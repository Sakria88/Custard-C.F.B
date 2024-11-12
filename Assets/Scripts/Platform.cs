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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collapsable == true)
        {
            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("brick dis"))
            {

                if (animator.GetCurrentAnimatorStateInfo(0).length > animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
                {
                    Destroy(gameObject);
                }
            }
            if (collision.gameObject.tag == "Player")
            {
                timers = true;


            }
            if (timers == true)
            {
                timer = timer + Time.deltaTime;
                if (timer > 2)
                {
                    animator.SetBool("step time", true);
                }
            }


        }



    }
}
