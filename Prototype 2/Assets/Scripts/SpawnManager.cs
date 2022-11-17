using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefab;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.25f;

    private float spawnTopRangeX = 17.5f;
    private float spawnTopPosZ = 20.0f;

    private float spawnSideRangeX = 22.5f;
    private float spawnSideTopBoundZ = 15.0f;
    private float spawnSideLowerBoundZ = 0.0f;
    private float spawnSideRotationY = 90;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn random animal from each side every interval
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        // Spawn a random animal from the top side
        int animalIndex = Random.Range(0, animalPrefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnTopRangeX, spawnTopRangeX), 0, spawnTopPosZ);
        GameObject animal = Instantiate(animalPrefab[animalIndex], spawnPos, animalPrefab[animalIndex].transform.rotation);

        // Spawn a random animal from the left side
        animalIndex = Random.Range(0, animalPrefab.Length);
        animal = Instantiate(animalPrefab[animalIndex], new Vector3(-spawnSideRangeX, 0, Random.Range(spawnSideLowerBoundZ, spawnSideTopBoundZ)), animalPrefab[animalIndex].transform.rotation);
        animal.transform.Rotate(0, -spawnSideRotationY, 0);

        // Spawn a random animal from the right side
        animalIndex = Random.Range(0, animalPrefab.Length);
        animal = Instantiate(animalPrefab[animalIndex], new Vector3(spawnSideRangeX, 0, Random.Range(spawnSideLowerBoundZ, spawnSideTopBoundZ)), animalPrefab[animalIndex].transform.rotation);
        animal.transform.Rotate(0, spawnSideRotationY, 0);
    }
}
