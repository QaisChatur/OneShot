using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private bool canShoot = true;

    void Update()
    {
        if (Keyboard.current.jKey.wasPressedThisFrame && canShoot)
        {
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            canShoot = false; // Disable shooting until an enemy is killed
        }
    }

    public void AllowShooting()
    {
        canShoot = true; // Allow shooting again
    }
}
