using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballTrap : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private int Damage = 20;
    [SerializeField] private GameObject Scull;
    [SerializeField] private GameObject Caster;
    [SerializeField] private float FireRate = 2f;
    [SerializeField] private GameObject Fireball;

	private void OnTriggerStay(Collider other)
	{
        if (!other.gameObject.CompareTag("Player"))
            return;

        Scull.transform.LookAt(other.transform.position, Vector3.up);
        

        if(m_fire < 0.0001) {
            var fireball = Instantiate(Fireball);

            fireball.transform.position = Caster.transform.position;
            fireball.transform.LookAt(other.transform);

            fireball.GetComponent<Fireball>().Damage = Damage;

            m_fire = FireRate;
            return;
        }

        m_fire -= Time.deltaTime;
    }

	private void OnTriggerExit(Collider other)
	{
        if (!other.gameObject.CompareTag("Player"))
            return;

        m_fire = 0f;
	}


	void Start()
    {
        Debug.Assert(null != Scull, "Scull is not assigned");
        Debug.Assert(null != Caster, "Caster is not assigned");
    }

    private float m_fire = 0f;
}
