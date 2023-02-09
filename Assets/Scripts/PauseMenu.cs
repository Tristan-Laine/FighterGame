using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("StartControllerSwitch") || Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            }else
            {
                Paused();
            }
        }
        if(gameIsPaused){
            if(Input.GetButtonDown("SelectControllerSwitch")){
                LoadMainMenu();
            }
        }
    }

    public void Paused(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void LoadMainMenu(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
