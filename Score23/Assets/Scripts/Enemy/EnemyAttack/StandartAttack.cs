using UnityEngine;

public class StandartAttack : AttackType
{
    public override Unit ReturnTarget()
    {
        return GameObject.FindWithTag("Player").GetComponent<Unit>();
    }
}
