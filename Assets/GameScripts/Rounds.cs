using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rounds : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roundText;
    //[SerializeField] private TextMeshProUGUI titleRoundText;

    private EnemySpawnScript enemySpawnScript;
    private int roundCount;
    private float roundTimer;

    private void Start()
    {
        enemySpawnScript = gameObject.GetComponent<EnemySpawnScript>();
        SetRound(0);
        SetRoundTimer(30);
        InvokeRepeating("IncrementRound", 0f, roundTimer);
    }

    private void SetRound(int count)
    {
        roundCount = count;
    }

    public int GetCurrentRound()
    {
        return roundCount;
    }

    private void SetRoundTimer(float timeInSeconds = 60)
    {
        roundTimer = timeInSeconds;
    }

    private void IncrementRound()
    {
        roundCount++;
        print("CurrentRound: " + roundCount);
        ChangeRoundDisplay();
        StartRound();
    }

    private void ChangeRoundDisplay()
    {
        //titleRoundText.text = "Round : " + roundCount;
        
        roundText.text = "Round " + roundCount;
    }

    private void StartRound()
    {
        float waitToSpawn = 5f;
        print("Starting new round soon");
        enemySpawnScript.SpawnWave(waitToSpawn);
    }
}
