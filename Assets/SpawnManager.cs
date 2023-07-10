using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabToSpawn;  
    public int numberOfPrefabs = 5;

    

    private void Start()
    {
        StartCoroutine(SpawnOleada());
    }

    private void Update()
    {
    }

    private void Spawn()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
        
    }

    IEnumerator SpawnOleada()
    {
        
        Spawn();
        yield return new WaitForSeconds(1f);
        StartCoroutine(Wait());

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnOleada());

    }

    
}




