using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;

    void Start()
    {
        PreLoadBullet();
    }

    private void PreLoadBullet()
    {
        SimplePool.Preload(_bullet, 10);
    }

}
