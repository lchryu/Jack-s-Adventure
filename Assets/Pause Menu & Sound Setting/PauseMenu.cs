using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void Home()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
        HealthSystem.ResetHealthSystem();
        PLayerLife.SaveCherriesStatic();
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        ItemCollector.cherries = 0;
    }
}

/*
 * timeScale = 0 --> stop toan bo tro choi
 * timeScale = 1 --> continue
 */