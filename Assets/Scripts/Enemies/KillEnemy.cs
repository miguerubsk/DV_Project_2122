using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour

{

    [SerializeField] GameObject padre;
    [SerializeField] Collider colliderPadre;
    [SerializeField] AudioClip killSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        colliderPadre.enabled = false;
        padre.transform.localScale -= new Vector3(0, (float)0.3, 0);
        AudioSource.PlayClipAtPoint(killSound, transform.position, 1);
        Destroy(padre,1);


    }

   
}
