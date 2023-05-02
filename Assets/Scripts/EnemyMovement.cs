using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    Transform t;
    Rigidbody2D rb;
    PhysicsMovement m;
    [SerializeField] float closeDistance;
    [SerializeField] float farDistance;
    [SerializeField] bool isAnimating; // Hacer que si no esta activa se active en el hit
    [SerializeField] Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        m = GetComponent<PhysicsMovement>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        closeDistance = 1.2f;
        m._step = 200f;
        farDistance = 4f;
    }

    void Update()
    {
        RaycastHit2D hitLeft = Physics2D.Linecast(new Vector2(t.position.x - closeDistance, t.position.y), new Vector2(t.position.x - farDistance, t.position.y));
        
        if (hitLeft)
        {
            string tag = hitLeft.collider.gameObject.tag;
            if (tag == "Player")
            {
                m.isLeft = true;
                if (!isAnimating)
                {
                    isAnimating = true;
                    anim.SetTrigger("Correr");
                }
            }
        }

        RaycastHit2D hitRight = Physics2D.Linecast(new Vector2(t.position.x + closeDistance, t.position.y), new Vector2(t.position.x + farDistance, t.position.y));

        if (hitRight)
        {
            string tag = hitRight.collider.gameObject.tag;
            if (tag == "Player")
            {
                m.isRight = true;
                if (!isAnimating)
                {
                    isAnimating = true;
                    anim.SetTrigger("Correr");
                }
            }
        }

        RaycastHit2D attackRight = Physics2D.Linecast(new Vector2(t.position.x + 0.5f, t.position.y), new Vector2(t.position.x + closeDistance, t.position.y));
        if (attackRight)
        {
            string tag = attackRight.collider.gameObject.tag;
            if (tag == "Player")
            {
                Debug.Log("In Range");
            }
        }

        RaycastHit2D attackLeft = Physics2D.Linecast(new Vector2(t.position.x - 0.5f, t.position.y), new Vector2(t.position.x - closeDistance, t.position.y));
        if (attackLeft)
        {
            string tag = attackLeft.collider.gameObject.tag;
            if (tag == "Player")
            {
                Debug.Log("In Range");
            }
        }

        if (!hitLeft && !hitRight)
        {
            isAnimating = false;
            anim.SetTrigger("Idle");
        }

    }
}
