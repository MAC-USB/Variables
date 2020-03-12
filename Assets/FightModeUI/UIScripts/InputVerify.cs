using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputVerify : MonoBehaviour
{
    [HideInInspector()]
    public FightUIManager ui_manager;
    [HideInInspector()]
    public MHController bar_controller;

    private void Start(){
        ui_manager = GameObject.Find("MainPanel").GetComponent<FightUIManager>();
        bar_controller = GameObject.Find("Status").GetComponent<MHController>();
    }

    private void Update(){
        if(ui_manager.current_ui_mode == UIMode.attackMode && Input.GetKeyDown(KeyCode.Return)){
            if(checkAnswer(ui_manager.monster.solution)){
                //Respuesta
                //Ganar y salir de combate. Secuencia de escape
                StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Entry, ui_manager.manager.sceneName));
            } else {
                if(!ui_manager.is_blocking){
                    bar_controller.reduceBar("h", "f");
                } else {
                    ui_manager.is_blocking = false;
                }

                ui_manager.updateUI(UIMode.initialMode);
            }
        }
    }

    private bool checkAnswer(string answer){
        return GetComponent<InputField>().text == answer;
    }
}
