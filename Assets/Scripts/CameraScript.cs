using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float yMax = 90f;

    float vMove = 0f;

    private PlayerController controller = null;

	private void Awake()
	{
        controller = GetComponentInParent<PlayerController>();
    }

    void Start()
    {
        vMove = transform.eulerAngles.x;
    }

	private void Update()
	{
        vMove -= controller.yAxis * Time.deltaTime;

        vMove = Mathf.Clamp(Mathf.Repeat(vMove + 180, 360) - 180, -yMax, yMax);
    }

	private void FixedUpdate()
	{
        transform.localRotation = Quaternion.Euler(vMove, 0f, 0f);
    }
}