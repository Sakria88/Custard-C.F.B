using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private Vector3 targetPosition;
    private float moveSpeed;

    private float DistanceToDestroy = 1f;

    private AnimationCurve trajectory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {


            Vector3 moveDirNormalized = (target.position - transform.position).normalized;
            transform.position += moveDirNormalized * moveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, target.position) < DistanceToDestroy)
            {
                Destroy(gameObject);
            }
        }
    }


    public void InitializeProjectile(Transform target, float moveSpeed)
    {
        this.target = target;
        //this.targetPosition = target.position + Vector3.down;
        this.moveSpeed = moveSpeed;
    }

    public void InitializeCurve(AnimationCurve trajectory)
    {
        this.trajectory = trajectory;
    }
}
