using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform target;
    public Vector3 offset;

    [Range(0,10)]
    public float smoothness;

    private void LateUpdate()
    {
        follow();
        if (rb.velocity.x > 0.1)
        {
            offset = new Vector3(3, 0, -10);
        }
        if (rb.velocity.x < -0.1)
        {
            offset = new Vector3(-3, 0, -10);
        }



    }

    void follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
        transform.position = smoothPosition;
    }

   

}
