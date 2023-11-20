using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hp = 100f;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            // destroy player
            Destroy(gameObject);
            // destroy weapons
            Destroy(gameObject.transform.parent.GetChild(0).GetChild(0).gameObject);
            GetComponent<PlayerDeath>().HandleDeath();
        }
    }
}
