using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalUI : MonoBehaviour
{
    public GameObject count;
    public GameObject you_died;
    public GameObject leader_board;
    public GameObject leader_manager;

    private void Start(){
        initialState();
    }

    private void Update(){
        DontDestroyOnLoad(gameObject);


    }

    private void initialState(){
        count.SetActive(false);
        you_died.SetActive(false);
        leader_board.SetActive(false);
        leader_manager.SetActive(false);
    }
}
