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
        if (Input.GetKeyDown (KeyCode.O))
            StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Boss, "Test"));
        if (Input.GetKeyDown (KeyCode.I))
            StartCoroutine(SimpleBlit.managers.FadeIn(TransType.Boss));
        if (Input.GetKeyDown (KeyCode.K))
            StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Portal, "Test"));
        if (Input.GetKeyDown (KeyCode.L))
            StartCoroutine(SimpleBlit.managers.FadeIn(TransType.Portal));
        if (Input.GetKeyDown (KeyCode.M))
            StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Random, "Test"));
        if (Input.GetKeyDown (KeyCode.Comma))
            StartCoroutine(SimpleBlit.managers.FadeIn(TransType.Random));
        if (Input.GetKeyDown (KeyCode.Y))
            StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Entry, "Test"));
        if (Input.GetKeyDown (KeyCode.U))
            StartCoroutine(SimpleBlit.managers.FadeIn(TransType.Entry));
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
