using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{

    [SerializeField] Config config;
    public enum MovementType { tup, tdown, tleft, tright, tjump, tstop }

    public MovementType movementType { get; set; }
    
    public bool isLeft = false;
    public bool isRight = false;
    public bool isJump = false;
    public bool stop = false;
    public bool startMov = false;
    [SerializeField] Animator anim;
    Vector3 p;
    Rigidbody2D rb;
    GameConfig gc;

    PhysicsMovement()
    {
        _step = 400f;
    }

    public float jumpTime = 0f;
    public int jumpQ = 0;

    public float _step;

    void Awake()
    {
        gc = FindObjectOfType<GameConfig>();
        if (!gc) Debug.LogError("Falta el compoenente GameConfig");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        if (gc.Paused)
        {
            if (startMov)
            {
                anim.SetTrigger("Correr");
                startMov = false;
            }
            if (isRight)
            {
                rb.velocity = new Vector2(1 * _step * Time.deltaTime, rb.velocity.y);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                isRight = false;
                //anim.SetTrigger("Correr");
            }
            if (isLeft)
            {
                rb.velocity = new Vector2(-1 * _step * Time.deltaTime, rb.velocity.y);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                isLeft = false;

                //anim.SetTrigger("Correr");
            
            }
            if (stop)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                stop = false;
                anim.SetTrigger("Idle");
            }
            if (isJump)
            {
                isJump = false;
                if (jumpQ == 1)
                {
                    rb.velocity = new Vector2(0, 1.2f) * _step * Time.deltaTime;
                }
                if (jumpQ < 2)
                {
                    rb.AddForce(Vector2.up * 3.2f * _step, ForceMode2D.Force);
                    jumpTime = 0f;
                    jumpQ += 1;
                }
            }
        }
    }
}