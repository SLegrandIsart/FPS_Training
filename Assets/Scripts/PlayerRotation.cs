using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float sensitivity = 90f;

    float yAxis = 0f;

    float hMove = 0f;

    // Update is called once per frame
    void Update()
    {
        yAxis = Input.GetAxis("Mouse X");

        hMove = transform.eulerAngles.y;
    }

    private void FixedUpdate()
	{
        hMove += yAxis * sensitivity * Time.fixedDeltaTime;

        transform.rotation = Quaternion.Euler(0f, hMove, 0f);
    }
}
