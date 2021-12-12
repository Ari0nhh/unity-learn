using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour, Explorer.IInteractive
{
    [SerializeField] private GameObject AssignedDoor;
    [SerializeField] private GameObject WallPoint;

    public void Activate()
	{
        Debug.Assert(null != AssignedDoor, "Assigned door is not assigned (funny, yes =)");

        m_activated = true;
        m_initial = AssignedDoor.transform.position.y;
        m_angle = transform.rotation.eulerAngles.y;
	}
    
    // Update is called once per frame
    void Update()
    {
        
        if (m_opened || !m_activated)
            return;

        if(Mathf.Abs(transform.rotation.eulerAngles.y - m_angle) < 45f)
            transform.RotateAround(WallPoint.transform.position, Vector3.forward, -30f * Time.deltaTime);

        AssignedDoor.transform.Translate(0, -1f * Time.deltaTime, 0);
        if ((m_initial - AssignedDoor.transform.position.y) > 100f)
            m_opened = true;
    }

    private bool m_opened = false;
    private bool m_activated = false;
    private float m_initial, m_angle;
}
