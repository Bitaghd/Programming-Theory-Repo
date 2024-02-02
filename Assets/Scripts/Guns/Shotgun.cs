using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun // INHERITANCE
{
    [SerializeField] int spread;
    public override void Shoot() // POLYMORPHISM
    {
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        canShoot = false;
        GameObject[] bullets = new GameObject[spread];
        for (int i= 0; i < spread; i++)
        {
            bullets[i] = Instantiate(bulletPrefab, bullethole.position, bullethole.rotation);
        }
        foreach (GameObject bullet in bullets) 
        {
            bullet.GetComponent<Rigidbody>().velocity = bullethole.forward * speed;
        }
        yield return new WaitForSeconds(rapidity);
        canShoot = true;
    }
}
