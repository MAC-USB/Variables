using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GUIMode{

}

public class GlobalUI : MonoBehaviour
{
    public GameObject count;
    public GameObject you_died;
    public GameObject leader_board;

    private void Update(){
        switch(Variables.managers.sceneName){
            case "Start":
                count.SetActive(false);
                you_died.SetActive(false);
                leader_board.SetActive(false);
            break;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void StartMode(){

    }
}
