using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 1.0f;
    [SerializeField] private float Gravity = -9.8f;
    [SerializeField] private float JumpSpeed = 15f;

    private void Start()
	{
        m_controller = GetComponent<CharacterController>();
        m_health = GetComponent<CharacterHealth>();
	}

	// Update is called once per frame
	void Update()
    {
        if (!m_alive)
            return;

        Debug.Assert(null != m_controller, "Character controller component is missing!");
        Debug.Assert(null != m_health, "Health controller component is missing!");

		if (m_health.IsDead) {
            m_alive = false;

            transform.Rotate(Vector3.left, 90);
            transform.Translate(0, 0.5f, 0);
            return;
		}
        

        //0) Jumping
        if (m_controller.isGrounded) {
			if (Input.GetButtonDown("Jump")) {
                m_vert_speed = JumpSpeed;
			}
		}else {
            m_vert_speed += Gravity * Time.deltaTime / 4f;
		}

        m_vert_speed = Mathf.Clamp(m_vert_speed, -JumpSpeed, JumpSpeed);

        //1) Movement
        var dx = Input.GetAxis("Horizontal") * Speed;
        var dz = Input.GetAxis("Vertical") * Speed;
        var movement = new Vector3(dx, 0, dz);
        
        //1.1) Clamp diagonal speed
        movement = Vector3.ClampMagnitude(movement, Speed) * Time.deltaTime;
        movement.y = m_vert_speed;
        movement = transform.TransformDirection(movement);

        m_controller.Move(movement);
    }

    private bool m_alive = true;
    private CharacterController m_controller = null;
    private CharacterHealth m_health = null;
    private float m_vert_speed = 0f;
}
