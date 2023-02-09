using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    
    public GameObject settingsWindow;
    
    public void StartGame(){
        SceneManager.LoadScene(3);
    }

    public void SettingsButton(){
        settingsWindow.SetActive(true);  
    }

    public void CloseSettingsButton(){
        settingsWindow.SetActive(false);  
    }

    public void QuitGame(){
        Application.Quit();
    }
}
