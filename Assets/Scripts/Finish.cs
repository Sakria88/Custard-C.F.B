using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Pc2 player;
    public water water;
    public float mimer;
    public bool Timers;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Timers == true)
        {
            mimer = mimer + Time.deltaTime;
        }
        if (mimer > 20)
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player");
            water.waterspeed = 0;
            Timers = true;
        }

    }
}
