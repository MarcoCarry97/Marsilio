using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(SpriteRenderer))]
public abstract class Mob : MonoBehaviour
{
    // Start is called before the first frame update

    [Range(0, 1000)]
    public int life;

    [Range(0, 1000)]
    public int attack;

    [Range(0, 1000)]
    public int defense;

    [Range(0, 1000)]
    public int speed;

    public string Name { get; set; }

    [Range(0, 5)]
    public float acceleration;

    [Range(0, 5)]
    public float footSpeed;

    Vector2 currentVelocity;

    private Rigidbody2D rigid;

    private SpriteRenderer renderer;

    private float velocity;

    private float step;

    private Vector3 lastMove;

    enum State
    {
        Idle,
        Move
    }

    State state;

    void Start()
    {
        //manager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
        rigid = this.GetComponent<Rigidbody2D>();
        renderer = this.GetComponent<SpriteRenderer>();
        state= State.Idle;
        velocity = 0;
        step = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        print("lastMove " + lastMove);
        switch (state)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Move:
                MoveState();
                break;
        }
    }

    private void IdleState()
    {
        if(lastMove!=Vector3.zero)
        {
            Vector3 start = this.transform.position;
            Vector3 end = start + lastMove;
            float distance = (end - start).magnitude;
            velocity = 0;
            lastMove = Vector3.zero;
            state = State.Move;
        }
    }

    private void MoveState()
    {
        float dt = Time.deltaTime;
        velocity = Mathf.Clamp01(velocity + acceleration * dt);
        rigid.velocity = Vector2.SmoothDamp(rigid.velocity, lastMove * footSpeed, ref currentVelocity, acceleration, footSpeed);
    }

    public void Move(Vector3 direction)
    {
        lastMove = direction.normalized * step;
    }
}
