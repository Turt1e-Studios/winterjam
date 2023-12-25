using System.Collections.Generic;
using UnityEngine;

public class DropPresent : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnObjects;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPresent();
        }
    }

    void SpawnPresent()
    {
        // Spawn at location of sleigh
        Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], GameObject.Find("Sleigh").transform.position, transform.rotation);
    }
}
