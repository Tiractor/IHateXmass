using UnityEngine; 
[RequireComponent(typeof(Unit)), RequireComponent(typeof(Jump_Mod), typeof(FirstPersonMovement_Mod), typeof(TakeDamageCanvas)) ]
public class MainPlayerController : MonoBehaviour
{
    [SerializeField] private Unit ControlledChar;
    public KeyCode AttackKey = KeyCode.Mouse0;
    [System.Serializable]
    struct Motion
    {
        public Jump_Mod UpMove;
        public FirstPersonMovement_Mod HorizontalMove;
    }
    [SerializeField] private Motion Controll;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ControlledChar = GetComponent<Unit>();
        Controll.UpMove = GetComponent<Jump_Mod>();
        Controll.HorizontalMove = GetComponent<FirstPersonMovement_Mod>();
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) Controll.HorizontalMove.Moving();
        if (Input.GetButtonDown("Jump")) Controll.UpMove.Jumping();
        if (Input.GetKey(AttackKey))ControlledChar.Command_Attack();
    }
}
