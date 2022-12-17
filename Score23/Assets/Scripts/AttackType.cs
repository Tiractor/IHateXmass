using UnityEngine;

abstract public class AttackType : MonoBehaviour
{
    [Range(0, 100)] public float Damage; // Урон наносимый данным оружием
    abstract public Unit Attack(); 
}