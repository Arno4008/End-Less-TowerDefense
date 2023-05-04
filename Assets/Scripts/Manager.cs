using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Boss;
    public Transform Enter;
    public Transform Exit;
    public float timeBetweenSpawn = 2.0f;
    public GameObject CurrentEnemy;
    public int EnemyPerWave = 5;
    public int BossWaveApparition = 5;
    public int WaveCounter = 0;
    public float TimeBetweenWave = 5;

    private float CurrentSpawnTimer;
    private float CurrentWaveTimer;
    private int EnemyCount;
    private bool my_bool;
    void Start() 
    {
        CurrentSpawnTimer = timeBetweenSpawn;
        CurrentWaveTimer = 0;
        EnemyCount = 0;
        WaveCounter = 0;
    }
    void Update()
    {
        CurrentWaveTimer += Time.deltaTime;
        if (EnemyCount >= EnemyPerWave && CurrentWaveTimer < TimeBetweenWave)
        {
            WaveCounter++;
            CurrentWaveTimer = 0;
            my_bool = false;
            if (WaveCounter % BossWaveApparition == 0)
            {
                Debug.Log("Boss !");
                GameObject boss = Instantiate(Boss, Enter.position, Quaternion.identity);
                boss.GetComponent<enemy_navmesh>().Move(Exit);
            }
            EnemyCount = 0;
            Debug.Log("End. Wave:" + WaveCounter);
            return;
        }
        CurrentSpawnTimer += Time.deltaTime;
        if (CurrentSpawnTimer >= timeBetweenSpawn)
        {
            my_bool = false;
            CurrentEnemy = Instantiate(Enemy, Enter.position, Quaternion.identity);
            CurrentEnemy.GetComponent<enemy_navmesh>().Move(Exit);
            CurrentSpawnTimer = 0;
            EnemyCount++;
        }
    }
}
