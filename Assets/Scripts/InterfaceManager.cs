using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] GameObject menuInicio;
    [SerializeField] GameObject menuPausa;

    public static bool inicia, pausa;

    // Start is called before the first frame update
    void Start()
    {
        menuInicio.SetActive(false);
        menuPausa.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        inicia = false;
        panelInicio();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausa)
            {
                botonResume();
            }else
            {
                Debug.Log("Pausa");
                panelPausa();
            }
        }
    }

    public void botonStart()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1f;
        menuInicio.SetActive(false);
    }

    public void botonQuit()
    {
        Debug.Log("Saliendo de la aplicación");
        Application.Quit();
    }
    public void botonResume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        menuPausa.SetActive(false);
        pausa = inicia = false;
        //menuInicio.SetActive(false);
        Time.timeScale = 1f;
    }

    public static bool play()
    {
        return !inicia && !pausa;
    }

    public void panelInicio()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            inicia = true;
            menuInicio.SetActive(true);
            Time.timeScale = 0f;
        }
        

    }

    public void panelPausa()
    {
        Debug.Log("Pausa");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
        
    }
}
