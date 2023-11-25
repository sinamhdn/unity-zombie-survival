using System.Collections;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // if you use serialize field and pass the gameobject that has camera component
    // and variable type is Camera unity will automatically pass camera component to the script
    // [SerializeField] Camera fpCamera;
    // [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] float shotInterval = 0.5f;
    TextMeshProUGUI ammoText;
    Camera fpCamera;
    ParticleSystem muzzleFlash;
    Ammo ammoSlot;
    bool canShoot = true;

    private void OnEnable()
    {
        StartCoroutine(EnableShoot());
    }

    private void Start()
    {
        fpCamera = transform.parent.parent.GetComponent<Camera>();
        muzzleFlash = transform.GetChild(0).GetComponent<ParticleSystem>();
        ammoSlot = GameObject.FindGameObjectWithTag("Player").GetComponent<Ammo>();
        ammoText = GameObject.FindGameObjectWithTag("AmmoText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        DisplayAmmo();
        // if (Input.GetButtonDown("Fire1") && canShoot)
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            DoRaycast();
            ammoSlot.ReduceAmmo(ammoType);
        }
        yield return new WaitForSeconds(shotInterval);
        canShoot = true;
    }

    // to solve instant shot on weapon switch bug
    private IEnumerator EnableShoot()
    {
        yield return new WaitForSeconds(shotInterval);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void DoRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpCamera.transform.position, fpCamera.transform.forward, out hit, range))
        {
            SpawnHitEffect(hit);
            // Debug.Log("Target attacked " + hit.transform.name);
            EnemyHealth target = hit.transform.GetComponentInParent<EnemyHealth>();
            if (!target) return;
            target.TakeDamage(damage);
        }
        return;
    }

    private void SpawnHitEffect(RaycastHit hit)
    {
        // if you dont get retrned value of the Instantiate it will try to destroy the prefab
        // turn on play on awake because we dont use Play() fonctionfor this
        ParticleSystem spawnedHitEffect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        // Destroy(spawnedHitEffect, 1f);
    }
    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }
}
