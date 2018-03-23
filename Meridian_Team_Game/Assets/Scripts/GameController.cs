using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject hazardBlue, hazardRed, powerUp,HealthBar;
    public Vector3 spawnValues;
    public int hazardCount, score, enemyIncrease, whenIncrease, redCount, blueCount, redCount2, blueCount2, waveCount;
    public float spawnWait, startWait, waveWait,HealthTotal;
    public Text scoreText, restartText, gameOverText;

    private bool gameOver, restart;
    private float enemyType;
    private int enemyTotal,waveUp;

    void Start() {
        waveUp = 1;
        enemyTotal = hazardCount;
        waveCount = 1;
        StartCoroutine(SpawnWaves());
        score = 0;
        UpdateScore();
        blueCount2 = blueCount;
        redCount2 = redCount;

    
    }
	
	
	void Update () {
        if(waveCount>=waveUp+whenIncrease){
            waveUp = waveCount;
            enemyTotal = enemyTotal + enemyIncrease;
            blueCount = blueCount + (enemyIncrease/2);
            redCount = redCount + (enemyIncrease/2);
            spawnWait = (spawnWait / 1.5f);
            HealthBar.transform.localScale = new Vector3(HealthTotal, 1, 1);
            
        }

		
	}
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            //gameOverText.text = "Wave:" + waveCount;
            //restartText.text = "Wave:" + waveCount;
            yield return new WaitForSeconds(waveWait);
            //gameOverText.text = "";

            for (int i = 0; i < enemyTotal; i++)
            {
                Vector3 spawnPostion = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                enemyType = 0;
                while (enemyType == 0)
                {
                    enemyType = Random.Range(-2, 2);
                }
                if (redCount2 != 0 && blueCount2 != 0)
                {
                    
                    if (enemyType > 0)
                    {
                        Instantiate(hazardRed, spawnPostion, spawnRotation);
                        redCount2 = redCount2 - 1;
                    }
                    else { Instantiate(hazardBlue, spawnPostion, spawnRotation);
                    blueCount2 = blueCount2 - 1;
                    }
                }
                else {
                    if (blueCount2 == 0)
                    {
                        Instantiate(hazardRed, spawnPostion, spawnRotation);
                    }
                    else { Instantiate(hazardBlue, spawnPostion, spawnRotation); }
                
                }
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            blueCount2 = blueCount;
            redCount2 = redCount;
            waveCount++;

            if (gameOver)
            {
                restartText.text = "Press 'R' to Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        //scoreText.text = "Score:" + score;
    }
    public void GameOver()
    {
        //gameOverText.text = "Game Over";
        gameOver = true;
    }
    public void LoseHealth() {
        HealthTotal = HealthTotal - 1;

    
    }
}
