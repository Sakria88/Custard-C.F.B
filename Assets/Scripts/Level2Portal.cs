using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level2Portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pc2 player = other.GetComponent<Pc2>();
            if (player != null && player.itemsCollected >= 2)
            {
                SceneManager.LoadSceneAsync("MiniBCutscene");
            }
            else
            {
                Debug.Log("You need to collect the required item to enter!");
            }
        }
    }
}
