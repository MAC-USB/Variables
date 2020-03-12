using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogEvents : UnityEvent { }

public enum Characters { Caballero, Maga, Falso_EAS, EAS, Nadie};

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem Manager { get; private set;}

    /// <summary>
    /// Objeto UI del texto
    /// </summary>
    public Text dialogText = null;
    /// <summary>
    /// Objeto panel que contiene el texto
    /// </summary>
    public GameObject panelObject = null;

    /// <summary>
    /// Delay de escritura entre letras
    /// </summary>
    [SerializeField]
    private float letterDelay = 0.1f;
    
    /// <summary>
    /// Delay de blinkeo del pointer
    /// </summary>
    [SerializeField]
    private float cositoDelay = 0.3f;

    /// <summary>
    /// Indica si se esta escribiendo
    /// </summary>
    private bool writing = false;
    /// <summary>
    /// Indica si se hizo un skip
    /// </summary>
    private bool skip = false;
    /// <summary>
    /// Indica si el cuadro de dialogo ya termino de escribir
    /// </summary>
    private bool ready = false;

    /// <summary>
    /// Conversacion actual
    /// </summary>
    [SerializeField]
    private ConversationSO conversation = null;

    private int current = 0;

    private Coroutine dialogTextRoutine = null;

    public Text test;
    public MonsterSO testmonst;

    public DialogEvents onDialogStart = new DialogEvents();
    public DialogEvents onDialogFinish = new DialogEvents();

    private void Awake()
    {
        #region Singleton
        if (Manager != null && Manager != this)
        {
            Debug.LogError("Sistema de dialogo duplicado! Intentando borrar: " + Manager.name, Manager.gameObject);
            Destroy(Manager.gameObject);
        }
        Manager = this;
        #endregion
    }

    void Start(){
        if (panelObject != null) panelObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E)) StartConversation(conversation);
        //else if (Input.GetKeyDown(KeyCode.R)) StartMonsterDialogRoutine(testmonst, test);
        //else if (Input.GetKeyDown(KeyCode.T)) StartMonsterTipRoutine(testmonst, test);
        if (writing)
        {
            if (Input.GetKeyDown(KeyCode.Return)) skip = true;
        }
        if (ready)
        {
            if (Input.GetKeyDown(KeyCode.Return)) NextDialog();
        }
        
    }


    /// <summary>
    /// Inicia una conversacion
    /// </summary>
    /// <param name="conversation">Conversacion a iniciar</param>
    public void StartConversation(ConversationSO conversation)
    {
        this.conversation = conversation;
        current = 0;
        panelObject.SetActive(true);
        onDialogStart.Invoke();
        StartWriteDialogRoutine(this.conversation.dialogsSO[0]);
    }

    
    /// <summary>
    /// Cambia al siguiente dialogo en la conversacion
    /// </summary>
    public void NextDialog()
    {
        ready = false;

        current += 1;
        if (current >= conversation.dialogsSO.Count)
        {
            StopCoroutine(dialogTextRoutine);
            dialogText.text = "";
            panelObject.SetActive(false);
            onDialogFinish.Invoke();
        }
        else StartWriteDialogRoutine(conversation.dialogsSO[current]);
    }


    /// <summary>
    /// Empieza la corutina que se encarga de escribir un dialogo
    /// </summary>
    /// <param name="dialog">Dialogo a escribir</param>
    public void StartWriteDialogRoutine(DialogSO dialog)
    {
        if (dialogTextRoutine != null) StopCoroutine(dialogTextRoutine);
        dialogTextRoutine = StartCoroutine(WriteDialogText(dialog));
    }


    /// <summary>
    /// Escribe el texto del dialogo
    /// </summary>
    /// <param name="dialog">Dialogo a escribir</param>
    public IEnumerator WriteDialogText(DialogSO dialog)
    {
        dialogText.color = GetColor(dialog.talker);

        writing = true;
        ready = false;
        dialogText.text = GetName(dialog.talker);
        int i = 0;
        foreach (char c in dialog.dialog.Trim())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(letterDelay);
            if (skip)
            {
                dialogText.text = GetName(dialog.talker) + dialog.dialog.Trim();
                skip = false;
                break;
            }
        }
        writing = false;
        ready = true;
        i = 0;
        while (true)
        {
            if (i % 2 != 0) dialogText.text = dialogText.text.Remove(dialogText.text.Length - 1);
            else dialogText.text += "|";
            yield return new WaitForSeconds(cositoDelay);
            i += 1;
        }
    }

    /// <summary>
    /// Empieza la corutina que se encarga de escribir un dialogo de monstruo
    /// </summary>
    /// <param name="monster">Monstruo a escribir problema</param>
    /// <param name="textBox">Caja de texto donde escribir problema</param>
    public void StartMonsterDialogRoutine(MonsterSO monster, Text textBox)
    {
        if (dialogTextRoutine != null) StopCoroutine(dialogTextRoutine);
        dialogTextRoutine = StartCoroutine(WriteMonsterText(monster.problem.Trim() + "... ", textBox));
    }

    /// <summary>
    /// Empieza la corutina que se encarga de escribir un tip de un monstruo
    /// </summary>
    /// <param name="monster">Monstruo a escribir tip</param>
    /// <param name="textBox">Caja de texto donde escribir tip</param>
    public void StartMonsterTipRoutine(MonsterSO monster, Text textBox)
    {
        if (dialogTextRoutine != null) StopCoroutine(dialogTextRoutine);
        dialogTextRoutine = StartCoroutine(WriteMonsterText(monster.tip.Trim(), textBox, monster.problem.Trim() + "... "));
    }

    public void StopMonsterDiag()
    {
        StopCoroutine(dialogTextRoutine);
    }

    /// <summary>
    /// Corutina que se encarga de escribir un dialogo de monstruo
    /// </summary>
    /// <param name="monster">Monstruo a escribir problema</param>
    /// <param name="textBox">Caja de texto donde escribir problema</param>
    public IEnumerator WriteMonsterText(string toWrite, Text textBox, string initial = "")
    {
        textBox.color = Color.white;

        writing = true;
        ready = false;
        textBox.text = initial;
        int i = 0;
        foreach (char c in toWrite)
        {
            textBox.text += c;
            yield return new WaitForSeconds(letterDelay);
            if (skip)
            {
                textBox.text = toWrite;
                skip = false;
                break;
            }
        }
        writing = false;
        i = 0;
        while (true)
        {
            if (i % 2 != 0) textBox.text = textBox.text.Remove(textBox.text.Length - 1);
            else textBox.text += "|";
            yield return new WaitForSeconds(cositoDelay);
            i += 1;
        }
    }

    public string GetName(Characters character)
    {
        switch (character)
        {
            case Characters.EAS:
                return "EAS: ";
            case Characters.Falso_EAS:
                return "EAS: ";
            case Characters.Maga:
                return "Maga: ";
            case Characters.Caballero:
                return "Caballero: ";
            default:
                return "";
        }
    }

    public Color GetColor(Characters character)
    {
        switch (character) {
            case Characters.EAS:
                return Color.yellow;
            case Characters.Falso_EAS:
                return Color.white;
            case Characters.Maga:
                return Color.red;
            case Characters.Caballero:
                return Color.blue;
            default:
                return Color.white;
        }
    }
}
