using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
[RequireComponent(typeof(Unit)), RequireComponent(typeof(Jump_Mod), typeof(FirstPersonMovement_Mod), typeof(Crouch_Mod)) ]
public class MainPlayerController : MonoBehaviour
{
    private Unit ControlledChar;
    public KeyCode AttackKey = KeyCode.Mouse0;
    struct Motion
    {
        public Jump_Mod UpMove;
        public Crouch_Mod DownMove;
        public FirstPersonMovement_Mod HorizontalMove;
    }
    private Motion Controll;

    private void Awake()
    {
        ControlledChar = GetComponent<Unit>();
        Controll.UpMove = GetComponent<Jump_Mod>();
        Controll.DownMove = GetComponent<Crouch_Mod>();
        Controll.HorizontalMove = GetComponent<FirstPersonMovement_Mod>();
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) Controll.HorizontalMove.Moving();
        if (Input.GetButtonDown("Jump")) Controll.UpMove.Jumping();
        if (Input.GetKey(Controll.DownMove.key)) Controll.HorizontalMove.Moving(); // Там слишком много кода на прожатии, 
        //если упущу важную деталь может перестать работать, поэтому надо модифицировать
        if (Input.GetKey(AttackKey)) ControlledChar.Command_Attack();
    }
}
