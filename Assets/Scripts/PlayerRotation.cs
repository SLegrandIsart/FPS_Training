using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerRotation : MonoBehaviour
{
    float m_hMove = 0f;

    private PlayerController m_controller = null;

    private void Awake()
	{
        m_controller = GetComponentInParent<PlayerController>();
    }

	private void Start()
	{
        m_hMove = transform.eulerAngles.y;
    }

    void Update()
    {
        m_hMove += m_controller.m_xAxis * Time.deltaTime;
    }

    private void FixedUpdate()
	{
        transform.rotation = Quaternion.Euler(0f, m_hMove, 0f);
    }
}
