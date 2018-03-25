using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollector : MonoBehaviour {
    private PlayerController PlayerControllerRed;
    private PlayerControllerBlue PlayerControllerblue;
    void Start() {
        GameObject playerObjectRed = GameObject.FindWithTag("PlayerRed");
        PlayerControllerRed = playerObjectRed.GetComponent<PlayerController>();
        GameObject playerObjectBlue = GameObject.FindWithTag("PlayerBlue");
        PlayerControllerblue = playerObjectBlue.GetComponent<PlayerControllerBlue>();
    
    
    }


	void OnTriggerEnter(Collider other){
        if(other.tag == "PowerRed1"){
            Destroy(other.gameObject);
            PlayerControllerRed.PickupRed1();
            
        }
        if (other.tag == "PowerRed2")
        {
            Destroy(other.gameObject);
            PlayerControllerRed.PickupRed2();
        }
        if (other.tag == "PowerBlue1")
        {
            Destroy(other.gameObject);
            PlayerControllerblue.PickupBlue1();
        }
        if (other.tag == "PowerBlue2")
        {
            Destroy(other.gameObject);
            PlayerControllerblue.PickupBlue2();
        }
    
    }
}
