using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Environment/EnvironmentData", order = 1)]
public class EnvironmentData : ScriptableObject
{
    [SerializeField] private string _platformPath;
    public string PlatformPath { get => _platformPath;}

    [SerializeField] private string _planePath;
    public string PlanePath { get => _planePath; }

    [SerializeField] private string _gunPath;
    public string GunPath { get => _gunPath;}


    private Transform _currentPlatformPath;
    public Transform CurrentPlatform { get => _currentPlatformPath; set => _currentPlatformPath = value; }

    private Transform _currentGun;
    public Transform CurrentGun { get => _currentGun; set => _currentGun = value; }

    private Transform _currentPlane;
    public Transform CurrentPlane { get => _currentPlane; set => _currentPlane = value; }
}
