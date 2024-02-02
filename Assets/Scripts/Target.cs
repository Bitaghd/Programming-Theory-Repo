using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
            gameManager.UpdateScore();

    }
}
