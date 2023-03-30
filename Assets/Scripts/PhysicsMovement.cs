using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    public enum MovementType { tup, tdown, tleft, tright, tjump }

    public MovementType movementType { get; set; }
    Vector3 p;
    Rigidbody2D rb;

    PhysicsMovement()
    {
        _step = 4f;
    }

    public float jumpTime = 0f;
    public int jumpQ = 0;

    public float _step { get; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
                p = t.position;
                if (jumpQ < 2)
                {
                    jumpTime = 0;
                    jumpQ += 1;
                }
                break;

        }
        t.position = p;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            jumpQ = 0;
        }
    }

    void FixedUpdate()
    {
        if (jumpTime < 0.1f)
        {
            jumpTime += Time.deltaTime;
            rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        }
    }
}