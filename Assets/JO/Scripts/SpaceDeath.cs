using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceDeath : MonoBehaviour
{

    bool fix = false;
    public GameObject you_died;
    public AudioManager audMan;

    void Start(){
        audMan = GameObject.Find("Variables").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fix && Input.GetKeyDown(KeyCode.F)){
            Variables.managers.current_hp = 0;
            Variables.managers.malditoAmin = true;
            Variables.managers.portales["Kernel"] = 0;
            audMan.Play("Death");
            StartCoroutine("youRoutine");
        }
    }

    IEnumerator youRoutine(){
        you_died.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Elyiano");
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player") fix = true;
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player") fix = false;
    }
}
