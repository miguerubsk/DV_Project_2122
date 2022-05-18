using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    [SerializeField] GameManager gameManager;
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
        if(other.tag == "Player") {
            GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(m_pickSound, this.transform.position, 1);
            gameManager.pickKeyItem();
            gameManager.AddScore(20);
            //gameManager.HealPlayer();
            Destroy(effect, 3);
            GameObject.Destroy(gameObject);
        }
    }
}
