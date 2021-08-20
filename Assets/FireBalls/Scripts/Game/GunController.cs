using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : MonoBehaviour
{
    [SerializeField] private InputData _inputData;
    [SerializeField] private BoolValue _gunActive;

    [SerializeField] private GameObject _bulletPref;
    [SerializeField] private Transform _bulletSpawnTransform;

    private float _timer = 0;

    private void Start()
    {
        _gunActive.Value = false;
    }
    private void Update()
    {
        if (_timer <= 0)
        {
            if (_inputData.TouchCount > 0)
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
        SimplePool.Preload(_bulletPref, 10);
    }

    public void Shot()
    {
        if (_gunActive.Value)
            SimplePool.Spawn(_bulletPref, _bulletSpawnTransform.position, transform.rotation);
    }

    /*public void Translate()
    {
        _active = false;
        transform.DOMoveZ();
    }*/
}
