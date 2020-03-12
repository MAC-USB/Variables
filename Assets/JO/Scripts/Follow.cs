using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class Follow : MonoBehaviour
{
//place this script on the player gameobject
 
    public GameObject follow; 
    public int followDistance;
    private List<Vector3> storedPositions;
    public Animator anim;
    private Vector3 prev;
 
 
    void Awake()
    {
        storedPositions = new List<Vector3>(); //create a blank list
     
        if(!follow)
        {
            Debug.Log("The FollowingMe gameobject was not set");
        }      
     
        if(followDistance == 0)
        {
            Debug.Log("Please set distance higher then 0");
        }
    }
 
    void Start ()
    {
        transform.position = GameObject.Find("Caballero").transform.position;
    }
 
    void Update()
    {
        if(transform.position.y > follow.transform.position.y){
            transform.position = new Vector3(transform.position.x,transform.position.y,1);
        } else{
            transform.position = new Vector3(transform.position.x,transform.position.y,-1);
        }
        
        if(storedPositions.Count == 0 || storedPositions[storedPositions.Count - 1] != follow.transform.position){
            storedPositions.Add(follow.transform.position); //store the position every frame
        }

        if(storedPositions.Count > followDistance)
        {
            prev = transform.position;
            transform.position = storedPositions[0]; //move the player

            if(prev.x < transform.position.x){
                anim.SetBool ("Stop",false);
			    anim.Play ("AnimationRight");
            } else if(prev.x > transform.position.x){
                anim.SetBool ("Stop",false);
			    anim.Play ("AnimationLeft");
            }else if(prev.y < transform.position.y){
                anim.SetBool ("Stop",false);
                anim.Play ("AnimationUp");
            } else if((prev.y > transform.position.y)){
                anim.SetBool ("Stop",false);
                anim.Play ("AnimationDown");
            }
        
            if(transform.position.y > follow.transform.position.y){
                transform.position = new Vector3(transform.position.x,transform.position.y,1);
            } else{
                transform.position = new Vector3(transform.position.x,transform.position.y,-1);
            }

            
            storedPositions.RemoveAt (0); //delete the position that player just move to

        }else{

            anim.SetBool ("Stop",true);
        }
    }
}