using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int score = 0;
    [SerializeField] private int waveNumber = 0;
    [SerializeField, Range(5, 10)] private float spawnRange = 9;

    [Header("Enemy Objects")]
    [SerializeField] private int enemyCount = 0;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject BossSpawnPoint;

    [Header("Powerup Objects")]
    [SerializeField] private GameObject powerupPrefab;

    [Header("UI Component")]
    [SerializeField] private Text ScoreText;

    public GameObject SpawnedBoss = null;
    private bool bossHasBeenSpawned = false;

    void Start()
{
    // If ScoreText is not assigned in the Inspector, try to get it from the GameObject
    if (ScoreText == null)
    {
        ScoreText = GetComponentInChildren<Text>();
    }

    score = 0;
    waveNumber = 1; // Set the initial waveNumber to 1
    UpdateUIScore();
}


    void Update()
    {
        if (enemyCount == 0)
        {
            waveNumber++;
            UpdateWaveText(); // Ensure that UpdateWaveText is called when the wave increases
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPoint(), powerupPrefab.transform.rotation);
        }

        if (!bossHasBeenSpawned && waveNumber == 10)
        {
            bossHasBeenSpawned = true;
            SpawnedBoss = Instantiate(boss, BossSpawnPoint.transform.position, BossSpawnPoint.transform.rotation);
        }
    }

    public void UpdateUIScore()
    {
        ScoreText.text = "Score: " + score;
    }

    void UpdateWaveText()
    {
        ScoreText.text = "Wave: " + waveNumber;
    }

    public Vector3 GenerateSpawnPoint()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private void SpawnEnemyWave(int _enemiesToSpawn)
    {
        for (int i = 0; i < _enemiesToSpawn; i++)
        {
            Instantiate(ChooseRandomEnemy(), GenerateSpawnPoint(), Quaternion.identity);
            enemyCount++;
        }
    }

    private GameObject ChooseRandomEnemy()
    {
       return enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];

    }

    public void EnemyDied()
    {
        enemyCount--;
        score++;
        UpdateUIScore();
    }
}
