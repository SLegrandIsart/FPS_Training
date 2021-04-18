using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_mouseSensitivity = 90f;
    [SerializeField] private bool  m_toggleSprint = false;
    [SerializeField] private bool  m_toggleCrouch = false;

    [HideInInspector]
    public float m_xAxis = 0f;

    [HideInInspector]
    public float m_yAxis = 0f;

    [HideInInspector]
    public float m_xMovement = 0f;

    [HideInInspector]
    public float m_yMovement = 0f;

    [HideInInspector]
    public bool m_sprint = false;

    [HideInInspector]
    public bool m_jump = false;

    [HideInInspector]
    public bool m_crouch = false;

    // Update is called once per frame
    void Update()
    {
        m_xAxis = Input.GetAxis("Mouse X") * m_mouseSensitivity;
        m_yAxis = Input.GetAxis("Mouse Y") * m_mouseSensitivity;

        m_xMovement = Input.GetAxis("Horizontal") * m_mouseSensitivity;
        m_yMovement = Input.GetAxis("Vertical") * m_mouseSensitivity;

        m_jump = Input.GetButtonDown("Jump");

        // TODO -> Change the following inputs to buttons in inputs manager (Crouch, and Sprint)

        if (!m_toggleCrouch)
        {
            m_crouch = Input.GetKey(KeyCode.LeftControl);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            m_crouch = !m_crouch;
        }


        if (!m_toggleSprint)
        {
            m_sprint = Input.GetKey(KeyCode.LeftShift);
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_sprint = !m_sprint;
        }
    }
}
