using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalUI : MonoBehaviour
{
    public GameObject count;
    public GameObject panel;
    public GameObject leader_board;
    public GameObject leader_manager;
    private bool can_count = false;

    private void Start(){
        DontDestroyOnLoad(gameObject);
        initialState();
    }

    private void Update(){
        if(SceneManager.GetActiveScene().name != "Start"){
            leader_manager.SetActive(true);
            panel.SetActive(true);
            can_count = true;
        }

        if(SceneManager.GetActiveScene().name == "Kernel"){
            can_count = false;
            panel.SetActive(false);
        }

        if(can_count){
            updateCount();
        }
    }

    private void initialState(){
        panel.SetActive(false);
        leader_board.SetActive(false);
        leader_manager.SetActive(false);
    }

    private void updateCount(){
        int c = 4;
        switch(Variables.managers.sceneName){
            case "Elyiano":
                c -= Variables.managers.challengesCompletedElyiano.Count;
                break;
            case "Magicant":
                c -= Variables.managers.challengesCompletedMagicant.Count;
                break;
            case "LaPuta":
                c -= Variables.managers.challengesCompletedLaPuta.Count;
                break;
            case "Konohagakure":
                c -= Variables.managers.challengesCompletedKonohagakure.Count;
                break;
            case "Neovice":
                c -= Variables.managers.challengesCompletedNeovice.Count;
                break;
        }
        count.GetComponent<Text>().text = c.ToString();
    }
}
