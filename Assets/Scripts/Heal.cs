using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {
    [SerializeField] AudioClip m_pickSound;
    [SerializeField] GameObject pickupEffect;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            gameManager.HealPlayer();
            AudioSource.PlayClipAtPoint(m_pickSound, this.transform.position, 1);
            GameObject effect = Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(effect, 3);
            Debug.Log(gameManager.GetHealth());
            Destroy(gameObject);
        }
    }
}
