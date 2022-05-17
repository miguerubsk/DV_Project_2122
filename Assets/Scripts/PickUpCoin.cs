using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour {

    GameManager gameManager;

    // Start is called before the first frame update
    void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("A");
        if (other.tag == "Player") {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            gameManager.AddScore(5);
            Destroy(gameObject);
        }
    }

}
