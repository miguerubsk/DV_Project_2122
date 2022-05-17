using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            gameManager.pickKeyItem();
            gameManager.AddScore(20);
            gameManager.AddHealth();
            GameObject.Destroy(gameObject);
        }
    }
}
