using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    private GameObject player;
    private Player playerScript;
    private float delay = 0.1f;

    [SerializeField]
    private Slider slider;

    [SerializeField] private string playerTag;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            slider.value = playerScript.getLifePoints();
            delay = 0.1f;
        }
    }
}
