using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using Random = UnityEngine.Random;

public class DropPresent : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnObjects;
    private Score _presents;

    private void Start()
    {
        _presents = GameObject.Find("PresentsScore").GetComponent<Score>();
        print(_presents);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _presents.GetScore() > 0)
        {
            SpawnPresent();
        }
    }

    void SpawnPresent()
    {
        // Spawn at location of sleigh
        Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], GameObject.Find("Sleigh").transform.position, transform.rotation);
        _presents.ChangeScore(-1);
    }
}
