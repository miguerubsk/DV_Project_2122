using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public void botonStart()
    {
        SceneManager.LoadScene("");
    }

    public void botonQuit() {
        Debug.Log("Saliendo de la aplicación");
        Application.Quit();
    }

}
