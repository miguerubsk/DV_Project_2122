using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioBandera : MonoBehaviour
{

    [SerializeField] GameObject  flag_block, flag_victory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cambiaBandera() {

        flag_block.SetActive(false);
        flag_victory.SetActive(true);
    }


}
