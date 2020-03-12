using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDialog : MonoBehaviour
{
    public static InitialDialog Manager { get; private set; }

    public ConversationSO initialConv = null;
    public ConversationSO deadConv = null;

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
    void StartInitial()
    {
        if (!Variables.managers.diagInit[sceneDiag])
        {
            DialogSystem.Manager.StartConversation(initialConv);
            Variables.managers.diagInit[sceneDiag] = true;
        }
        else
        {
            if (sceneDiag == "Elyiano" && Variables.managers.malditoAmin)
            {
                DialogSystem.Manager.StartConversation(deadConv);
            }
        }
    }
}
