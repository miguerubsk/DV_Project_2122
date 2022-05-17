using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour

{

    [SerializeField] GameObject padre;
    [SerializeField] Collider colliderPadre;
    
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
        padre.transform.localScale -= new Vector3(0, (float)0.8, 0);
        colliderPadre.enabled = false;
        Destroy(padre,2);


    }

   
}
