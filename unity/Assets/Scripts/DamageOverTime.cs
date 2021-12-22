using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private int DamageAmount = 20;
	[SerializeField] private float Period = 5f;

	private void OnTriggerStay(Collider other)
	{
		var health = other.gameObject.GetComponent<CharacterHealth>();
		if (null == health)
			return;

		if(m_elapsed < 0.001) {
			health.Damage(DamageAmount);
			m_elapsed = Period;
			return;
		}

		m_elapsed -= Time.deltaTime;
	}

	private void OnTriggerExit(Collider _)
	{
		m_elapsed = 0f;
	}

	private float m_elapsed = 0f;
}
