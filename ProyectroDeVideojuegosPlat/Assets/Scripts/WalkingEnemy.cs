﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
	public float vel;
	public Animator animator;
	private Rigidbody2D cha;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		cha = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.tag=="bad"){
			cha.velocity=new Vector2(vel,0);
		}

		animator.SetBool("running", true);

		if (this.gameObject.tag == "grab")
		{
			animator.SetBool("grabbed", true);
		}
	}
	
	void Voltear(){
		Vector3 Scaler = transform.localScale;
		Scaler.x*=-1;
		transform.localScale= Scaler;
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
    	GameObject ney= other.gameObject;
		if(ney.tag=="mover" && this.gameObject.tag=="bad"){
			Debug.Log("turn");
			vel=vel*(-1);
			Voltear();
		}
    }
		
}
