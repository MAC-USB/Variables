using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
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
    public GameObject you_died;
    public GameObject status;

    // Main Scripts
    public Variables manager;
    private DialogSystem dialog;
    
    //UI Components
    private GameObject monster_image;
    private GameObject attack_panel;
    private GameObject dialog_panel;
    private GameObject special_options;
    private GameObject button_area;
    private AudioManager audMan;

    //Event system
    private GameObject event_system_manager;

    private void Awake(){
        manager = GameObject.Find("Variables").GetComponent<Variables>();
        dialog = GameObject.Find("Variables").GetComponent<DialogSystem>();
        event_system_manager = GameObject.Find("EventSystem");

        audMan = GameObject.Find("Variables").GetComponent<AudioManager>();

        monster_image = transform.GetChild(0).gameObject;
        attack_panel = transform.GetChild(1).gameObject;
        dialog_panel = transform.GetChild(2).gameObject;
        special_options = transform.GetChild(3).gameObject;
        button_area = transform.GetChild(4).gameObject;

    }

    public void scapeSecuence(){
        //manager.challengeCompleted = true;
        SimpleBlit.managers.enabled = true;
        
        audMan.Play("Huir");

        StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Entry, manager.sceneName));
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            updateUI(UIMode.initialMode);
        }

        if(manager.current_hp <= 0){
            StartCoroutine("youRoutine");
        }
    }

    IEnumerator youRoutine(){
        monster_image.SetActive(false);
        attack_panel.SetActive(false);
        dialog_panel.SetActive(false);
        special_options.SetActive(false);
        button_area.SetActive(false);
        status.SetActive(false);
        you_died.SetActive(true);
        audMan.Play("Death");
        yield return new WaitForSeconds(3f);
        reborn();
    }

    void reborn(){
        SceneManager.LoadScene("Elyiano");
        manager.position = new Vector3(-0.75f, -6f, 0f);
        manager.current_hp = manager.initial_hp;
    }

    private void Start(){
        monster = MonsterPicker.Picker.GetMonster(manager.currentChallenge);
        monster_image.GetComponent<Image>().sprite = monster.sprite;
        monster_image.transform.GetChild(0).gameObject.GetComponent<Text>().text = monster.id;
        SimpleBlit.managers.enabled = false;

        you_died.SetActive(false);

        updateUI(UIMode.initialMode);
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

    // Init and reset modes
    private void initialMode(){
        monster_image.SetActive(true);
        attack_panel.SetActive(false);
        dialog_panel.SetActive(true);
        special_options.SetActive(false);
        button_area.SetActive(true);

        button_area.GetComponent<OptionManager>().can_move = true;
        special_options.GetComponent<OptionManager>().can_move = true;

        dialog_panel.transform.GetChild(0).gameObject.SetActive(true);
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
        DialogSystem.Manager.StartMonsterDialogRoutine(monster, dialog_panel.transform.GetChild(0).gameObject.GetComponent<Text>());
    }

    private void monsterTipMode(){
        resetMode();
        dialog_panel.transform.GetChild(0).gameObject.SetActive(true);
        attack_panel.SetActive(false);
        special_options.SetActive(false);
        DialogSystem.Manager.StartMonsterTipRoutine(monster, dialog_panel.transform.GetChild(0).gameObject.GetComponent<Text>());

        button_area.GetComponent<OptionManager>().can_move = true;
        special_options.GetComponent<OptionManager>().can_move = true;
    }

    // Selection mode
    private void specialMode(){
        resetMode();
        //dialog.StopMonsterDiag();
        attack_panel.SetActive(false);
        dialog_panel.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Attack and block modes
    private void attackMode(){
        FileUpdate.update();
        resetMode();
        //dialog.StopMonsterDiag();
        special_options.SetActive(false);
        dialog_panel.SetActive(false);
        attack_panel.GetComponent<InputField>().text = "";
        //EventSystem.current.SetSelectedGameObject(attack_panel.gameObject, null);
        //attack_panel.GetComponent<InputField>().OnPointerClick(null);
    }

    
}