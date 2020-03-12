using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIMode {
    attackMode,
    specialMode,
    tipMode,
    dialogMode,
    initialMode
}

public class FightUIManager : MonoBehaviour
{
    private Variables manager;
    private DialogSystem dialog;
    public MonsterSO monster;
    private GameObject monster_image;
    private GameObject attack_panel;
    private GameObject dialog_panel;
    private GameObject special_options;
    private GameObject button_area;

    private void Awake(){
        manager = GameObject.Find("Variables").GetComponent<Variables>();
        dialog = GameObject.Find("Variables").GetComponent<DialogSystem>();

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
    }

    public void escapeSecuence(){

    }

    private void initialMode(){
        monster_image.SetActive(true);
        attack_panel.SetActive(false);
        dialog_panel.SetActive(true);
        special_options.SetActive(false);
        button_area.SetActive(true);

        monsterDialogMode();
    }

    private void resetMode(){
        monster_image.SetActive(true);
        attack_panel.SetActive(true);
        dialog_panel.SetActive(true);
        special_options.SetActive(true);
        button_area.SetActive(true);
    }

    private void monsterDialogMode(){
        resetMode();
        attack_panel.SetActive(false);
        special_options.SetActive(false);
        dialog.StartMonsterDialogRoutine(monster, dialog_panel.transform.GetChild(0).gameObject.GetComponent<Text>());
    }

    private void monsterTipMode(){
        dialog.StartMonsterTipRoutine(monster, dialog_panel.transform.GetChild(0).gameObject.GetComponent<Text>());
    }

    private void attackMode(){
        resetMode();
        dialog.StopMonsterDiag();
        dialog_panel.SetActive(false);
        special_options.SetActive(false);
    }

    private void specialMode(){
        resetMode();
        attack_panel.SetActive(false);
    }

    private void inputChecker(){
        if (monster.solution.Equals(dialog_panel.transform.GetChild(0).GetComponent<InputField>().text)){
            //Kill monster
        } else {
            updateUI(UIMode.initialMode);
        }
    }
}