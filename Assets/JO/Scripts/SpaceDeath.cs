using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDeath : MonoBehaviour
{

    bool fix = false;

    // Update is called once per frame
    void Update()
    {
        if (fix && Input.GetKeyDown(KeyCode.F)){
            Variables.managers.current_hp = 0;
            Variables.managers.malditoAmin = true;
            Variables.managers.portales["Kernel"] = 0;
            StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Portal, "Elyiano"));
            //SceneManager.LoadScene(to);
        }
    }


    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") fix = true;
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player") fix = false;
    }
}
