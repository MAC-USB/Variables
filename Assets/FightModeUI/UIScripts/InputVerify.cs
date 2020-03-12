using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputVerify : MonoBehaviour
{
    [HideInInspector()]
    public FightUIManager ui_manager;

    private void Start(){
        ui_manager = GameObject.Find("MainPanel").GetComponent<FightUIManager>();
    }

    private void Update(){
        if(ui_manager.current_ui_mode == UIMode.attackMode && Input.GetKeyDown(KeyCode.Return)){
            if(checkAnswer(ui_manager.monster.solution)){
                //Respuesta
                //Ganar y salir de combate. Secuencia de escape
                Debug.Log("Win");
                ui_manager.manager.challengeCompleted = true;
            } else {
                if(!ui_manager.is_blocking){
                    //Perder vida
                    //Barra de vida
                } else {
                    ui_manager.is_blocking = false;
                }

                Debug.Log("Fail");
                ui_manager.updateUI(UIMode.initialMode);
            }
        }
    }

    private bool checkAnswer(string answer){
        return GetComponent<InputField>().text == answer;
    }
}
