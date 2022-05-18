using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    [SerializeField] GameObject menuInicio;
    [SerializeField] GameObject menuPausa;
    [SerializeField] GameObject menuWin;
    [SerializeField] GameObject menuGameOver;
    [SerializeField] GameObject HUD;
    GameManager gameManager;
    [SerializeField] TextMeshProUGUI vidas;
    [SerializeField] TextMeshProUGUI vitalidad;
    [SerializeField] TextMeshProUGUI puntos;
    [SerializeField] TextMeshProUGUI puntosFW;
    //[SerializeField] TextMeshProUGUI puntosF;
    [SerializeField] TextMeshProUGUI tiempo;
    [SerializeField] TextMeshProUGUI objetos;
    [SerializeField] TextMeshProUGUI nivel;


    public static bool inicia, pausa, ganar;

    // Start is called before the first frame update
    void Start()
    {
        menuInicio.SetActive(false);
        menuPausa.SetActive(false);
        menuWin.SetActive(false);
        menuGameOver.SetActive(false);
        HUD.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        inicia = pausa = ganar = false;
        
        if (SceneManager.GetActiveScene().name == "Puntuaciones")
        {
            panelWin();
        }
        else
        {
            panelInicio();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
            puntos.text = "Puntos: " + gameManager.GetCurrentScore();
            vidas.text = "Vidas: " + gameManager.GetLives();
            vitalidad.text = "Vitalidad: " + gameManager.GetHealth();
            objetos.text = "Objetos: " + gameManager.GetKeyItems();
            tiempo.text = "Tiempo: " + (int)Time.timeSinceLevelLoad;
        
        

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
        inicia = false;
        HUD.SetActive(true);
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
        HUD.SetActive(true);
        //menuInicio.SetActive(false);
        Time.timeScale = 1f;
    }

    public void botonRestart()
    {
        SceneManager.LoadScene(0);
        menuInicio.SetActive(false);
    }

    public static bool play()
    {
        return !inicia && !pausa;
    }

    public void panelInicio()
    {
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        inicia = true;
        menuInicio.SetActive(true);
        Time.timeScale = 0f;

        nivel.text = "Nivel: " + SceneManager.GetActiveScene().name;
        

    }

    public void panelPausa()
    {
        Debug.Log("Pausa");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
        HUD.SetActive(false);

    }

    public void panelWin()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        menuWin.SetActive(true);
        ganar = true;
        
        Time.timeScale = 0f;

        puntosFW.text = "Nivel 1: " + gameManager.GetLevelScore(1);
        puntosFW.text = "Nivel 2: " + gameManager.GetLevelScore(2);
        puntosFW.text = "Nivel 3: " + gameManager.GetLevelScore(3);
    }

    public void panelGameOver()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        menuGameOver.SetActive(true);

        //puntosF.text = "Puntuación: " + gameManager.GetCurrentScore();
        Time.timeScale = 0f;


    }

}
