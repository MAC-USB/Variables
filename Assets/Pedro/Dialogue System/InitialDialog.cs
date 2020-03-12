using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDialog : MonoBehaviour
{
    public static InitialDialog Manager { get; private set; }

    public ConversationSO initialConv = null;

    public string sceneDiag = "Elyiano";

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
                    DialogSystem.Manager.StartConversation(Variables.managers.deadElyiano);
                    if (Variables.managers.todosMuertos) DialogSystem.Manager.onDialogFinish.AddListener(() => DialogSystem.Manager.StartConversation(Variables.managers.dialogoTodosMuertos));
                }
                
                else if (sceneDiag == "Kernel")
                {
                    DialogSystem.Manager.StartConversation(Variables.managers.deadKernel);
                }
            }
        }
    }
}
