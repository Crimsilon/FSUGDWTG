﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

    private int bounceCount;

    private PlayerControllerBlue PlayerControllerblue;

    void Start() {
        GameObject playerObjectBlue = GameObject.FindWithTag("PlayerBlue");
        PlayerControllerblue = playerObjectBlue.GetComponent<PlayerControllerBlue>();
        bounceCount = PlayerControllerblue.Bounce;
    
    }
    void OnCollisionEnter(Collision other) {
        bounceCount = bounceCount - 1;
        if (bounceCount == 0)
        {
            Destroy(gameObject);
        }
    
    }
    public void IncreaseBounce() { bounceCount = bounceCount + 1; }
}
