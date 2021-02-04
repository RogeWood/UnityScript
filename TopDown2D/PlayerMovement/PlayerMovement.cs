using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D m_Rigidbody2D;

    private Vector2 movement;

    // Update is called once per frame
    private void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

	private void FixedUpdate()
	{
        // Movement
        m_Rigidbody2D.MovePosition(m_Rigidbody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
	}
}
