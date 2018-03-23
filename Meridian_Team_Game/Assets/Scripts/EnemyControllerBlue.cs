using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBlue : MonoBehaviour
{

    public GameObject explosionBlue, pickUpBlue;
    public int scoreValueBlue, dropRateBlue;

    private GameController gameControllerBlue;
    private bool scoreableBlue;
    private float dropChanceBlue;

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
                //gameController.AddScore(scoreValue);
                scoreableBlue = false;
                dropChanceBlue = Random.Range(dropRateBlue, 2);
                if (dropChanceBlue >= 0)
                {
                    Instantiate(pickUpBlue, transform.position, new Quaternion(0, 0, 0, 0));

                }

            }

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }


}

