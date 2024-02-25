using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Add an ammo count
    public int ammoCount = 1; // Set this to your desired initial ammo count

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammoCount > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Decrease the ammo count each time you shoot
        ammoCount--;
    }

    public void addAmmo()
    {
        ammoCount++;
    }
}
