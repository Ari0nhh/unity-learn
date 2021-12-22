using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] Waypoints;
    
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        Debug.Assert(null != m_agent, "NavMeshAgent component is missing");

        if (Waypoints.Length > 0)
            m_agent.SetDestination(Waypoints[0].position);
    }

    void Update()
    {
        if (Waypoints.Length == 0)
            return;

        if (m_agent.remainingDistance < m_agent.stoppingDistance) {
            m_idx = (m_idx + 1) % Waypoints.Length;
            m_agent.SetDestination(Waypoints[m_idx].position);
        }
    }

    private NavMeshAgent m_agent;
    private int m_idx;
}
