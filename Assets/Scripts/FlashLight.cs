using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;
    Light light;

    // Start is called before the first frame update
    private void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    private void Update()
    {
        ReduceLightAngle();
        ReduceLightIntensity();
    }

    private void ReduceLightAngle()
    {
        if (light.spotAngle <= minAngle) return;
        light.spotAngle -= angleDecay * Time.deltaTime;
    }
    private void ReduceLightIntensity()
    {
        light.intensity -= lightDecay * Time.deltaTime;
    }

    public void ResetLightAngle(float angle)
    {
        light.spotAngle = angle;
    }

    public void AddLightIntensity(float intensity)
    {
        light.intensity += intensity;
    }
}
