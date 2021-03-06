﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller; // use with CharacterController2D

	public float runSpeed = 10f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		// Input
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if(Input.GetButtonDown("Jump"))
		{
			jump = true;
		}

		if(Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if(Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
    }

	void FixedUpdate()
	{
		// Move charactor
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

		jump = false;
	}
}
