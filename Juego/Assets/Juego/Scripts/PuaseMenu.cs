using UnityEngine;
using UnityEngine.SceneManagement;
public class PuaseMenu : MonoBehaviour{

    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    //

        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Salir()
    {
        SceneManager.LoadScene("Menu");

    }
}
