using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    
    public GameObject settingsWindow;

    [SerializeField] private string[] gameScenes;
    public void StartGame(){
        SceneManager.LoadScene(gameScenes[Random.Range(0, gameScenes.Length)]);
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
