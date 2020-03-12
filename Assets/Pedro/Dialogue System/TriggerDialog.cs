using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class TriggerDialog : MonoBehaviour
{
    public ConversationSO conversation = null;
    private Collider2D coll2d = null;
    private bool wasActivated = false;

    private void Awake()
    {
        coll2d = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!coll2d.isTrigger) Debug.LogWarning("El trigger de dialogo no es trigger :(", gameObject);
        if (conversation == null) Debug.LogWarning("El trigger de dialogo no tiene dialogo :(", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Solo deberia colisionar el jugador
        if (!wasActivated)
        {
            Debug.Log("Si lees esto eres marico oyo");
            DialogSystem.Manager.StartConversation(conversation);
            wasActivated = true;
        }
    }
}
