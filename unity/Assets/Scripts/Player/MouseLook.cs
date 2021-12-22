using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum Axes { Vertical = 0, Horizontal, Both }
    
    [SerializeField] private float Sensivity = 9.0f;
    [SerializeField] private Axes Axe = Axes.Both;
    [SerializeField] private CharacterHealth HealthController;
    
    void Start()
    {
        Debug.Assert(null != HealthController, "Health controller is not assigned!");

        var body = GetComponent<Rigidbody>();
        if (null == body)
            return;

        body.freezeRotation = true;
    }

    void Update()
    {
        if (HealthController.IsDead)
            return;
        
        switch(Axe) {
            case Axes.Horizontal:
                transform.Rotate(0, Input.GetAxis("Mouse X") * Sensivity, 0);
                break;
            case Axes.Vertical: {
                    m_rot_x -= Input.GetAxis("Mouse Y") * Sensivity;
                    m_rot_x = Mathf.Clamp(m_rot_x, m_min_angle, m_max_angle);
                    var rot_y = transform.localEulerAngles.y;
                    transform.localEulerAngles = new Vector3(m_rot_x, rot_y, 0);
                }
                break;
            case Axes.Both: {
                    m_rot_x -= Input.GetAxis("Mouse Y") * Sensivity;
                    m_rot_x = Mathf.Clamp(m_rot_x, m_min_angle, m_max_angle);

                    var delta = Input.GetAxis("Mouse X") * Sensivity;
                    var rot_y = transform.localEulerAngles.y + delta;

                    transform.localEulerAngles = new Vector3(m_rot_x, rot_y, 0);
                }
                break;
        }
    }

    private const float m_min_angle = -45.0f;
    private const float m_max_angle = +45.0f;
    private float m_rot_x = 0.0f;
}
