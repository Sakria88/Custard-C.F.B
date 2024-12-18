using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform Target;

    [SerializeField] private float shootRate;
    [SerializeField] private float projectileMoveSpeed;

    [SerializeField] private AnimationCurve trajectory;
    private float shootTimer;

    public Pc2 Player;



    // Start is called before the first frame update
    void Start()
    {
        Player = FindAnyObjectByType<Pc2>();
    }

    // Update is called once per frame
    void Update()
    {

        if (shootTimer < 0)
        {
            Debug.Log("Shot");
            shootTimer = shootRate;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().InitializeProjectile(Target, projectileMoveSpeed);
            projectile.GetComponent<Projectile>().InitializeCurve(trajectory);

        }

    }
}
