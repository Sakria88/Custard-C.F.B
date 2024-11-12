using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    [SerializeField] public int healamount;
    public Pc2 playerHealth;




    private void Awake()
    {
        playerHealth = FindAnyObjectByType<Pc2>();
    }

    public void Pickup()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collide");
        if (playerHealth.currentHealth < playerHealth.maxHealth)
        {
            Debug.Log("Brail");
            playerHealth.Heal(healamount);
            Destroy(gameObject);

        }
    }


}
