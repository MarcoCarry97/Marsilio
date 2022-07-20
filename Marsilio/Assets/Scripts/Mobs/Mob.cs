using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [Range(0, 10)]
    public float acceleration;

    private TurnManager manager;

    void Start()
    {
        //manager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 direction)
    {
        this.transform.Translate(acceleration * direction);
    }
}
