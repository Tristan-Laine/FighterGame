using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    
    public GameObject settingsWindow;

    public AudioSource audioSource;
    public AudioClip sound;
    
    public void StartGame(){
        audioSource.PlayOneShot(sound);
        SceneManager.LoadScene(3);
    }

    public void SettingsButton(){
        audioSource.PlayOneShot(sound);
        settingsWindow.SetActive(true);  
    }

    public void CloseSettingsButton(){
        audioSource.PlayOneShot(sound);
        settingsWindow.SetActive(false);  
    }

    public void QuitGame(){
        audioSource.PlayOneShot(sound);
        Application.Quit();
    }
}
