using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hp = 100f;
    bool isDead = false;

    public bool GetIsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        // Broadcast method is better
        // GetComponent<Enemy>().damageTaken();
        BroadcastMessage("damageTaken");
        hp -= damage;
        if (hp <= 0) Die(); // Destroy(gameObject);
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        Destroy(gameObject, 5f);
    }
}
