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
    Movement m;

    private void Awake()
    {
        t = GetComponent<Transform>();
        m = GetComponent<Movement>();
    }

    void Update()
    {
        try
        {
            if (Input.GetKey(_up))
            {
                m.Move(t, Movement.MovementType.tup);
            }
            if (Input.GetKey(_down))
            {
                m.Move(t, Movement.MovementType.tdown);
            }
            if (Input.GetKey(_left))
            {
                m.Move(t, Movement.MovementType.tleft);
            }
            if (Input.GetKey(_right))
            {
                m.Move(t, Movement.MovementType.tright);
            }
            if (Input.GetKeyDown(_jump))
            {
                m.Move(t, Movement.MovementType.tjump);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error in code");
        }

    }
}