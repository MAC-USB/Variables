using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputVerify : MonoBehaviour
{
    public FightUIManager ui_manager;

    private void Start(){
        ui_manager = GameObject.Find("MainPanel").GetComponent<FightUIManager>();
    }

    private void Update(){
        if(ui_manager.current_ui_mode == UIMode.attackMode && Input.GetKeyDown(KeyCode.Return)){
            if(checkAnswer(ui_manager.monster.solution)){
                //Respuesta
                //Ganar y salir de combate. Secuencia de escape
                ui_manager.manager.challengeCompleted = true;
            } else {
                //Perder vida
                //Barra de vida
                Debug.Log("Fail");
                ui_manager.updateUI(UIMode.initialMode);
            }
        }
    }

    private bool checkAnswer(string answer){
        return GetComponent<InputField>().text == answer;
    }
}
