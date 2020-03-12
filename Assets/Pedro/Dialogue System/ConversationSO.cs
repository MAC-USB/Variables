using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "conversacion_", menuName = "Conversacion")]
public class ConversationSO : ScriptableObject
{
    // DEPRECATED, se usa solo en el sistema DialogSystemViejo
    public List<string> dialogs;
    public List<DialogSO> dialogsSO;
}
