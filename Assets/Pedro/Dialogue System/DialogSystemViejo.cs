using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystemViejo : MonoBehaviour
{
    public Text dialogText = null;
    public GameObject panelObject = null;

    [SerializeField]
    private float letterDelay = 0.1f;
    [SerializeField]
    private float cositoDelay = 0.3f;

    private bool writing = false;
    private bool skip = false;
    private bool ready = false;

    [SerializeField]
    private ConversationSO currentDiag = null;

    private int current = 0;

    private Coroutine dialogTextRoutine = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) StartDialog(currentDiag);
        if (writing)
        {
            if (Input.GetKeyDown(KeyCode.Return)) skip = true;
        }
        if (ready)
        {
            if (Input.GetKeyDown(KeyCode.Return)) NextDialog();
        }
    }

    public void StartDialog(ConversationSO dialog)
    {
        currentDiag = dialog;
        current = 0;
        panelObject.SetActive(true);
        StartWriteDialogRoutine(currentDiag.dialogs[0]);
    }


    public void NextDialog()
    {
        ready = false;

        current += 1;
        if (current >= currentDiag.dialogs.Count)
        {
            StopCoroutine(dialogTextRoutine);
            dialogText.text = "";
            panelObject.SetActive(false);
        }
        else StartWriteDialogRoutine(currentDiag.dialogs[current]);
    }


    public void StartWriteDialogRoutine(string toWrite)
    {
        if (dialogTextRoutine != null) StopCoroutine(dialogTextRoutine);
        dialogTextRoutine = StartCoroutine(WriteDialogText(toWrite));
    }

    public IEnumerator WriteDialogText(string toWrite)
    {
        if (toWrite.Contains("Angel")) dialogText.color = Color.red;
        else if (toWrite.Contains("Amin")) dialogText.color = Color.blue;
        else dialogText.color = Color.white;

        writing = true;
        ready = false;
        dialogText.text = "";
        int i = 0;
        foreach (char c in toWrite)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(letterDelay);
            if (skip)
            {
                dialogText.text = toWrite;
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
}

