using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScript: MonoBehaviour
{
    [SerializeField] private GameObject timerObject;
    
    private float second = 1f;
    private float time = 120f;
    private TextMeshProUGUI timerText;


    // Start is called before the first frame update
    void Start()
    {
        timerText = timerObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        second -= Time.deltaTime;
        if (second <= 0)
        {
            time -= 1;
            second = 1;
            timerText.text = time.ToString();
        }
    }
}