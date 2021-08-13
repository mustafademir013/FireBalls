using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public static event Action<Transform> BulletCollision;

    private static readonly float bulletSpeed = -15;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.velocity = new Vector3(0, 0, 1) * bulletSpeed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        DespawnBullet(collision.transform);
    }

    private void DespawnBullet(Transform collisionCube)
    {
        SimplePool.Despawn(gameObject);
        BulletCollision?.Invoke(collisionCube.transform);
    }
}
