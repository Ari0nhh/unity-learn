using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Activate")) {

            var ray = new Ray(transform.position, transform.forward);
            var hits = Physics.SphereCastAll(ray, 2f, 1f);
            foreach (var hit in hits) {
                var go = hit.collider.gameObject;
                if (!go.CompareTag("Interactive"))
                    continue;

                var comps = go.GetComponents<Explorer.IInteractive>();
                foreach (var comp in comps)
                    comp.Activate();
            }
        }
    }
}
