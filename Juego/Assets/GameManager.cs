using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Objeto GameManager
    private GameObject gameManager;

	[SerializeField]private GameObject pauseMenuUI;	
	private bool GameIsPaused = true;

    void Start()
    {
        //Busco el objeto llamado GameManager
        gameManager = GameObject.Find("GameManager");

        //Le indico que no se destruya al cargar otra escena 
        DontDestroyOnLoad(gameManager);

        //Cargo la escena de inicio
        //SceneManager.LoadScene("Menu");
    }

	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
			if(GameIsPaused){
				Resume();
			}else{
				Pause();
			}
		}
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

	public void abrirRegister(){
		Application.OpenURL("http://3.8.131.236/GAME/public/index.php/admin");
	}


	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

    public void reiniciar()
    {
        SceneManager.LoadScene("Juego");
    }


}
