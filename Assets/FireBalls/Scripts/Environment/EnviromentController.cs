using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    [SerializeField] private Transform _enviromentTr;

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
