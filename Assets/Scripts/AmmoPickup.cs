using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;
    Ammo ammo;

    private void Start()
    {
        ammo = FindObjectOfType<Ammo>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ammo.IncreaseAmmo(ammoType, ammoAmount);
            Destroy(gameObject);
        }
    }
}
