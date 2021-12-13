using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    [SerializeField] private AudioClip Explosion;

	private void Start()
	{
        m_source = GetComponent<AudioSource>();
        Debug.Assert(null != m_source, "Fireball: No AudioSource component!");
	}

	// Update is called once per frame
	void Update()
    {
        if (!m_exploding)
            transform.Translate(0, 0, Speed * Time.deltaTime);
    }

	private void OnTriggerEnter(Collider other)
	{
        if(!m_exploding)
            StartCoroutine(BlowFireball());
	}

    private IEnumerator BlowFireball()
	{
        m_exploding = true;
        GetComponent<Renderer>().enabled = false;
        m_source?.PlayOneShot(Explosion);
        yield return new WaitForSeconds(5);

        Destroy(this.gameObject);
    }

    private AudioSource m_source;
    private bool m_exploding = false;
}
