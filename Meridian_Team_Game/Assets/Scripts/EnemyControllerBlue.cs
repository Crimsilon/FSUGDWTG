using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBlue : MonoBehaviour
{

    public GameObject explosionBlue, pickUpBlue, pickUpBlue2;
    public int scoreValueBlue, dropRateBlue;

    private GameController gameControllerBlue;
    private bool scoreableBlue;
    private float dropChanceBlue,pickupTypeBlue;

    void Start()
    {
        scoreableBlue = true;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameControllerBlue = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerBlue == null)
        {
            Debug.Log("Cannot Find 'game controller'");
        }
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.tag == "ShotBlue")
        {
            //Instantiate(explosion, transform.position, transform.rotation);



            if (scoreableBlue)
            {
                gameControllerBlue.AddScore(scoreValueBlue);
                scoreableBlue = false;
                dropChanceBlue = Random.Range(dropRateBlue, 2);
                if (dropChanceBlue >= 0)
                {
                    pickupTypeBlue = 0;
                    while (pickupTypeBlue == 0)
                    {
                        pickupTypeBlue = Random.Range(-2, 3);
                    }
                    if (pickupTypeBlue > 0)
                    {
                        Instantiate(pickUpBlue, transform.position, new Quaternion(0, 0, 0, 0));
                    }
                    else { Instantiate(pickUpBlue2, transform.position, new Quaternion(0, 0, 0, 0)); }
                }

            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.tag == "PlayerWall")
        {
            Destroy(gameObject);
            gameControllerBlue.LoseHealth();

        }
    }


}

