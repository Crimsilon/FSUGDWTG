using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControllerRed : MonoBehaviour {

	
    private int bounceCount;

    private PlayerController PlayerControllerRed;

    void Start() {
        GameObject playerObjectRed = GameObject.FindWithTag("PlayerRed");
        PlayerControllerRed = playerObjectRed.GetComponent<PlayerController>();
        bounceCount = PlayerControllerRed.BounceRed;
    
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
