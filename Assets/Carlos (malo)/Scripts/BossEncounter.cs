using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEncounter : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other){

        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F)){
            // transition
            // Load battle scene
            Variables.managers.boss = true;
            StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Boss, "UI"));
        }
    }
}
