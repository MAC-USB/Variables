﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEncounter : MonoBehaviour
{
    bool fix = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fix && Input.GetKeyDown(KeyCode.F)){
            Variables.managers.position = transform.position;
            Variables.managers.boss = true;
            StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Boss, "UI"));
            //SceneManager.LoadScene(to);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Boss") fix = true;
    }
    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Boss") fix = false;
    }
}
