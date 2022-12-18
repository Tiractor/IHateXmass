using UnityEngine;

public class StandartAttack : AttackType
{
    public override Unit ReturnTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position+new Vector3(0,0.5f,0), transform.forward, out hit, Range))
        {
            var unit = hit.transform.GetComponent<Unit>();
            return unit;
        }
        return null;
    }
}
