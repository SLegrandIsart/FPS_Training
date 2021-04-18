using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerController))]
public class PlayerCrouch : MonoBehaviour
{
    private PlayerController m_controller;
    private CapsuleCollider  m_capsule;

    //  Temp variables, for prototype
    private Transform m_renderer;

    //  Temp variables, for prototype
    private Camera m_cam;

    private float m_croucCaphHeight;
    private float m_defaultCapHeight;

    private Vector3 m_crouchCapPos;
    private Vector3 m_defaultCapPos;

    private bool m_isCrouch;

    private void Awake()
    {
        m_controller = GetComponent<PlayerController>();
        m_capsule = GetComponent<CapsuleCollider>();
        m_cam = GetComponentInChildren<Camera>();
        m_renderer = transform.GetChild(1);

        m_defaultCapHeight = m_capsule.height;
        m_croucCaphHeight = m_defaultCapHeight / 2f;

        m_defaultCapPos = m_capsule.center;
        m_crouchCapPos = m_defaultCapPos - m_croucCaphHeight * .5f * Vector3.up;
    }

    private void Update()
    {
        if(m_controller.m_crouch)
        {
            Crouch();
        }
        else
        {
            UnCrouch();
        }
    }

    private void Crouch()
    {
        if(m_isCrouch == false)
        {
            //  Collider Resize

            m_capsule.height = m_croucCaphHeight;
            m_capsule.center = m_crouchCapPos;


            /* For prototype only, will be removed later, when model and animations will be implemented*/

            //  Camera

            m_cam.transform.localPosition = Vector3.zero;

            //  Renderer

            m_renderer.transform.localScale = new Vector3(1f, .5f, 1f);
            m_renderer.transform.localPosition = new Vector3(0f, -.5f, 0f);

            /*----------------------------------------------------------------------------------------*/

            m_isCrouch = true;
        }
    }

    private void UnCrouch()
    {
        if (m_isCrouch == true)
        {
            //  Collider Resize

            m_capsule.height = m_defaultCapHeight;
            m_capsule.center = m_defaultCapPos;

            /* For prototype only, will be removed later, when model and animations will be implemented*/

            //  Camera

            m_cam.transform.localPosition = new Vector3(0f,.5f,0f);
            //  Renderer

            m_renderer.transform.localScale = new Vector3(1f, 1f, 1f);
            m_renderer.transform.localPosition = new Vector3(0f, 0f, 0f);

            /*----------------------------------------------------------------------------------------*/

            m_isCrouch = false;
        }
    }
}
