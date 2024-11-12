using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstLevel : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider slider;
    public float progress = 1;
    [SerializeField] public float barSpeed;

    // Start is called before the first frame update
    void Start()
    {
        loadingscreen.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = progress;
        if (progress < 60)
        {
            barSpeed = 10;
            progress = progress + Time.deltaTime * barSpeed;

        }

        if (progress > 60 && progress < 65)
        {
            barSpeed = 2;
            progress = progress + Time.deltaTime * barSpeed;

        }
        if (progress > 65 && progress < 80)
        {
            barSpeed = 7;
            progress = progress + Time.deltaTime * barSpeed;
        }
        if (progress > 80)
        {
            barSpeed = 10;
            progress = progress + Time.deltaTime * barSpeed;
        }

        if (progress >= 100)
        {
            SceneManager.LoadSceneAsync(1);
        }
        
    }
}
