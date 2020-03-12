using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {



	public float speed;
	int vertical;
	int horizontal;
	public Animator anim;

    Vector3 velocity;

	void OnCollisionStay2D(Collision2D Other){
	}

	void Start(){
		transform.position = GameObject.Find("Variables").GetComponent<Variables>().position;
	}
	
	// Update is called once per frame
	void Update () {  
        velocity = Vector3.zero;
		
		if(Input.GetAxisRaw ("Vertical") > 0)
		{
			anim.SetBool ("Stop",false);
			anim.Play ("AnimationUp");
			velocity = new Vector3 (0, 0 + speed, 0);

		}else if(Input.GetAxisRaw ("Vertical") < 0)
		{
			anim.SetBool ("Stop",false);
			anim.Play ("AnimationDown");
			velocity = new Vector3 (0, 0 -speed, 0);

		}else if(Input.GetAxisRaw ("Horizontal") > 0)
		{
			anim.SetBool ("Stop",false);
			anim.Play ("AnimationRight");
			velocity = new Vector3 (0 + speed, 0, 0);
		}else if(Input.GetAxisRaw ("Horizontal") < 0)
		{
			anim.SetBool ("Stop",false);
			anim.Play ("AnimationLeft");
			velocity = new Vector3 (0 - speed, 0, 0);
		} else 
		{
			anim.SetBool ("Stop",true);
		}

        transform.position = transform.position + velocity;

			
	}
	
}
