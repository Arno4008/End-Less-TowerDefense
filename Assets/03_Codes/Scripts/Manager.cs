using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Boss;
    public int current_hp;
    public int base_hp;
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
    void Start() 
    {
        current_hp = base_hp;
        CurrentSpawnTimer = timeBetweenSpawn;
        CurrentWaveTimer = 0;
        EnemyCount = 0;
        WaveCounter = 0;
    }
    void Update()
    {
        if (current_hp <= 0)
        {
            Debug.Log("Fin du jeu.");
            return;
        }
        CurrentWaveTimer += Time.deltaTime;
        if (EnemyCount >= EnemyPerWave && CurrentWaveTimer < TimeBetweenWave)
        {
            WaveCounter++;
            CurrentWaveTimer = 0;
            if (WaveCounter % BossWaveApparition == 0)
            {
                Debug.Log("Boss !");
                GameObject boss = Instantiate(Boss, Enter.position, Quaternion.identity);
                boss.GetComponent<enemy_navmesh>().Move(Exit);
            }
            EnemyCount = 0;
            Debug.Log("End. Wave: " + WaveCounter);
            Debug.Log("HP: " + Var.Instance.hp);
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
 /*       if (Var.Instance.xp >= Var.Instance.xp_need)
        {
            Var.Instance.level++;
            Var.Instance.xp = 0;
            Var.Instance.xp_need += 50;
        }*/
    }
    public void SpawnTower(GameObject Tower, Transform transform)
    {
        
    }
}
