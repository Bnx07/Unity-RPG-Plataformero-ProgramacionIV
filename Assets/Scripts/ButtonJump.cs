using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJump : MonoBehaviour
{
    public PhysicsMovement physicsMovement;
    //PhysicsMovement m;

    void Start()
    {
        //m = GetComponent<PhysicsMovement>();
    }

    public void Jump()
    {
        physicsMovement.isJump = true;
    }
}
