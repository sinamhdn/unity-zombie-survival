using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    // [SerializeField] Camera fpCamera;
    [SerializeField] float zoomInFOV = 20f;
    [SerializeField] float zoomOutFOV = 40f;
    [SerializeField] float zoomInSense = 0.5f;
    [SerializeField] float zoomOutSense = 1f;
    CinemachineVirtualCamera fpCamera;
    FirstPersonController fisrtPersonController;
    bool zoomInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Start()
    {
        //fpCamera = transform.parent.parent.parent.GetChild(1).gameObject.GetComponent<CinemachineVirtualCamera>();
        fpCamera = GameObject.FindGameObjectWithTag("CMVC").GetComponent<CinemachineVirtualCamera>();
        fisrtPersonController = FindObjectOfType<Player>().GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!fpCamera) return;
            if (!fisrtPersonController) return;
            // change the field of view on cinemachine camera
            if (!zoomInToggle)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        zoomInToggle = true;
        fpCamera.m_Lens.FieldOfView = zoomInFOV;
        fisrtPersonController.RotationSpeed = zoomInSense;
    }
    private void ZoomOut()
    {
        zoomInToggle = false;
        fpCamera.m_Lens.FieldOfView = zoomOutFOV;
        fisrtPersonController.RotationSpeed = zoomOutSense;
        // fpCamera.fieldOfView = zoomOutFOV;
    }
}
