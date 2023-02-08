using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

public string gameToLoad;

public GameObject settingsWindow;

    public void StartGame(){
        SceneManager.LoadScene(gameToLoad);
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
