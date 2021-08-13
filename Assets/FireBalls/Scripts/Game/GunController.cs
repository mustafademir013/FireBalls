using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : MonoBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private int bulletCount;
    [SerializeField] private Transform bulletSpawnTransform;

    private float _timer = 0;
    private bool _active;

    private void Start()
    {
        _active = true;
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void Update()
    {
        if (_timer <= 0)
        {
            if (inputData.touchCount > 0)
            {
                Shot();
                _timer = 0.1f;
            }
        }
        else
            _timer -= Time.deltaTime;
    }

    public void PreLoadBullet()
    {
        SimplePool.Preload(bulletPref, 10);
    }

    public void Shot()
    {
        if (_active)
            SimplePool.Spawn(bulletPref, bulletSpawnTransform.position, transform.rotation);
    }

    /*public void Translate()
    {
        _active = false;
        transform.DOMoveZ();
    }*/
}
