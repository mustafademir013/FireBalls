using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CubeController : MonoBehaviour
{

    [SerializeField] private GameObject[] cubePrefabs;
    [SerializeField] private Transform cubeParent;
    [SerializeField] float translateTime = 0.001f;

    private void OnEnable()
    {
        BulletController.BulletCollision += DespawnCube;
    }
    private void OnDisable()
    {
        BulletController.BulletCollision -= DespawnCube;
    }
    public void PreLoadCubes()
    {
        foreach (var item in cubePrefabs)
            SimplePool.Preload(item, 50);
    }
    public Transform SpawnLevelCubes(Transform circleTr)
    {
        int rnd = Random.Range(25, 35);
        Vector3 pos = circleTr.position;
        GameObject spawnCube;

        for (int i = 0; i < rnd; i++)
        {
            foreach (var item in cubePrefabs)
            {
                spawnCube = SimplePool.Spawn(item, pos, item.transform.rotation);
                pos.y -= cubePrefabs[0].transform.localScale.y;
                spawnCube.transform.parent = cubeParent.transform;
            }
        }
        return cubeParent;
    }
    public void TranslateCubes(int cubesCount)
    {
        float height = cubePrefabs[0].transform.localScale.y * cubesCount;
        float endPointY = cubeParent.localPosition.y + height;
        float time = cubesCount * translateTime;
        cubeParent.DOMoveY(endPointY, time);
    }
    private void DespawnCube(Transform cubeTransform)
    {
        SimplePool.Despawn(cubeTransform.gameObject);
        TranslateCubes(-1);
    }
}
