using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SoundList))]
public class Unit : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float HitPoints;
    [SerializeField] private AttackType Attack; // Для чего сделал разделение. 1) Возможность сделать несколько оружий у ГГ, дробовик/граната. 
    //2) Вариативность противников: рукопашный-летающий, рукопашный-наземный. При этом не надо повторяться с кодом, просто навесить одну и ту же атаку
    // Ещё бы сюда навесить "Управляющий класс" т.е. Перс-контроллер или АИ-контроллер
    [SerializeField] private SoundList Audio;
    
    private void Awake()
    {
        Audio = GetComponent<SoundList>();
    }


    private void Death()
    {
        Audio.Death();
    }
    public void ApplyDMG(AttackType What)
    {
        HitPoints -= What.Damage;
        if (HitPoints <= 0) Death();
        else Audio.TakeDamage();
    }
    private void GiveDMG(Unit Target)
    {
        Target.ApplyDMG(Attack);
    }

    // Приказы, по-хорошему, отсюда управление мувментами ещё, но да
    public void Command_Attack()
    {
        Audio.Attack();
        GiveDMG(Attack.Attack());
    }
}
