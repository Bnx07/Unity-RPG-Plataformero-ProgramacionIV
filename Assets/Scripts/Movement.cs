/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public enum MovementType { tup, tdown, tleft, tright, tjump }

    public MovementType movementType { get; set; }
    Vector3 p;

    Movement()
    {
        _step = 4f;
        _jumpForce = 2f;
        _jumpTime = 0.2f;
    }

    public bool jumping = false;
    public float jumpProgress = 0f;
    public float jumpRoof = 0f;

    public float _step { get; }
    public float _jumpForce { get; }
    public float _jumpTime { get; }

    public void Move(Transform t, MovementType tm)
    {
        switch (tm)
        {
            case MovementType.tup:
                p = new Vector3(t.position.x, t.position.y + _step * Time.deltaTime);
                break;
            case MovementType.tdown:
                p = new Vector3(t.position.x, t.position.y - _step * Time.deltaTime);
                break;
            case MovementType.tleft:
                p = new Vector3(t.position.x - _step * Time.deltaTime, t.position.y);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case MovementType.tright:
                p = new Vector3(t.position.x + _step * Time.deltaTime, t.position.y);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case MovementType.tjump:
                if (!jumping)
                {
                    jumping = true;
                    jumpProgress = 0f;
                    jumpRoof = t.position.y + _jumpForce;
                }
                p = t.position;
                break;
        }
        t.position = p;
    }

    void Update()
    {
        if (jumping == true)
        {
            jumpProgress += Time.deltaTime;
            if (jumpProgress < _jumpTime)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, jumpRoof), _jumpForce * jumpProgress * 0.2f);
            }
            else
            {
                jumping = false;
            }

        }
    }
}*/