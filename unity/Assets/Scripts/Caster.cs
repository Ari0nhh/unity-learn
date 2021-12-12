using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public GameObject FireballPrefab;

    // Update is called once per frame
    void Update()
    {
        Debug.Assert(null != FireballPrefab, "Fireball prefab is not assigned!");
        if (Input.GetMouseButtonDown(0)) {
            var fireball = Instantiate(FireballPrefab);
            fireball.transform.position = transform.position;
            fireball.transform.rotation = transform.rotation;
		}
    }
}
