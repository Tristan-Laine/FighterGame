using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private float lifePoints = 100f;
    
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    
    [SerializeField]
    private string target;

    [SerializeField] private bool controller;

    [SerializeField] private CapsuleCollider2D boxCollider2D;

    // Variables
    private GameObject fist;
    private float fistCooldown = 0.3f;
    private bool punching = false;
    private bool canPunch = true;
    private bool flipped = false;
    private bool attacked = false;
    private BoxCollider2D fistCollider;
    private float attackedDelay = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        fist = gameObject.transform.GetChild(0).gameObject;
        fistCollider = fist.GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {

        // Player 1 Movement
        //if (transform.CompareTag("Player1") || transform.CompareTag("Player2"))
        if(!controller)
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
            if (Input.GetKeyDown(KeyCode.F) && canPunch && !punching)
            {
                punching = true;
                // Punch Sprite
                if (flipped)
                {
                    fist.transform.Translate(-punchDistance, 0, 0);
                }
                else
                {
                    fist.transform.Translate(punchDistance, 0, 0);
                }
            }

            if (Input.GetKeyDown(KeyCode.C) && rb.velocity.y == 0 && canPunch)
            {
                // Crouch Sprite
            }
        }
        // Player 2 Movements
        else if(transform.CompareTag("Player"))
        {
            // Left-Right Movement
            if ((Input.GetAxis("HorizontalPlayer2") != 0 ) && !punching)
            {
                transform.Translate(Vector2.right * Input.GetAxis("HorizontalPlayer2") * playerSpeed * Time.deltaTime);
            }

            // Jump Movement
            if (Input.GetButtonDown("JumpPlayer2") && rb.velocity.y == 0 && !punching)
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            }
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
        if (attacked)
        {
            attackedDelay -= Time.deltaTime;
            if (attackedDelay <= 0)
            {
                attacked = false;
                attackedDelay = 0.3f;
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

    public void lostPV(float attack)
    {
        if (!attacked)
        {
            lifePoints -= attack;
            attacked = true;
        }
    }

    public float getLifePoints()
    {
        return lifePoints;
    }

    public bool isPunching()
    {
        return punching;
    }

    public string getTarget()
    {
        return target;
    }

}
