using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private InputData inputData;
    // Update is called once per frame
    private void Start()
    {
        inputData.touchCount = 0;
    }
    void Update()
    {

#if UNITY_ANDROID||UNITY_IOS

        inputData.touchCount = Input.touchCount;
#else
        if (Input.GetKeyDown("space"))
        {
            inputData.touchCount = 1;
        }
         if (Input.GetKeyUp("space"))
        {
            inputData.touchCount = 0;
        }
#endif

    }
}
