using UnityEngine;
[RequireComponent(typeof(SoundList))]
public class Unit : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float HitPoints;
    [SerializeField] private AttackType Attack; // Для чего сделал разделение. 1) Возможность сделать несколько оружий у ГГ, дробовик/граната. 
    //2) Вариативность противников: рукопашный-летающий, рукопашный-наземный. При этом не надо повторяться с кодом, просто навесить одну и ту же атаку
    // Ещё бы сюда навесить "Управляющий класс" т.е. Перс-контроллер или АИ-контроллер
    private SoundList Audio;
    
    private void Awake()
    {
        Audio = GetComponent<SoundList>();
        gameObject.TryGetComponent<AttackType>(out Attack);
    }


    private void Death()
    {
        Audio.Death();
        Destroy(gameObject);
    }
    public void ApplyDMG(AttackType What)
    {
        HitPoints -= What.Damage;
        if (HitPoints <= 0) Death();
        else if (What.Damage > 0) Audio.TakeDamage();
    }
    private void GiveDMG(Unit Target)
    {
        if (Target == null) return;
        Target.ApplyDMG(Attack);
    }
    
    private void GiveDMG()
    {
        return;
    }

    // Приказы, по-хорошему, отсюда управление мувментами ещё, но да
    public void Command_Attack()
    {
        Audio.Attack();
        Unit target = Attack.ReturnTarget();
        if (target == null) return;
        GiveDMG(target);
    }
}
