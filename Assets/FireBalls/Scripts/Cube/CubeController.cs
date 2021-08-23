using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CubeController : MonoBehaviour
{

    public static event Action CubeFinished;

    [SerializeField] private BoolValue _gunActive;
    [SerializeField] FloatValue _translateTime;

    [SerializeField] private GameObject[] _cubePrefabs;
    [SerializeField] private EnvironmentData _environmentData;

    private Transform _cubeParent;

    private void Start()
    {
        _cubeParent = transform;
        PreLoadCubes();
    }

    private void OnEnable()
    {
        Bullet.BulletCollision += DespawnCube;
    }
    private void OnDisable()
    {
        Bullet.BulletCollision -= DespawnCube;
    }
    public void PreLoadCubes()
    {
        foreach (var item in _cubePrefabs)
            SimplePool.Preload(item, 50);
    }
    private Transform SpawnLevelCubes(Transform circleTr)
    {
        int rnd = UnityEngine.Random.Range(25, 35);
        Vector3 pos = circleTr.position;
        GameObject spawnCube;

        for (int i = 0; i < rnd; i++)
        {
            foreach (var item in _cubePrefabs)
            {
                spawnCube = SimplePool.Spawn(item, pos, item.transform.rotation);
                pos.y -= _cubePrefabs[0].transform.localScale.y;
                spawnCube.transform.parent = _cubeParent.transform;
            }
        }
        return _cubeParent;
    }
    public void TranslateCubes(int cubesCount)
    {
        float height = _cubePrefabs[0].transform.localScale.y * cubesCount;
        float endPointY = _cubeParent.localPosition.y + height;
        float time = cubesCount * _translateTime.Value;
        _cubeParent.DOMoveY(endPointY, time).
            OnComplete(() => _gunActive.Value = true);
    }
    private void TranslateCubes()
    {
        float height = _cubePrefabs[0].transform.localScale.y;
        float endPointY = _cubeParent.localPosition.y - height;
        _cubeParent.position = new Vector3(_cubeParent.position.x, endPointY, _cubeParent.position.z);
    }
    private void DespawnCube(Transform cubeTransform)
    {
        SimplePool.Despawn(cubeTransform.gameObject);
        cubeTransform.parent = null;
        TranslateCubes();
        if (_cubeParent.childCount <= 0)
        {
            _gunActive.Value = false;
            CubeFinished?.Invoke();
        }
    }
}
