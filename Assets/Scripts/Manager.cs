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
    public int EnemyPerWave = 10;
    public int BossWaveApparition = 3;
    public int WaveCounter = 0;
    public float TimeBetweenWave = 5;

    private float CurrentSpawnTimer;
    private float CurrentWaveTimer;
    private int EnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSpawnTimer = timeBetweenSpawn;
        CurrentWaveTimer = 0;
        EnemyCount = 0;
        WaveCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentWaveTimer += Time.deltaTime;

        if (EnemyCount >= EnemyPerWave && CurrentWaveTimer < TimeBetweenWave)
        {
            CurrentWaveTimer = 0;
            return;
        }

        CurrentSpawnTimer += Time.deltaTime;
        if (CurrentSpawnTimer >= timeBetweenSpawn)
        {
            CurrentEnemy = Instantiate(Enemy, Enter.position, Quaternion.identity);
            CurrentEnemy.GetComponent<enemy_navmesh>().Move(Exit);
            CurrentSpawnTimer = 0;
            EnemyCount++;
        }

    }
}
