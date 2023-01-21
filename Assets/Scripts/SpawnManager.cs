using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private float spawnRangeX = 20;
    private float spawnPosZ = 20;



    private float spawnRangeZ = 20;
    private float spawnPosX = 25;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        //InvokeRepeating("SpawnRandomAnimalFromSide", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       // SpawnRandomAnimal();
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 randomSpawn = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], randomSpawn, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalFromSide()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        float direction = Random.Range(0, 2);
        if (direction == 0)
        {
            // spawn stuff from the left
            Vector3 randomSpawn = new Vector3(-spawnPosX, 0, Random.Range(0, spawnRangeZ));
            Instantiate(animalPrefabs[animalIndex], randomSpawn, animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(0, 270, 0));
        } else
        {
            // spawn stuff from the right
            Vector3 randomSpawn = new Vector3(spawnPosX, 0, Random.Range(0, spawnRangeZ));
            Instantiate(animalPrefabs[animalIndex], randomSpawn, animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(0, 90, 0));
        }

    }
}
