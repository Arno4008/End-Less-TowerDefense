using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Boss;
    public int current_hp;
    public int base_hp;
    public int levels;
    public int xp;
    public int xp_need;
    public int money;
    public Transform Enter;
    public Transform Exit;
    public float timeBetweenSpawn = 2.0f;
    public GameObject CurrentEnemy;
    public int EnemyPerWave = 5;
    public int BossWaveApparition = 5;
    public int WaveCounter;
    public float TimeBetweenWave = 5;

    private float CurrentSpawnTimer;
    private float CurrentWaveTimer;
    private int EnemyCount;
    public void Start()
    {
        current_hp = base_hp;
        CurrentSpawnTimer = timeBetweenSpawn;
        CurrentWaveTimer = 0;
        EnemyCount = 0;
    }
    void Update()
    {
        GetComponent<UIManager>().Uimanager(money, levels, current_hp, WaveCounter, (TimeBetweenWave - CurrentWaveTimer));
        if (current_hp <= 0)
        {
            SceneManager.LoadScene("EndMenu");
            return;
        }
        if (CurrentWaveTimer < TimeBetweenWave)
        {
            CurrentWaveTimer += Time.deltaTime;
        }
        if (EnemyCount >= EnemyPerWave && CurrentWaveTimer < TimeBetweenWave)
        {
            WaveCounter++;
            CurrentWaveTimer = 0;
            if (WaveCounter % BossWaveApparition == 0)
            {
                    GameObject boss = Instantiate(Boss, Enter.position, Quaternion.identity);
            }
            EnemyCount = 0;
            return;
        }
        CurrentSpawnTimer += Time.deltaTime;
        if (CurrentSpawnTimer >= timeBetweenSpawn)
        {
            CurrentEnemy = Instantiate(Enemy, Enter.position, Quaternion.identity);
            CurrentSpawnTimer = 0;
            EnemyCount++;
        }
        if (xp >= xp_need)
        {
            levels++;
            xp = 0;
            xp_need += 50;
        }
    }
}
