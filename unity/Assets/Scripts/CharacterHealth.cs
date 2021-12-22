using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int Health { get; private set; } = 100;

    public bool IsDead { get => Health == 0; }

    public void Damage(int amount)
	{
        if (IsDead)
            return;

        Health = (Health > amount) ? Health - amount : 0;
	}
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
