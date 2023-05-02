using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    public JoystickMovemente joystickMovement;
    public float playerSpeed;
    private Rigidbody2D rb;
    bool isMoving = false;
    bool beingUsed = false;

    PhysicsMovement m;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m = GetComponent<PhysicsMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (joystickMovement.joystickVec.x < -0.1 || joystickMovement.joystickVec.x > 0.1)
        {
            if (joystickMovement.joystickVec.x < -0.45)
            {
                if (!isMoving)
                {
                    isMoving = true;
                    m.startMov = true;
                }
                m.isLeft = true;
            }
            else if (joystickMovement.joystickVec.x > 0.45)
            {
                if (!isMoving)
                {
                    isMoving = true;
                    m.startMov = true;
                }
                m.isRight = true;
            }
            else
            {
                if (joystickMovement.joystickVec.x != 0)
                {
                    isMoving = false;
                    m.stop = true;
                }
            }
            beingUsed = true;
        }
        if (joystickMovement.joystick.transform.position.x == joystickMovement.joystickOriginalPos.x && joystickMovement.joystick.transform.position.y == joystickMovement.joystickOriginalPos.y && beingUsed)
        {
            isMoving = false;
            m.stop = true;
            beingUsed = false;
        }
    }
}
