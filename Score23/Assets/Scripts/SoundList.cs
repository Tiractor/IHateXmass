using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class SoundList : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] private AudioClip[] Audio_TakeDamage;
    [SerializeField] private AudioClip[] Audio_Attack;
    [SerializeField] private AudioClip[] Audio_Death;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }
    public void TakeDamage()
    {
        if (Audio_TakeDamage.Length == 0) return;
        _source.clip = Audio_TakeDamage[Random.Range(0, Audio_TakeDamage.Length)];
        _source.Play();
    }
    public void Attack()
    {
        if (Audio_Attack.Length == 0) return;
        _source.clip = Audio_Attack[Random.Range(0, Audio_Attack.Length)];
        _source.Play();
    }
    public void Death()
    {
        if (Audio_Death.Length == 0) return;
        _source.clip = Audio_Death[Random.Range(0, Audio_Death.Length)];
        _source.Play();
    }
}
