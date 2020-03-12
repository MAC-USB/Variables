using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MHController : MonoBehaviour
{
    public Variables manager;
    private RectTransform h;
    private RectTransform m;

    private float initial_h;
    private float initial_m;

    void Start()
    {
        manager = GameObject.Find("Variables").GetComponent<Variables>();

        h = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        m = transform.GetChild(1).gameObject.GetComponent<RectTransform>();

        initial_h = h.localScale.x;
        initial_m = m.localScale.x;

        h.localScale = new Vector2(getHScale() , h.localScale.y);
        m.localScale = new Vector2(getMScale() , h.localScale.y);
    }

    float getHScale(){
        return (manager.current_hp * initial_h) / manager.initial_hp;
    }

    float getMScale(){
        return (manager.current_mp * initial_m) / manager.initial_mp;
    }

    public void reduceBar(string b, string t){
        switch (b){
            case "h":
                if(t == "f"){
                    if(manager.current_hp > 1){
                        manager.current_hp -= 2;
                    }
                    else{
                        manager.current_hp = 0;
                    }
                } else {
                    if(manager.current_hp >= 1){
                        manager.current_hp -= 1;
                    }
                }

                h.localScale = new Vector2(getHScale() , h.localScale.y);
                break;
            case "m":
                if(manager.current_mp >= 1){
                    manager.current_mp -= 1;
                    m.localScale = new Vector2(getMScale() , m.localScale.y);
                }
                break;
            case "M":
                if(manager.current_mp >= 6){
                    manager.current_mp -= 6;
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