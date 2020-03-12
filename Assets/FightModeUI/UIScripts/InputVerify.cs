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

    public AudioManager audMan;

    private void Start(){
        ui_manager = GameObject.Find("MainPanel").GetComponent<FightUIManager>();
        bar_controller = GameObject.Find("Status").GetComponent<MHController>();
        audMan = ui_manager.manager.gameObject.GetComponent<AudioManager>();
    }

    private void Update(){
        if(ui_manager.current_ui_mode == UIMode.attackMode && Input.GetKeyDown(KeyCode.Return)){
            if(checkAnswer(ui_manager.monster.solution)){
                //Respuesta
                //Ganar y salir de combate. Secuencia de escape
                
                if (ui_manager.manager.boss){
                    audMan.Play("Victoria Boss");
                }
                else{
                    audMan.Play("Victoria Reto");
                }
                ui_manager.manager.challengeCompleted = true;
                StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Entry, ui_manager.manager.sceneName));
            } else {
                if(!ui_manager.is_blocking){
                    bar_controller.reduceBar("h", "f");
                    audMan.Play("Hit");
                } else {
                    //Blockeo
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
