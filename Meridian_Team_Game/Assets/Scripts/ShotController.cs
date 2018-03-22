using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

    public int bounceCount;
    void OnCollisionEnter(Collision other) {
        bounceCount = bounceCount - 1;
        if (bounceCount == 0)
        {
            Destroy(gameObject);
        }
    
    }
}
