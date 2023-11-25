using UnityEngine;

public class Battery : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // GetComponentInChildren looks through all children to find the component we need
            other.transform.parent.GetComponentInChildren<FlashLight>().ResetLightAngle(restoreAngle);
            other.transform.parent.GetComponentInChildren<FlashLight>().AddLightIntensity(addIntensity);
        }
    }
}
