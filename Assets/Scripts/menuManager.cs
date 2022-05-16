using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject menuInicio;
    [SerializeField] GameManager gameManager;

    public static bool isPaused, isStarting;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        menuPausa.SetActive(false);
        menuInicio.SetActive(false);
        isStarting = isPaused = false;
        
        Inicio();
            
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && play())
        {
            if (isPaused)
            {
                botonResume();
            }
            else
            {
                menuPause();
            }
        }
    }

    public void botonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void botonQuit() {
        Debug.Log("Saliendo de la aplicación");
        Application.Quit();
    }

    public void Inicio()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        isStarting = true;
        menuInicio.SetActive(true);
        /*if (SceneManager.GetActiveScene().buildIndex == 0)
        {

        }*/
        Time.timeScale = 0f;
    }

    public void menuPause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        menuPausa.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void botonResume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menuPausa.SetActive(false);
        //menuInicio.SetActive(false);
        Time.timeScale = 1f;
    }

    public static bool play()
    {
        return !isPaused && !isStarting;
    }

    public void botonRestart()
    {
        SceneManager.LoadScene(0);
    }

}
