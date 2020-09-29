using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    public Enemy enemy;


    Wave currnetWave; //현재 웨이브
    int currnetWaveNumber; //현재 웨이브 횟수

    int enemiesRemainingToSpawn; //남아있는 스폰할 적
    int enemiesRemainngAlive; // 아직 살아있는 적의 수
    float nextSpawnTime; // 다음번 스폰할 시간

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        if(enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currnetWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            spawnedEnemy.onDeath += OnEnemyDeath;
        }

    }

    void OnEnemyDeath()
    {
        enemiesRemainngAlive--;
        if(enemiesRemainngAlive == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        currnetWaveNumber++;
        print("Wave : " + currnetWaveNumber);
        if (currnetWaveNumber - 1 < waves.Length)
        {
            currnetWave = waves[currnetWaveNumber - 1];

            enemiesRemainingToSpawn = currnetWave.enemyCount;
            enemiesRemainngAlive = enemiesRemainingToSpawn;
        }
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
