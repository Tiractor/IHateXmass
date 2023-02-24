using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] Guns;
    [SerializeField] private Animator[] GunsAnimators;
    [SerializeField] private Gun PlayerGunScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            string collisionGameObjectName = collision.gameObject.name;
            for (int i = 0; i < Guns.Length; i++)
            {
                // Disable all guns.
                Guns[i].SetActive(false);
                // if gun's name == collision gameobject gun name.
                if (Guns[i].name == collisionGameObjectName)
                {
                    // Enable current gun UI.
                    Guns[i].SetActive(true);
                }
                // Changing animator.
                if (GunsAnimators[i].name == collisionGameObjectName)
                {
                    PlayerGunScript.ChangeAnimator = GunsAnimators[i];
                }
            }
            Destroy(collision.gameObject);
        }           
    }
}
