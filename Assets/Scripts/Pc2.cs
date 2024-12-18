using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class Pc2 : MonoBehaviour
{
    //keybinds
    [SerializeField] private KeyCode Jump = KeyCode.Space;

    //movement
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpAmount = 20f;
    [SerializeField] private float fallSpeed = -3f;
    [SerializeField] private float maxSpeed = 10f;

    //jump 
    [SerializeField] private float jumpTime;
    [SerializeField] private float buttonTime = 0.3f;
    [SerializeField] public bool isJumping;

    //player
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private bool Running;
    [SerializeField] private bool superIdle;

    //Health
    public int maxHealth = 100;
    public int currentHealth;
    public int healAmmount = 25;
    public heal heal;
    public Healthbar healthbar;

    //ground check
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float maxDistance;
    private bool Gcheck;

    //EnemyCheck
    [SerializeField] private LayerMask layerMaskE;
    public enemycontrol Enemy;
    private bool Echeck;


    //timer
    private float idleTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerAnim.SetBool("Running", Running);
        playerAnim.SetBool("superIdle", superIdle);
        playerAnim.SetBool("isJumping", isJumping);
    }

    // Update is called once per frame
    private void Update()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        
        if (inputHorizontal != 0f)
        {
            rb.AddForce(Vector2.right * inputHorizontal * moveSpeed);
            //superIdle = false;
            //playerAnim.SetBool("superIdle", superIdle);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }

        //Clamped movement and fall speed
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, fallSpeed, jumpAmount));

        if (EnemyCheck())
        {
            Debug.Log("Enemy");
            
        }


        if(rb.velocity.x > 0.01)
        {
            sr.flipX = false;

            idleTimer = 0;
        }
        if(rb.velocity.x < -0.01)
        {
            sr.flipX = true;

            idleTimer = 0;
        }
        else if(inputHorizontal == 0f)
        {
            Running = false;
            playerAnim.SetBool("Running", Running);
            idleTimer = idleTimer + Time.deltaTime;
        }
        if(idleTimer >= 5)
        {
            superIdle = true;
            Debug.Log("SuperIDle");
            playerAnim.SetBool("superIdle", superIdle);
        }
        if (idleTimer < 5)
        {
            superIdle = false;
            playerAnim.SetBool("superIdle", superIdle);
        }




        //Check if moving and running
        if(rb.velocity.x > 0.01 && inputHorizontal != 0f)
        {
            Running = true;
            playerAnim.SetBool("Running", Running);
        }
        if(rb.velocity.x < -0.01 && inputHorizontal != 0f)
        {
            Running = true;
            playerAnim.SetBool("Running", Running);
        }

        if (Input.GetKeyDown(Jump) && GroundCheck())
        {
            isJumping = true;
            playerAnim.SetBool("isJumping", isJumping);
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            jumpTime = 0;
            idleTimer = 0;
            StartCoroutine(JumpWait());
        }



    }

    IEnumerator JumpWait()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        while (!GroundCheck() && isJumping)
        {
            yield return null;
        }
        isJumping = false;
        playerAnim.SetBool("isJumping", isJumping);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }

    private bool GroundCheck()
    {
        Gcheck = Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask);
        //Debug.Log("Landed");
        Debug.Log(Gcheck);
        return Gcheck;
        
    }   
    private bool EnemyCheck()
    {
        Echeck = Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMaskE);
        Debug.Log(Echeck);
        return Echeck;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);

            rb.velocity = new Vector2(Random.Range(-25f, 25f), jumpAmount * 0.75f);

            enemycontrol enemy = collision.gameObject.GetComponent<enemycontrol>();
            if (enemy != null)
            {
                enemy.dead = true;
            }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadSceneAsync("Game Over");
        }
    }

    public void Heal(int healAmmount)
    {
        currentHealth += healAmmount;
        healthbar.SetHealth(currentHealth);
    }

    public int itemsCollected = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tubby")
        {
            itemsCollected++;
            Destroy(other.gameObject);
        }
    }
}
