using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private Rounds round;

    private GameObject newEnemy;
    private float spawnRate;
    private int minSpawnCount;
    private int spawnCount;
    private float xDir;
    private float yDir;


    

    // Start is called before the first frame update
    void Start()
    {
        round = gameObject.GetComponent<Rounds>();
        minSpawnCount = 8;

        SetSpawnRate(1f);
    }

    private void SetSpawnRate(float timeInSeconds)
    {
        spawnRate = timeInSeconds;
    }

    public void SpawnWave(float waitTimeUntilSpawn)
    {
        spawnCount = 0;
        InvokeRepeating("SpawnEnemy", waitTimeUntilSpawn, spawnRate);
    }

    private void SpawnEnemy()
    {
        newEnemy = Instantiate(enemyPrefab) as GameObject;   // Creates copy of enemy
        SetEnemySpawnPosition();
        SetActive(true);
        spawnCount++;
        IsWaveOver();
    }

    private void SetEnemySpawnPosition()
    {

        xDir = Random.Range(-15f, 15f);
        // If x position is too close to player, make y further (random)
        if (Mathf.Abs(xDir) < 7f)
        {
            yDir = Random.Range(7f, 15f) * ((Random.Range(0, 2) * 2) - 1);
        }
        // if x position far from player, make y position closer (random)
        else
        {
            yDir = Random.Range(-15f, 15f);
        }
        // places enemy at calculated positions
        newEnemy.transform.position = new Vector2(player.position.x + xDir, player.position.y + yDir);    // moves copy to specific position
    }

    private void SetActive(bool isActive)
    {
        newEnemy.SetActive(isActive);
    }

    private void IsWaveOver()
    {
        // If the amount of enemies = the amount for the round, stop spawning
        if (minSpawnCount + (3 * round.GetCurrentRound()) == spawnCount)
        {
            CancelInvoke(); // Ends loop of spawning
        }
    }
}
