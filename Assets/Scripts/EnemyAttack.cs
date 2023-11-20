using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //[SerializeField] Transform target;
    [SerializeField] float damage = 40f;
    // PlayerHealth playerHealth;
    Player target;

    // Start is called before the first frame update
    void Start()
    {
        // playerHealth = GetComponent<PlayerHealth>();
        target = FindObjectOfType<Player>();
    }

    public void AttackAnimEvent()
    {
        if (!target) return;
        // both are correct
        // playerHealth.TakeDamage(damage);
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}
