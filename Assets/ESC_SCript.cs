using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESC_SCript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void TogglePauseMenu()
    {
        //pauseMenu.SetActive(true);
        //Time.timeScale = 0;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }
}
