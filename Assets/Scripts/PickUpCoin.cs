using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour {

    GameManager gameManager;
    [SerializeField] GameObject pickupEffect;
    [SerializeField] AudioClip m_pickSound = null;

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
            AudioSource.PlayClipAtPoint(m_pickSound, this.transform.position, 1);
            Instantiate(pickupEffect, transform.position, transform.rotation);
            gameManager.AddScore(5);
            Destroy(gameObject);
        }
    }

}
