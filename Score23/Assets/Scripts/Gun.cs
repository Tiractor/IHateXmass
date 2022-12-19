using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class Gun : AttackType
{
    [SerializeField] private float reloadTime, coolDown; // RLD and CD of the gun
    private float _cdTimer, _reloadingTimer;
    private AudioSource _source;
    [SerializeField] private AudioClip Audio_Reload;
    [SerializeField] private AudioClip Audio_Shoot;
    [SerializeField] private int maxAmmoCount;
    private int _currentAmmoCount;
    
    private Camera _fpsCamera;

    [SerializeField] private Animator animator;
    private static readonly int Reloading1 = Animator.StringToHash("Reloading");

    private void Start()
    {
        _source = GetComponent<AudioSource>();
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
        _source.clip = Audio_Reload;
        _source.Play();
        animator.SetTrigger(Reloading1);
        _currentAmmoCount = maxAmmoCount;
        _reloadingTimer = reloadTime;
    }

    public override Unit ReturnTarget()
    {
        Unit Target = null;
        if (IsReady() && !IsReloading())
        {
            _source.clip = Audio_Shoot;
            _source.Play();
            animator.Play("Shoot");
            _cdTimer = coolDown;
            _currentAmmoCount--;
            if (Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out var hit, Range))
                Target = hit.transform.GetComponent<Unit>();
        }
        
        if (_currentAmmoCount <= 0)
        {
            Reloading();
        }
        return Target;
    }

    public void DoubleAttack()
    {
        Damage *= 2;
        StartCoroutine(EndBuff());
    }
    private IEnumerator EndBuff()
    {
        yield return new WaitForSeconds(10);
        Damage /= 2;
    }

}