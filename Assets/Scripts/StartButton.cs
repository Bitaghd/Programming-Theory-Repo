using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private bool isClicked;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetKeyDown(KeyCode.E) && !isClicked)
        {
            isClicked = true;
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                StartCoroutine(gameManager.StartGame());
                Debug.Log("Button is pressed!");
            }
        }

        if (!gameManager.isStarted && isClicked)
            isClicked = false;
    }
}
