using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    float hMove = 0f;

    private PlayerController controller = null;

    private void Awake()
	{
        controller = GetComponentInParent<PlayerController>();
    }

	private void Start()
	{
        hMove = transform.eulerAngles.y;
    }

    void Update()
    {
        hMove += controller.xAxis * Time.deltaTime;
    }

    private void FixedUpdate()
	{
        transform.rotation = Quaternion.Euler(0f, hMove, 0f);
    }
}
