using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Components
    [SerializeField] SpriteRenderer p_spriteRenderer;
    [SerializeField] Rigidbody2D rb;

    //Movement
    [SerializeField] private float f_playerSpeed;

    //Jumping
    [SerializeField] private float f_jumpHeight = 1;
    public float cancelRate = 1000;
    public float buttonTime = 0.5f;
    float jumpTime;
    bool isJumping;
    bool jumpCancelled;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Transform Movement
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += Vector3.right * f_playerSpeed * Time.deltaTime;
        //    Debug.Log("Right");
        //    p_spriteRenderer.flipX = false;

        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += Vector3.right * -f_playerSpeed * Time.deltaTime;
        //    Debug.Log("Left");
        //    p_spriteRenderer.flipX = true;
        //}

        //Physics based movement
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = Vector2.right * inputHorizontal * f_playerSpeed;
        Debug.Log(inputHorizontal);

        //Jumping + Variable Jump Height + Calculate Jump height SQR -2 * gravity * height
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpForce = Mathf.Sqrt(f_jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            jumpCancelled = false;
            jumpTime = 0;
        }
        if (isJumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if(jumpTime > buttonTime)
            {
                isJumping = false;
            }

        }

    }
    private void FixedUpdate()
    {
        if(jumpCancelled && isJumping && rb.velocity.y > 0)
        {
            //rb.AddForce(Vector2.down * cancelRate);
        }
    }
}

