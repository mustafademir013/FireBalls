using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Environment/EnvironmentData", order = 1)]
public class EnvironmentData : ScriptableObject
{
    [SerializeField] private string _pathFolder;
    public string PathFolder { get => _pathFolder;}

    private Transform _path;
    public Transform Path { get => _path; set => _path = value; }
}
