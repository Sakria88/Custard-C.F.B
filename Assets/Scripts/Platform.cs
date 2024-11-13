using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private bool collapsable;
    public float timer;
    public bool timers;
    public float respawn;
    [SerializeField] public float timeLimit;
    [SerializeField] public Collider2D collider2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timers == true)
        {
            timer = timer + Time.deltaTime;
            if (timer > timeLimit)
            {
                animator.SetBool("step time", true);
                respawn = respawn + Time.deltaTime;
               
            }
        }
        if (timers == false)
        {
            respawn = 0;
            timer = 0;

        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("brick dis"))
        {

            if (animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
            {
                collider2.enabled = false;
            }
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("frost block 0"))
        {

            if (animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
            {
                collider2.enabled = false;
            }
        }
        if (respawn > 3)
        {
            collider2.enabled = true;
            timers = false;
            animator.SetBool("step time", false);
            animator.SetBool("Dis", false);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collapsable == true)
        {

            if (collision.gameObject.tag == "Player")
            {
                timers = true;
                animator.SetBool("Dis", true);


            }



        }



    }
}
