using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Objeto GameManager
    private GameObject gameManager;
    private GameObject musicaMenu;

    void Start()
    {
        //Busco el objeto llamado GameManager
        gameManager = GameObject.Find("GameManager");
        musicaMenu = GameObject.Find("MusicMenu");

        //Le indico que no se destruya al cargar otra escena 
        DontDestroyOnLoad(gameManager);
        DontDestroyOnLoad(musicaMenu);

        //Cargo la escena de inicio
        //SceneManager.LoadScene("Menu");    }

    }
    public void menuLogin()
    {
        SceneManager.LoadScene("MenuLogin");
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void menuSalir()
    {
        Application.Quit();
    }

    public void menuInfo()
    {
        SceneManager.LoadScene("MenuInfo");
    }

    public void abrirRegister()
    {
        Application.OpenURL("http://3.8.131.236/GAME/public/index.php/admin");    }

    void reiniciar()
    {
        SceneManager.LoadScene("Juego");
    }
}

