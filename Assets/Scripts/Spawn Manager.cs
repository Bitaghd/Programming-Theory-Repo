using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] gunPrefabs;

    public GameObject SpawnGun(string type, Transform spawn)
    {
        foreach (var gun in gunPrefabs)
        {
            if(gun.name == type)
            {
                return Instantiate(gun, spawn);

            }
        }
        return null;
    }
}
