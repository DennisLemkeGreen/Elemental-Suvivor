using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public float spawnTime = 1f;
    private float spawnTimer =0f;
    public int maxEnemies = 150;
    private int currentEnemies = 0;
    private float roudTimer = 60.0f;
    private float roudTime = 0.0f;
    int enemyIndex;
    void Start (){
        enemyIndex = Random.Range(0, enemies.Length);
    }
    void Update()
    {
        roudTime += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnTime)
        {
            
            if(roudTime >= roudTimer)
            {
                roudTime = 0.0f;
                enemyIndex = Random.Range(0, enemies.Length);
            }
            SpawnEnemy(enemyIndex);
            spawnTimer = 0f;
        }
        
    }

    public void DecreaseCount()
    {
        currentEnemies--;
    }

    void SpawnEnemy(int enemyIndex)
    {
        if(currentEnemies < maxEnemies)
        {
            
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemies[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation );
            currentEnemies++;
        
            
        }
    }
}
