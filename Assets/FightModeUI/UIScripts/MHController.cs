using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MHController : MonoBehaviour
{
    public Variables manager;
    private RectTransform h;
    private RectTransform m;

    void Start()
    {
        manager = GameObject.Find("Variables").GetComponent<Variables>();

        h = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        m = transform.GetChild(1).gameObject.GetComponent<RectTransform>();

        h.localScale = new Vector2(getHScale() , h.localScale.y);
        m.localScale = new Vector2(getMScale() , h.localScale.y);
    }

    float getHScale(){
        return (manager.current_hp * h.localScale.x) / manager.initial_hp;
    }

    float getMScale(){
        return (manager.current_mp * m.localScale.x) / manager.initial_mp;
    }

    public void reduceBar(string b, string t){
        switch (b){
            case "h":
                if(t == "f"){
                    if(manager.current_mp > 2){
                        manager.current_hp -= 2;
                    }
                } else {
                    if(manager.current_mp > 1){
                        manager.current_hp -= 1;
                    }
                }

                h.localScale = new Vector2(getHScale() , h.localScale.y);
                break;
            case "m":
                if(manager.current_mp > 1){
                    manager.current_mp -= 1;
                    m.localScale = new Vector2(getMScale() , m.localScale.y);
                }
                break;
        }
    }
    public void increaseBar(){
        if (manager.current_hp <= Mathf.RoundToInt(manager.initial_hp / 2)){
            manager.current_hp += Mathf.RoundToInt(manager.initial_hp / 2);
            h.localScale = new Vector2(getHScale() , h.localScale.y);
        }
    }
}