using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    [SerializeField] private Transform pathParent;
    [SerializeField] private Transform[] circlePaths;

    private int _circleIndex;

    void Start()
    {
        _circleIndex = 0;
    }

    private void RotatePath()
    {
        float angle = circlePaths[_circleIndex].parent.rotation.y;
        pathParent.RotateAround(circlePaths[_circleIndex].position, Vector3.up, angle);
    }




}
