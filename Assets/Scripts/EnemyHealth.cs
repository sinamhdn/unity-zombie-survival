using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hp = 100f;

    public void TakeDamage(float damage)
    {
        // Broadcast method is better
        // GetComponent<Enemy>().damageTaken();
        BroadcastMessage("damageTaken");
        hp -= damage;
        if (hp <= 0) Destroy(gameObject);
    }
}
