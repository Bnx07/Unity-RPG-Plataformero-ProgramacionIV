using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] KeyCode _up;
    [SerializeField] KeyCode _down;
    [SerializeField] KeyCode _left;
    [SerializeField] KeyCode _right;

    [SerializeField] KeyCode _jump;

    Transform t;
    PhysicsMovement m;

    private void Awake()
    {
        t = GetComponent<Transform>();
        m = GetComponent<PhysicsMovement>();
    }

    void Update()
    {
        try
        {
            if (Input.GetKeyDown(_left))
            {
                m.startMov = true;
            }
            if (Input.GetKeyDown(_right))
            {
                m.startMov = true;
            }
            if (Input.GetKey(_left))
            {
                m.isLeft = true;
            }
            if (Input.GetKey(_right))
            {
                m.isRight = true;
            }
            if (Input.GetKeyUp(_right))
            {
                m.stop = true;
            }
            if (Input.GetKeyUp(_left))
            {
                m.stop = true;
            }
            if (Input.GetKeyDown(_jump))
            {
                m.isJump = true;
            }
        }
        catch (Exception)
        {
            Debug.LogError("Error in code");
        }

    }
}