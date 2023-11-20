using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeaponIndex = 0;

    private void Start()
    {
        SetActiveWeapon();
    }

    private void Update()
    {
        int prevWeaponIndex = currentWeaponIndex;
        ProcessMouseScroll();
        ProcessKeyInput();
        if (prevWeaponIndex != currentWeaponIndex)
        {
            SetActiveWeapon();
        }
    }

    private void SetActiveWeapon()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    private void ProcessMouseScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //if (currentWeaponIndex >= transform.childCount - 1)
            //{
            //    currentWeaponIndex = 0;
            //}
            //else
            //{
            //    currentWeaponIndex++;
            //}
            currentWeaponIndex = (currentWeaponIndex + 1) % transform.childCount;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentWeaponIndex = currentWeaponIndex - 1;
            if (currentWeaponIndex < 0) currentWeaponIndex = transform.childCount - 1;
        }
    }

    private void ProcessKeyInput()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeaponIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeaponIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeaponIndex = 2;
        }
    }
}
