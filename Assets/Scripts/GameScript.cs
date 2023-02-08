using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GameScript: MonoBehaviour
{
    [SerializeField] private GameObject timerObject;
    [SerializeField] private float time = 120f;
    [SerializeField] private GameObject endGameUI;

    private float second = 1f;
    private TextMeshProUGUI timerText;
    private GameObject endTextGameObject;
    private bool gameEnded;
    private GameObject audioPlayer;


    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GameObject.FindGameObjectWithTag("AudioPlayer");
        timerText = timerObject.GetComponent<TextMeshProUGUI>();
        endTextGameObject = endGameUI.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Fin de partie
        if (time > 0 && !gameEnded)
        {
            second -= Time.deltaTime;
            if (second <= 0)
            {
                time -= 1;
                timerText.text = time.ToString();
                second = 1;
            }
        }
        else if(time <= 0)
        {
            GameEnded(null);
        }
    }

    public void GameEnded([CanBeNull] GameObject loser)
    {
        gameEnded = true;
        TextMeshProUGUI endText = endTextGameObject.GetComponent<TextMeshProUGUI>();
        if (loser)
        {
            endText.text = loser.name + " a perdu";
            loser.SetActive(false);
        }
        else
        {
            endText.text = "Egalité";
        }

        audioPlayer.GetComponent<AudioManager>().gameEnded();
        endGameUI.SetActive(true);
    }
}