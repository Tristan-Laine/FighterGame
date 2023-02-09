using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackGround : MonoBehaviour
{
    public Sprite[] backgrounds;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
    }
}
