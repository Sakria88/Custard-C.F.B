using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    [SerializeField] public int healamount;

    public void Pickup()
    {
        Destroy(gameObject);
    }

}
