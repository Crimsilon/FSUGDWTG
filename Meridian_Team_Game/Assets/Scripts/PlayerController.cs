﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed, fireRate, powerUpTimer,rotateSpeed;
    public Boundry boundry;
    public GameObject shot;
    public Transform ShotsSpawn;
    public bool TriShot, GiantShot;
    public int BounceRed;

    private float nextFire, fireRate2, powerUpDespawn, powerUpDespawn2,rotateAngle;
    private Rigidbody rb;
    private AudioSource audiosource;
    private Vector3 ShotsSpawn2, ShotsSpawn3;
    private Quaternion rotation;
    private GameController gameControllerRed;
    private bool CanUpgradeRed;
   


    void Start()
    {
        rotateAngle = 180;
        CanUpgradeRed = false;
        rb = GetComponent<Rigidbody>();
        fireRate2 = fireRate;
        BounceRed = 5;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameControllerRed = gameControllerObject.GetComponent<GameController>();
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
        if (Input.GetButton("FireRed") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate2;
            Instantiate(shot, ShotsSpawn.position, ShotsSpawn.rotation);

            if (TriShot)
            {

                Instantiate(shot, ShotsSpawn2, ShotsSpawn.rotation);
                Instantiate(shot, ShotsSpawn3, ShotsSpawn.rotation);
            }


        }
        if (CanUpgradeRed) {
            if (Input.GetButton("UpgradeRed1")) {
                fireRate2 = fireRate2 - .05f;
                CanUpgradeRed = false;
                gameControllerRed.PlayerRedChoice();
            }
            if (Input.GetButton("UpgradeRed2")) {
                gameControllerRed.GainHealth();
                CanUpgradeRed = false;
                gameControllerRed.PlayerRedChoice();
            }
            if (Input.GetButton("UpgradeRed3"))
            {
                BounceRed++;
                CanUpgradeRed = false;
                gameControllerRed.PlayerRedChoice();
            }
           
        
        }
        
    }
    void FixedUpdate()
    {
        float moveHorizontal = 0;
        if(Input.GetButton("MoveLeftRed")){
        moveHorizontal = -1;
        }
        else if (Input.GetButton("MoveRightRed"))
        {
            moveHorizontal = 1;

        }
        else { moveHorizontal = 0; }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.velocity = movement * speed;
        if (Input.GetButton("RotateLeftRed"))
        {
            if (rotateAngle >= 95) { rotateAngle = rotateAngle - rotateSpeed; }
            transform.eulerAngles = new Vector3(0, rotateAngle, 0);
        }
        if (Input.GetButton("RotateRightRed"))
        {
            if(rotateAngle<=265){rotateAngle = rotateAngle + rotateSpeed;}
            transform.eulerAngles = new Vector3(0,rotateAngle,0);
        }
        

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundry.xMin, boundry.xMax), 0.0f, Mathf.Clamp(rb.position.z, boundry.zMin, boundry.zMax));
        


    }
    public void PickupRed1() {
        TriShot = true;			
		powerUpDespawn = Time.time;
    
    }
    public void PickupRed2()
    {
        GiantShot = true;
        powerUpDespawn2 = Time.time;

    }
    public void EnableUpgradeRed() {
        CanUpgradeRed = true;
    
    }
}


