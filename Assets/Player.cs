using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Fields
    [SerializeField, Range(1f, 10f)]
    private float playerSpeed = 5;
    
    [SerializeField, Range(1f, 10f)]
    private float jumpAmount = 5;
    
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField] 
    private float punchDistance = 0.8f;     
    
    [SerializeField] 
    private float punchDelay = 0.6f;

    [SerializeField]
    private float lifePoints = 20f;
    
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    // Variables
    private GameObject fist;
    private float fistCooldown = 0.3f;
    private bool punching = false;
    private bool canPunch = true;
    private bool flipped = false;

    
    // Start is called before the first frame update
    void Start()
    {
        fist = gameObject.transform.GetChild(0).gameObject;
    }
    
    void Update()
    {
        // Left-Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !punching)
        {
            GoLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !punching)
        {
            GoRight();
        }

        // Jump Movement
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0 && !punching)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        
        // Punch Movement
        if (Input.GetKeyDown(KeyCode.F) && canPunch)
        {
            // Punch Sprite
            if (flipped)
            {
                fist.transform.Translate(-punchDistance, 0, 0);
            }
            else
            {
                fist.transform.Translate(punchDistance, 0, 0);
            }
            punching = true;
        }

        if (Input.GetKeyDown(KeyCode.C) && rb.velocity.y == 0 && canPunch)
        {
            // Crouch Sprite
        }

        // Punching
        if (punching)
        {
            fistCooldown -= Time.deltaTime;
            if (fistCooldown <= 0)
            {
                // idle Sprite
                if (flipped)
                {
                    fist.transform.Translate(punchDistance, 0, 0);
                }
                else
                {
                    fist.transform.Translate(-punchDistance, 0, 0);
                }

                
                fistCooldown = 0.3f;
                punching = false;
                
                // init delay after punch
                canPunch = false;
            }
        }
        else
        {
            punchDelay -= Time.deltaTime;
            if (punchDelay <= 0)
            {
                canPunch = true;
                punchDelay = 0.6f;
            }
        }
    }
    void GoLeft()
    {
        // If facing right
        if (!flipped)
        {
            FlipPlayer();
        }
        transform.Translate(- (playerSpeed * Time.deltaTime), 0, 0);
    }

    void FlipPlayer()
    {
        flipped = !flipped;
        spriteRenderer.flipX = flipped;
    }
    
    void GoRight()
    {
        // If facing left
        if (flipped)
        {
            FlipPlayer();
        }
        transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
    }
}
