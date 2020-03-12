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
                switch(t){
                    case "f":
                        manager.current_hp -= 2;
                        h.localScale = new Vector2(getHScale() , h.localScale.y);
                        break;
                    case "r":
                        //reducir 1
                        break;
                }
                break;
            case "m":
                    //reducir 1
                break;
        }
    }
    public void increaseBar(){

    }
}
