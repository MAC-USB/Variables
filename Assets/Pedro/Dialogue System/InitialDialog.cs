using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDialog : MonoBehaviour
{
    public static InitialDialog Manager { get; private set; }

    public ConversationSO initialConv = null;

    public string sceneDiag = "Elyiano";

    private bool xd = false;

    private void Awake()
    {
        if (Manager != null && Manager != this)
        {
            Debug.LogWarning("Dialogo inicial duplicado");
        }
        Manager = this;
    }


    // Start is called before the first frame update
    public void StartInitial()
    {
        if (!Variables.managers.diagInit[sceneDiag])
        {
            DialogSystem.Manager.StartConversation(initialConv);
            Variables.managers.diagInit[sceneDiag] = true;
        }
        else
        {
            if ((sceneDiag == "Elyiano" || sceneDiag == "Kernel") && Variables.managers.malditoAmin)
            {
                if (sceneDiag == "Elyiano")
                {
                    if (!Variables.managers.dialogoMuerteDicho)
                    {
                        DialogSystem.Manager.StartConversation(Variables.managers.deadElyiano);
                        Variables.managers.dialogoMuerteDicho = true;
                    }
                    if (Variables.managers.todosMuertos)
                    {
                        DialogSystem.Manager.onDialogFinish.AddListener(dale);
                        StartCoroutine(maldito());
                    }
                }
                
                else if (sceneDiag == "Kernel")
                {
                    GameObject.Find("Neovice").GetComponent<Teleport>().DisableTeleport();
                    GameObject.Find("Caballero").GetComponent<Movement>().enabled = false;
                    DialogSystem.Manager.StartConversation(Variables.managers.deadKernel);
                }
            }
        }
    }

    public void dale()
    {
        xd = true;
    }

    public IEnumerator maldito()
    {
        while (!xd) yield return new WaitForSeconds(0);
        DialogSystem.Manager.onDialogFinish.RemoveListener(dale);
        DialogSystem.Manager.StartConversation(Variables.managers.dialogoTodosMuertos);
    }
}
