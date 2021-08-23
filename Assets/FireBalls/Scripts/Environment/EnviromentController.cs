using System;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{

    public static event Action PathSpawned; 


    [SerializeField] private IntValue _levelNumber;
    [SerializeField] private EnvironmentData _environmentData;
    [SerializeField] private IntValue _gunData;

    private void Start()
    {
        SpawnPath();
        SpawnGun();
        SpawnPlane();
    }
    public void SpawnPath()
    {
        string path = _environmentData.PlatformPath + _levelNumber.Value.ToString();
        _environmentData.CurrentPlatform = Instantiate(Resources.Load<GameObject>(path)).transform;
        _environmentData.CurrentPlatform.transform.parent = transform;
        _environmentData.CurrentPlatform.transform.localPosition = Vector3.zero;
        PathSpawned?.Invoke();
    }
    public void SpawnGun()
    {
        string path = _environmentData.GunPath + _gunData.Value.ToString();
        _environmentData.CurrentGun = Instantiate(Resources.Load<GameObject>(path)).transform;
        _environmentData.CurrentGun.transform.position = new Vector3(0,0,1);
    }
    public void SpawnPlane()
    {
        string path = _environmentData.PlanePath + _levelNumber.Value.ToString();
        _environmentData.CurrentPlane = Instantiate(Resources.Load<GameObject>(path)).transform;
        _environmentData.CurrentPlane.transform.parent = transform;
        _environmentData.CurrentPlane.transform.localPosition = Vector3.zero;
    }
    private void OnEnable()
    {
        CubeController.CubeFinished += Rotate;
    }

    private void OnDisable()
    {
        CubeController.CubeFinished -= Rotate;
    }
    private void Rotate()
    {
        //float angle = circlePaths[_circleIndex].parent.rotation.y;
        // enviromentTr.RotateAround(circlePaths[_circleIndex].position, Vector3.up, angle);
    }
}
