using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SoundList))]
public class Gun : AttackType
{
    [SerializeField] private float reloadTime, coolDown; // RLD and CD of the gun
    private float _cdTimer, _reloadingTimer;
    private SoundList _source;
    [SerializeField] private int maxAmmoCount;
    [SerializeField] private float SpreadRadius=1;
    [SerializeField] private int CountOfRays = 1;
    private int _currentAmmoCount;
    
    private Camera _fpsCamera;

    [SerializeField] private Animator animator;
    private static readonly int Reloading1 = Animator.StringToHash("Reloading");

    private void Start()
    {
        _source = GetComponent<SoundList>();
        _currentAmmoCount = maxAmmoCount;
        _fpsCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }


    private bool IsReady()
    {
        return _cdTimer <= 0;
    }

    private bool IsReloading()
    {
        return _reloadingTimer > 0;
    }

    private void FixedUpdate()
    {
        _cdTimer -= Time.fixedDeltaTime;
        _reloadingTimer -= Time.fixedDeltaTime;
    }

    private void Reloading()
    {
        _source.Play("Reload");
        animator.SetTrigger(Reloading1);
        _currentAmmoCount = maxAmmoCount;
        _reloadingTimer = reloadTime;
    }
    public override Unit ReturnTarget()
    {
        return null;
    }
    private Vector3 Spread()
    {
        Vector3 Result = _fpsCamera.transform.forward;
        Vector2 Temp = Random.insideUnitCircle * SpreadRadius;
        Result.x += Temp.x;
        Result.y += Temp.y;
        return Result;
    }
    public override Unit[] ReturnTargets()
    {
        Unit[] Targets = new Unit[CountOfRays];
        if (IsReady() && !IsReloading())
        {
            int CountOfDamages = 0;
            _source.Play("Shoot");
            animator.Play("Shoot");
            _cdTimer = coolDown;
            _currentAmmoCount--;
            for (int i = 0; i < CountOfRays; ++i)
            {
                if (Physics.Raycast(_fpsCamera.transform.position, Spread(), out var hit, Range))
                    Targets[CountOfDamages] = hit.transform.GetComponent<Unit>();
            }
        }
        
        if (_currentAmmoCount <= 0)
        {
            Reloading();
        }
        return Targets;
    }

    public void DoubleAttack(int count)
    {
        Damage *= count;
        StartCoroutine(EndBuff());
    }
    private IEnumerator EndBuff()
    {
        yield return new WaitForSeconds(10);
        Damage /= 2;
    }

}