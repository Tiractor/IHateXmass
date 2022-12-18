using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : AttackType
{
    public override Unit ReturnTarget()
    {
        Unit Target = null;
        return Target;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Unit>().ApplyDMG(this);    
            Destroy(gameObject);
        }
    }

    
}
