using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float life = 1.5f;

    private void Awake()
    {
        Destroy(gameObject, life);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(gameObject);
    //}
}
