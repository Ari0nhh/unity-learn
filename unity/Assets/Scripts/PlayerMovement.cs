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
	}

	// Update is called once per frame
	void Update()
    {
        Debug.Assert(null != m_controller, "Character controller component is missing!");

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

		//2) Activation (E button)
		if (Input.GetButtonDown("Activate")) {

            var ray = new Ray(transform.position, transform.forward);
            var hits = Physics.SphereCastAll(ray, 5f);
            foreach(var hit in hits) {
                var go = hit.collider.gameObject;
                if (!go.CompareTag("Interactive"))
                    continue;

                var comps = go.GetComponents<Explorer.IInteractive>();
                foreach (var comp in comps)
                    comp.Activate();
            }
        }
        
    }

	private CharacterController m_controller = null;
    private float m_vert_speed = 0f;
}
