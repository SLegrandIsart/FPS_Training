using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 90f;

    public float xAxis = 0f;
    public float yAxis = 0f;


    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Mouse X") * mouseSensitivity;
        yAxis = Input.GetAxis("Mouse Y") * mouseSensitivity;
    }
}
