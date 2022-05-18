using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEntrada : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void botonStart()
    {
    
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
       
    }

    public void botonQuit()
    {
        Application.Quit();
    }

}
