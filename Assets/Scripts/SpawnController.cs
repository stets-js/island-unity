using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerUp;
    private float range = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public bool isPowerUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();
        }
        
    }

    public void SpawnEnemyWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int idx = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[idx], SpawmPosition(), enemyPrefab[idx].transform.rotation);
            
           
             
        }
    }
    void SpawnPowerUp()
    {
        Instantiate(powerUp, SpawmPosition(), powerUp.transform.rotation);
        isPowerUsed = false;
    }

    public Vector3 SpawmPosition()
    {
        float randomPosX = Random.Range(-range, range);
        float randomPosZ = Random.Range(-range, range);
        Vector3 spawnPos = new Vector3(randomPosX, 0, randomPosZ);
        return spawnPos;
    }

}
