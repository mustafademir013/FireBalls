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
    private void OnEnable()
    {
        CubeController.CubeFinished += DeSpawn;
    }

    private void OnDisable()
    {
        CubeController.CubeFinished -= DeSpawn;
    }

    private void DeSpawn()
    {
        SimplePool.Despawn(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Obstacle")
        {

        }
        else
            DespawnBullet(collision.transform);



    }

    private void DespawnBullet(Transform collisionCube)
    {
        DeSpawn();
        BulletCollision?.Invoke(collisionCube.transform);
    }
}
