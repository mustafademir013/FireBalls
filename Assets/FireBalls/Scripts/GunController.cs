using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private InputData inputData;
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private int bulletCount;
    [SerializeField] private Transform bulletSpawnTransform;

    private float _timer = 0;

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
        SimplePool.Preload(bulletPref, 50);
    }

    public void Shot()
    {
        SimplePool.Spawn(bulletPref, bulletSpawnTransform.position, bulletPref.transform.rotation);
    }


}
