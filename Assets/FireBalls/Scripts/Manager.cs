using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] CubeController cubeController;
    [SerializeField] GunController gunController;
    [SerializeField] Transform[] pathCircles;
    private int _circleIndex;
    // Start is called before the first frame update
    void Start()
    {
        cubeController.PreLoadCubes();
        gunController.PreLoadBullet();
        _circleIndex = 0;
        Load();
    }

    private void Load()
    {
        Transform cubeParent = cubeController.SpawnLevelCubes(pathCircles[_circleIndex]);
        cubeController.TranslateCubes(cubeParent.childCount);
        
    }


}
