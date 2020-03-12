using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Color selected = Color.cyan;
    public Color unselected = Color.blue;
    public bool is_vertical;
    public GameObject[] options;
    private FightUIManager manager;
    private float index = 0;
    private KeyCode more = KeyCode.RightArrow;
    private KeyCode less = KeyCode.LeftArrow;
    private bool can_move = true;

    private void Awake()
    {
        manager = GameObject.Find("MainPanel").GetComponent<FightUIManager>();

        if (is_vertical){
            less = KeyCode.UpArrow;
            more = KeyCode.DownArrow;
        }

        while(index < options.Length){
            updateColors(unselected);
            index++;
        }
        index = 0;
        updateColors(selected);
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Return)){
            can_move = false;

            if (is_vertical){
                setUIModeV();
            } else {
                setUIMode();
            }
        }

        if (can_move){
            if(Input.GetKeyDown(less)){
                updateColors(unselected);
                index = (index - 1) < 0? 2 : index - 1;
            }

            if(Input.GetKeyDown(more)){
                updateColors(unselected);
                index = (index + 1) % options.Length;
            }

            updateColors(selected);
        }
    }

    private void updateColors(Color c){
        options[(int)index].GetComponent<Image>().color = c;
        Transform t = options[(int)index].transform.GetChild(0);
        t.GetComponent<Text>().color = c;
    }

    private void setUIMode(){
        switch(index){
            case 0:
                manager.updateUI(UIMode.attackMode);
                break;
            case 1:
                manager.updateUI(UIMode.specialMode);
                break;
            case 2:
                manager.escapeSecuence();
                break;
        }
    }

    private void setUIModeV(){
        switch(index){
            case 0:
                //manager.updateUI(UIMode.attackMode);
                break;
            case 1:
                //manager.updateUI(UIMode.specialMode);
                break;
            case 2:
                //manager.escapeSecuence();
                break;
        }
    }

}
