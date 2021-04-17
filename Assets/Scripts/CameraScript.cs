using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float yMax = 90f;

    [SerializeField] private float sensitivity = 90f;

    float xAxis = 0f;

    float vMove = 0f;

    void Update()
    {
        xAxis = Input.GetAxis("Mouse Y");

        vMove = transform.eulerAngles.x;
    }

    private void FixedUpdate()
	{
        vMove -= xAxis * sensitivity * Time.fixedDeltaTime;

        vMove = Mathf.Clamp(Mathf.Repeat(vMove + 180, 360) - 180, -yMax, yMax);

        transform.localRotation = Quaternion.Euler(vMove, 0f, 0f);
    }
}