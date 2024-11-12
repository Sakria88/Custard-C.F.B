using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Animator animator;
<<<<<<< Updated upstream
    [SerializeField] private bool collapsable;
=======
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
        if (collapsable = true)
        {
            if (collision.gameObject.tag == "Player")
            {
                animator.SetBool("step time", true);

            }
        }
        
=======
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("step time", true);

        }
>>>>>>> Stashed changes

    }
}
