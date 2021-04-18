using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovements : MonoBehaviour
{
    private Rigidbody m_rb;
    private PlayerController m_controller;

    [SerializeField] private float m_speed = 5;
    [SerializeField] private float m_sprintAcceleration = 1.5f;
    [SerializeField] private float m_crouchDeceleration = .5f;

    private Vector2 m_direction;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        m_controller = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        SetDirection();

        m_rb.velocity = (m_direction.x * transform.right + m_direction.y * transform.forward) * GetSpeed() + m_rb.velocity.y * Vector3.up;
    }

    private void SetDirection()
    {
        //  Get direction from player input
        m_direction = new Vector3(m_controller.m_xMovement, m_controller.m_yMovement);

        //  Square length of the direction
        float directionSqrLength = m_direction.sqrMagnitude;

        //  Is the length below one so the player does not speed up when moving on diagonals
        if (directionSqrLength > 1)
        {
            m_direction = m_direction.normalized;
        }
    }

    private float GetSpeed()
    {
        float speed = m_speed;

        if(m_controller.m_crouch)
        {
            speed *= m_crouchDeceleration;
        }
        else if (m_controller.m_sprint)
        {
            speed *= m_sprintAcceleration;
        }

        return speed;
    }
}
