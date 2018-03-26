using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject hazardBlue, hazardRed, HealthBar;
    public Vector3 spawnValues;
    public int hazardCount, score, enemyIncrease, whenIncrease, waveCount;
    public float spawnWait, startWait, waveWait,HealthTotal;
    public Text scoreText, restartText, gameOverText;

    private bool gameOver, restart, ChoiceRed,ChoiceBlue,Pause;
    private float enemyType;
    private int enemyTotal,waveUp;
    private PlayerController PlayerControllerRed;
    private PlayerControllerBlue PlayerControllerblue;

    void Start() {
        waveUp = 1;
        enemyTotal = hazardCount;
        waveCount = 1;
        StartCoroutine(SpawnWaves());
        score = 0;
        UpdateScore();
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        ChoiceRed = true;
        ChoiceBlue = true;
        GameObject playerObjectRed = GameObject.FindWithTag("PlayerRed");
        PlayerControllerRed = playerObjectRed.GetComponent<PlayerController>();
        GameObject playerObjectBlue = GameObject.FindWithTag("PlayerBlue");
        PlayerControllerblue = playerObjectBlue.GetComponent<PlayerControllerBlue>();

    
    }
	
	
	void Update () {
        if(waveCount>=waveUp+whenIncrease){
            waveUp = waveCount;
            enemyTotal = enemyTotal + enemyIncrease;
            
            spawnWait = (spawnWait / 1.5f);
            
            
        }
        if (HealthTotal <= 0)
                GameOver();
        if(HealthTotal >=0)
            HealthBar.transform.localScale = new Vector3(HealthTotal/2, 1, 1);
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

		
	}
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            gameOverText.text = "Wave:" + waveCount;
            restartText.text = "Wave:" + waveCount;
            yield return new WaitForSeconds(waveWait);
            gameOverText.text = "";
            
            while (Pause) {
                yield return new WaitForSeconds(.02f);
                if (ChoiceRed)
                {
                    if (ChoiceBlue)
                    {
                        Pause = false;
                    }
                }
            
            }

            
            for (int i = 0; i < enemyTotal; i++)
            {
                Vector3 spawnPostion1 = new Vector3(Random.Range(-spawnValues.x, -1.5f), spawnValues.y, spawnValues.z);
                Vector3 spawnPostion2 = new Vector3(Random.Range(1.5f, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                enemyType = 0;
               
                    while (enemyType == 0)
                    {
                        enemyType = Random.Range(-2, 8);
                    }
                    if (enemyType > 0)
                    {
                        Instantiate(hazardRed, spawnPostion1, spawnRotation);
                        Instantiate(hazardBlue, spawnPostion2, spawnRotation);
                        
                    }
                    else
                    {
                        Instantiate(hazardBlue, spawnPostion1, spawnRotation);
                        Instantiate(hazardRed, spawnPostion2, spawnRotation);
                    }
                
                
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            
                waveCount++;
            
            

            if (gameOver)
            {
                restartText.text = "Press 'fire' to Restart";
                restart = true;
                break;
            }
            
            if(ChoiceBlue && ChoiceRed){
                PlayerControllerRed.EnableUpgradeRed();
                PlayerControllerblue.EnableUpgradeBlue();
                FalseChoice();
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
        scoreText.text = "Score:" + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
    public void LoseHealth() {
        HealthTotal = HealthTotal - 1;

    
    }
    public void GainHealth(){
        HealthTotal = HealthTotal + 5;

    
    }
    public void PlayerRedChoice() { ChoiceRed = true; }
    public void PlayerBlueChoice() { ChoiceBlue = true; }
    void FalseChoice() { ChoiceRed = false; ChoiceBlue = false; Pause = true; }
}
