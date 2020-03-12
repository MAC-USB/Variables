using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public Vector3 position;
    public KeyCode buttom;
    public string to;
    public string from;
    bool fix = false;

    Variables variables;

    // Start is called before the first frame update
    void Start()
    {
        variables = GameObject.Find("Variables").GetComponent<Variables>();
        if(variables.portales[to] == 1){
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().Play("Portal");
            foreach(BoxCollider2D box in this.GetComponents<BoxCollider2D>()){
                box.enabled = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // RECORDAR CAMBIAR ESTO variables.portales[to] = 1;

        if(Variables.managers.portales[to] == 1){
            GetComponent<Animator>().enabled = true;
            foreach (BoxCollider2D box in this.GetComponents<BoxCollider2D>()){
                box.enabled = true;
            }
            variables.portales[from] = 1;
        }
        if (fix && Input.GetKeyDown(KeyCode.F)){
            variables.position = position;
            Variables.managers.portalCrossing = true;
            StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Portal, to));
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
