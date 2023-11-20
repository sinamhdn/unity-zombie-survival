using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // [SerializeField] Transform target;
    [SerializeField] GameObject target;
    [SerializeField] float followRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity; // assign to a really big number
    bool hasAggro = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        InteractWithTarget();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }

    // Follows the target if in range
    private void InteractWithTarget()
    {
        if (!target) return;
        distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

        if (hasAggro)
        {
            TurnToTarget();
            if (distanceToTarget >= agent.stoppingDistance)
            {
                GetComponent<Animator>().SetBool("Attack", false);
                GetComponent<Animator>().SetTrigger("Move");
                // this will also work
                // bool agentresult = agent.SetDestination(target.position);
                bool setResult = agent.SetDestination(target.transform.position);
                // Debug.Log(setResult);
            }

            if (distanceToTarget <= agent.stoppingDistance)
            {
                GetComponent<Animator>().SetBool("Attack", true);
                // Debug.Log("Enemy Attacked");
            }
        }

        if (distanceToTarget <= followRange)
        {
            hasAggro = true;
        }
    }

    private void TurnToTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void damageTaken()
    {
        hasAggro = true;
    }
}
