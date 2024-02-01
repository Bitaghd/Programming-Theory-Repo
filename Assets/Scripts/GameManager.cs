using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // ENCAPSULATION
    public string gunType;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
