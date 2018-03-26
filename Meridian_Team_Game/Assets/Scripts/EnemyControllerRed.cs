using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerRed : MonoBehaviour {

    public GameObject explosion, pickUpRed,pickUpRed2;
    public int scoreValue, dropRate;

    private GameController gameController;
    private bool scoreable;
    private float dropChance, pickupTypeRed;

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
                        gameController.AddScore(scoreValue);
                        scoreable = false;
                        dropChance = Random.Range(dropRate, 2);
                        if (dropChance >= 0)
                        {
                            pickupTypeRed = 0;
                            while (pickupTypeRed == 0)
                            {
                                pickupTypeRed = Random.Range(-2, 3);
                            }
                            if (pickupTypeRed > 0)
                            {
                                Instantiate(pickUpRed, transform.position, new Quaternion(0, 0, 0, 0));
                            }
                            else { Instantiate(pickUpRed2, transform.position, new Quaternion(0, 0, 0, 0)); }
                        }

                    }
                
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        if (other.tag == "PlayerWall") {
            Destroy(gameObject);
            gameController.LoseHealth();
        
        }
        }


    }

