using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoundryBlue
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerControllerBlue : MonoBehaviour
{
    public float speed, fireRate, powerUpTimer;
    public BoundryBlue boundry;
    public GameObject shot;
    public Transform ShotsSpawn;
    public bool TriShot, GiantShot;
    public int Bounce;

    private float nextFire, fireRate2, powerUpDespawn, powerUpDespawn2, spin;
    private Rigidbody rb;
    private AudioSource audiosource;
    private Vector3 ShotsSpawn2, ShotsSpawn3;
    private Quaternion rotation;
    private GameController gameControllerBlue;
    private ShotController ShotControllerBlue;
    private bool CanUpgradeBlue;
    



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fireRate2 = fireRate;
        Bounce = 5;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameControllerBlue = gameControllerObject.GetComponent<GameController>();
        }
       
    }


    void Update()
    {
        ShotsSpawn2 = new Vector3(ShotsSpawn.position.x - 1, ShotsSpawn.position.y, ShotsSpawn.position.z);
        ShotsSpawn3 = new Vector3(ShotsSpawn.position.x + 1, ShotsSpawn.position.y, ShotsSpawn.position.z);
        if (TriShot && Time.time >= powerUpDespawn + powerUpTimer)
        {
            TriShot = false;
        }
        if (GiantShot && Time.time >= powerUpDespawn2 + powerUpTimer)
        {
            GiantShot = false;
        }
        if (GiantShot)
        {
            shot.transform.localScale = new Vector3(.5f, .5f, .5f);

        }
        else
        {
            shot.transform.localScale = new Vector3(.255f, .255f, .255f);
        }
        if (Input.GetButton("FireBlue") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate2;
            Instantiate(shot, ShotsSpawn.position, ShotsSpawn.rotation);

            if (TriShot)
            {

                Instantiate(shot, ShotsSpawn2, ShotsSpawn.rotation);
                Instantiate(shot, ShotsSpawn3, ShotsSpawn.rotation);
            }


        }
        if (CanUpgradeBlue)
        {
            if (Input.GetButton("UpgradeBlue1"))
            {
                fireRate2 = fireRate2 - .05f;
                CanUpgradeBlue = false;
                gameControllerBlue.PlayerBlueChoice();
            }
            if (Input.GetButton("UpgradeBlue2"))
            {
                gameControllerBlue.GainHealth();
                CanUpgradeBlue = false;
                gameControllerBlue.PlayerBlueChoice();
            }
            if (Input.GetButton("UpgradeBlue3"))
            {
                Bounce++;
                CanUpgradeBlue = false;
                gameControllerBlue.PlayerBlueChoice();
            }

        }

    }
    void FixedUpdate()
    {
        float moveHorizontal = 0;
        if (Input.GetButton("MoveRightBlue"))
        {
            moveHorizontal = -1;
        }
        else if (Input.GetButton("MoveLeftBlue"))
        {
            moveHorizontal = 1;

        }
        else { moveHorizontal = 0; }
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.velocity = movement * speed;
        if (Input.GetButton("RotateLeftBlue"))
        {
            transform.Rotate(Vector3.down * 85 * Time.deltaTime);
            rotation = Quaternion.Euler(transform.rotation.x, spin, transform.rotation.z);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime);
        }
        if (Input.GetButton("RotateRightBlue"))
        {
            transform.Rotate(Vector3.up * 85 * Time.deltaTime);
            rotation = Quaternion.Euler(transform.rotation.x, spin, transform.rotation.z);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime);
        }

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundry.xMin, boundry.xMax), 0.0f, Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax));



    }
    public void PickupBlue1()
    {
        TriShot = true;
        powerUpDespawn = Time.time;

    }
    public void PickupBlue2()
    {
        GiantShot = true;
        powerUpDespawn2 = Time.time;

    }
    public void EnableUpgradeBlue()
    {
        CanUpgradeBlue = true;

    }
 
}


