using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    [SerializeField] private float RotationSpeed = 1;
    
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, RotationSpeed * Time.deltaTime);     
    }
}
