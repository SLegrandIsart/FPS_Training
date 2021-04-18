using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerJump : MonoBehaviour
{
    private CapsuleCollider  m_capsule;
    private PlayerController m_controller;
    private Rigidbody        m_rigidbody;

    [SerializeField] private float m_jumpForce = 7.5f;
    [SerializeField] private float m_fallingMultiplier = .5f;

    private LayerMask m_grouncCheckLayerMask;

    private void Awake()
    {
        m_capsule    = GetComponent<CapsuleCollider>();
        m_controller = GetComponent<PlayerController>();
        m_rigidbody  = GetComponent<Rigidbody>();

        m_grouncCheckLayerMask = ~(LayerMask.GetMask("Player"));
    }

    // Update is called once per frame
    void Update()
    {
        if(m_controller.m_jump && CheckGround())
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if(m_rigidbody.velocity.y < 0f)
        {
            m_rigidbody.velocity += Vector3.down * m_fallingMultiplier;
        }
    }

    private void Jump()
    {
        m_rigidbody.velocity += m_jumpForce * Vector3.up;
    }


    private bool CheckGround()
    {
        float marge = .05f;

        Vector3 startPos = transform.position + m_capsule.center + (m_capsule.height * .5f - marge) * Vector3.down;

        Vector3 dir01 = (Vector3.down + Vector3.right)*.5f;
        Vector3 dir02 = (Vector3.down + Vector3.left)*.5f;
        Vector3 dir03 = (Vector3.down + Vector3.forward)*.5f;
        Vector3 dir04 = (Vector3.down + Vector3.back)*.5f;

        return  Physics.Raycast(startPos, dir01, 1f, m_grouncCheckLayerMask) ||
                Physics.Raycast(startPos, dir02, 1f, m_grouncCheckLayerMask) ||
                Physics.Raycast(startPos, dir03, 1f, m_grouncCheckLayerMask) ||
                Physics.Raycast(startPos, dir04, 1f, m_grouncCheckLayerMask) ; 
    }
}
