using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour, Explorer.IInteractive
{
    public void Activate()
    {
        Destroy(this.gameObject);
    }
}
