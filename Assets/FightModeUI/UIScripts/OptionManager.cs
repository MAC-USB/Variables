﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public bool can_move = true;
    public Color selected = Color.cyan;
    public Color unselected = Color.blue;
    public bool is_vertical;
    public GameObject[] options;
    private FightUIManager manager;
    public MHController bar_controller;
    private float index = 0;
    private KeyCode more = KeyCode.RightArrow;
    private KeyCode less = KeyCode.LeftArrow;

    private void Awake()
    {
        manager = GameObject.Find("MainPanel").GetComponent<FightUIManager>();
        bar_controller = GameObject.Find("Status").GetComponent<MHController>();

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
        if (Input.GetKeyDown(KeyCode.Return) && can_move){
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
                bar_controller.reduceBar("h", "s");
                manager.scapeSecuence();
                break;
        }
    }

    private void setUIModeV(){
        switch(index){
            case 0:
                manager.is_blocking = true;
                bar_controller.reduceBar("m", "f");
                manager.updateUI(UIMode.attackMode);
                break;
            case 1:
                bar_controller.reduceBar("m", "f");
                manager.updateUI(UIMode.tipMode);
                break;
            case 2:
                bar_controller.reduceBar("M", "f");
                bar_controller.increaseBar();
                manager.updateUI(UIMode.initialMode);
                break;
        }
    }

}
