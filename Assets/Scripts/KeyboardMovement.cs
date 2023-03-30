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
            if (Input.GetKey(_up))
            {
                m.Move(t, PhysicsMovement.MovementType.tup);
            }
            if (Input.GetKey(_down))
            {
                m.Move(t, PhysicsMovement.MovementType.tdown);
            }
            if (Input.GetKey(_left))
            {
                m.Move(t, PhysicsMovement.MovementType.tleft);
            }
            if (Input.GetKey(_right))
            {
                m.Move(t, PhysicsMovement.MovementType.tright);
            }
            if (Input.GetKeyDown(_jump))
            {
                m.Move(t, PhysicsMovement.MovementType.tjump);
            }
        }
        catch (Exception)
        {
            Debug.LogError("Error in code");
        }

    }
}