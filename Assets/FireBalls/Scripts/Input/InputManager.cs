using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private InputData _inputData;
    // Update is called once per frame
    private void Start()
    {
        _inputData.TouchCount = 0;
    }
    void Update()
    {

#if UNITY_ANDROID||UNITY_IOS

        _inputData.TouchCount = Input.touchCount;
#else
        if (Input.GetKeyDown("space"))
        {
            _inputData.TouchCount = 1;
        }
         if (Input.GetKeyUp("space"))
        {
            _inputData.TouchCount = 0;
        }
#endif

    }
}
