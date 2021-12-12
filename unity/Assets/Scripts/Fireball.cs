using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);        
    }

	private void OnTriggerEnter(Collider other)
	{
        Destroy(this.gameObject);
	}
}
