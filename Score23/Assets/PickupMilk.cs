using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMilk : AttackType
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
            Unit temp = other.GetComponent<Unit>();
            if (temp.ReturnHP() > 85) Damage = temp.ReturnHP() - 100;
            temp.ApplyDMG(this);
            Destroy(gameObject);
        }
    }

    
}
