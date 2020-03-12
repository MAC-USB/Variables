using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public enum UIMode {
    attackMode,
    specialMode,
    tipMode,
    dialogMode,
    initialMode
}

public class FightUIManager : MonoBehaviour
{
    // Shared 
    public UIMode current_ui_mode;
    public MonsterSO monster;
    public bool is_blocking = false;
    
    // Main Scripts
    public Variables manager;
    private DialogSystem dialog;
    
    //UI Components
    private GameObject monster_image;
    private GameObject attack_panel;
    private GameObject dialog_panel;
    private GameObject special_options;
    private GameObject button_area;

    //Event system
    private GameObject event_system_manager;

    private void Awake(){
        manager = GameObject.Find("Variables").GetComponent<Variables>();
        dialog = GameObject.Find("Variables").GetComponent<DialogSystem>();
        event_system_manager = GameObject.Find("EventSystem");

        monster_image = transform.GetChild(0).gameObject;
        attack_panel = transform.GetChild(1).gameObject;
        dialog_panel = transform.GetChild(2).gameObject;
        special_options = transform.GetChild(3).gameObject;
        button_area = transform.GetChild(4).gameObject;

        initialMode();
    }

    private void Start(){
        //GetMonster
    }

    public void updateUI(UIMode mode){
        switch(mode){
             case UIMode.initialMode:
                initialMode();
                break;
            case UIMode.attackMode:
                attackMode();
                break;
            case UIMode.specialMode:
                specialMode();
                break;
            case UIMode.dialogMode:
                monsterDialogMode();
                break;
            case UIMode.tipMode:
                monsterTipMode();
                break;
        }

        current_ui_mode = mode;
    }

    public void escapeSecuence(){

    }

    // Init and reset modes
    private void initialMode(){
        monster_image.SetActive(true);
        attack_panel.SetActive(false);
        dialog_panel.SetActive(true);
        special_options.SetActive(false);
        button_area.SetActive(true);

        button_area.GetComponent<OptionManager>().can_move = true;

        monsterDialogMode();
    }

    private void resetMode(){
        monster_image.SetActive(true);
        attack_panel.SetActive(true);
        dialog_panel.SetActive(true);
        special_options.SetActive(true);
        button_area.SetActive(true);
    }

    // Dialog modes
    private void monsterDialogMode(){
        resetMode();
        attack_panel.SetActive(false);
        special_options.SetActive(false);
        dialog.StartMonsterDialogRoutine(monster, dialog_panel.transform.GetChild(0).gameObject.GetComponent<Text>());
    }

    private void monsterTipMode(){
        dialog.StartMonsterTipRoutine(monster, dialog_panel.transform.GetChild(0).gameObject.GetComponent<Text>());
    }

    // Selection mode
    private void specialMode(){
        resetMode();
        dialog.StopMonsterDiag();
        attack_panel.SetActive(false);
        dialog_panel.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Attack and block modes
    private void attackMode(){
        resetMode();
        dialog.StopMonsterDiag();
        special_options.SetActive(false);
        dialog_panel.SetActive(false);
        attack_panel.GetComponent<InputField>().text = "";
        //EventSystem.current.SetSelectedGameObject(attack_panel.gameObject, null);
        //attack_panel.GetComponent<InputField>().OnPointerClick(null);
    }
}