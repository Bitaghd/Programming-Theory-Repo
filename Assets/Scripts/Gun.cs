using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //public GameObject gunPrefab;
    public Transform bullethole;
    [SerializeField] protected GameObject bulletPrefab;
    public float rapidity;
    protected bool canShoot = true;
    protected float speed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && canShoot) 
        {
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        StartCoroutine(FireRate());
        
    }

    IEnumerator FireRate()
    {
        canShoot = false;
        var bullet = Instantiate(bulletPrefab, bullethole.position, bullethole.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullethole.forward * speed;
        yield return new WaitForSeconds(rapidity);
        canShoot = true;
    }
}
