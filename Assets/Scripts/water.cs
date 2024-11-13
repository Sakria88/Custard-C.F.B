using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class water : MonoBehaviour
{
    public Pc2 player;
    [SerializeField] public float waterspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = this.transform.position + new Vector3(0, waterspeed, 0) * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player");
            SceneManager.LoadSceneAsync("Game Over");
        }
    }

}
