using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour {
    public GameObject player;

    // Start is called before the first frame update
    void Start() {
        //player = GameObject.Find("PlayerArmature");
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player) {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject == player) {
            player.transform.parent = GameObject.Find("Player").transform;
        }
    }

}
