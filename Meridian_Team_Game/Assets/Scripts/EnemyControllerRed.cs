using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerRed : MonoBehaviour {

    public GameObject explosion, pickUp;
    public int scoreValue, dropRate;

    private GameController gameController;
    private bool scoreable;
    private float dropChance;

    void Start()
    {
        scoreable = true;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot Find 'game controller'");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "ShotRed")
        {
            //Instantiate(explosion, transform.position, transform.rotation);
              
            
           
                if (scoreable)
                {
                        //gameController.AddScore(scoreValue);
                        scoreable = false;
                        dropChance = Random.Range(dropRate, 2);
                        if (dropChance >= 0)
                        {
                            Instantiate(pickUp, transform.position, new Quaternion(0, 0, 0, 0));

                        }

                    }
                
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }


    }

