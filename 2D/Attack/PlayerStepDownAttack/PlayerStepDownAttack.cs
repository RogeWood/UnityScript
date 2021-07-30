//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private float attackForce = 800f;

    [SerializeField] private Rigidbody2D m_Rigidbody2D;
    [SerializeField] private Transform m_groundCheck;
    [SerializeField] private LayerMask m_groundLayer;

    [HideInInspector] public bool isDownAttack;

    private Vector2 movement;
    private bool jump;
    private bool isGround;

    const float GroundedRadius = .2f;

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Input
        movement.y = m_Rigidbody2D.velocity.y;
        if (Input.GetButtonDown("Jump"))
		{
            jump = true;
		}

        // Ground Check
        isGround = Physics2D.OverlapCircle(m_groundCheck.position, GroundedRadius, m_groundLayer);

    }

	private void FixedUpdate()
	{
        // Movement
        m_Rigidbody2D.velocity = movement;

        if (jump && isGround) //jump
		{
            m_Rigidbody2D.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }
        else if (jump && !isGround) //down attack
		{
            isDownAttack = true;
            m_Rigidbody2D.AddForce(new Vector2(0, attackForce * -1));
            jump = false;
        }
        else if (isGround)
		{
            isDownAttack = false;
		}

    }

}
