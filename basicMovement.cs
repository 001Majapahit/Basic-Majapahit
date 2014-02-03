using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (CapsuleCollider))]

public class basicMovement : MonoBehaviour 
{
	private bool running, attacking;
	private Animator animator;

	void Awake ()
	{
		rigidbody.freezeRotation = true;
		rigidbody.mass = 60.0f;
		animator = GetComponent<Animator>();
		attacking = false;
		running = false;
	}

	void Start ()
	{

	}

	void FixedUpdate ()
	{
		float H = Input.GetAxis("Horizontal");
		float V = Input.GetAxis("Vertical");

		basicMove(H,V);
	}

	void basicMove (float h, float v)
	{
		animator.SetFloat("Speed", v);
		animator.SetFloat("Direction", h);

		if(Input.GetButton("Run"))
			running = true;
		else
			running = false;

		if(Input.GetKeyDown(KeyCode.X))
			attacking = true;
		if(Input.GetKeyUp(KeyCode.X))
			attacking = false;

		Running(running);
		Attacking(attacking);
	}

	void Running (bool check)
	{
		animator.SetBool("Run", check);
	}

	void Attacking (bool check)
	{
		animator.SetBool("KickJump", check);
	}

}
