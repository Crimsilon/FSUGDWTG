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

    private float nextFire, fireRate2, powerUpDespawn, powerUpDespawn2, spin;
    private Rigidbody rb;
    private AudioSource audiosource;
    private Vector3 ShotsSpawn2, ShotsSpawn3;
    private Quaternion rotation;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fireRate2 = fireRate;

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
        if (Input.GetButton("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate2;
            Instantiate(shot, ShotsSpawn.position, ShotsSpawn.rotation);

            if (TriShot)
            {

                Instantiate(shot, ShotsSpawn2, ShotsSpawn.rotation);
                Instantiate(shot, ShotsSpawn3, ShotsSpawn.rotation);
            }


        }

    }
    void FixedUpdate()
    {
        float moveHorizontal = 0;
        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1;

        }
        else { moveHorizontal = 0; }
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.velocity = movement * speed;
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * 85 * Time.deltaTime);
            rotation = Quaternion.Euler(transform.rotation.x, spin, transform.rotation.z);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
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
}


