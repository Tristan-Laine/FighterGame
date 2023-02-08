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
    
    [SerializeField] private Animator animator;

    // Variables
    private GameObject fist;
    private float fistCooldown = 0.3f;
    private bool punching = false;
    private bool canPunch = true;
    private bool flipped = false;
    private bool attacked = false;
    private BoxCollider2D fistCollider;
    private float attackedDelay = 0.3f;
    private string controllerType = "ControllerSwitch";


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
                Jump();
            }

            // Punch Movement
            if (Input.GetKeyDown(KeyCode.F) && canPunch && !punching)
            {
                Punch();
            }

            if (Input.GetKeyDown(KeyCode.C) && rb.velocity.y == 0 && canPunch)
            {
                // Crouch Sprite
            }
        }
        // Player 2 Movements
        else
        {
            float horizontalAxis = Input.GetAxis("Horizontal" + controllerType);
            
            // Left-Right Movement
            if ((horizontalAxis != 0 ) && !punching)
            {
                if (Input.GetAxis("Horizontal" + controllerType) < 0)
                {
                    GoLeft();
                }
                else if (horizontalAxis > 0)
                {
                    GoRight();
                }
            }

            // Jump Movement
            if ((Input.GetAxis("Jump"+controllerType)<0) && rb.velocity.y == 0 && !punching)
            {
                Jump();
            }
            
            //Punch
            if (Input.GetButtonDown("Punch" + controllerType) && canPunch && !punching)
            {
                Punch();
            }
        }
        if (rb.velocity.y ==0 && animator.GetBool("InAir"))
        {
            animator.SetBool("InAir", false);
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

    void Punch()
    {
        punching = true;
        animator.SetTrigger("test");
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
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        animator.SetBool("InAir", true);
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

            if (lifePoints == 0)
            {
                GameObject.FindGameObjectWithTag("GameUI").GetComponent<GameScript>().GameEnded(gameObject);
            }
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
