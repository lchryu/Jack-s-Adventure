using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScreenScript : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Main Menu");
        HealthSystem.ResetHealthSystem();
        ItemCollector.SaveCherriesToPlayerPrefs();
    }
    
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
