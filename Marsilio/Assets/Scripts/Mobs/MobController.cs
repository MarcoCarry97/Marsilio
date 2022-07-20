using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mob))]
public class MobController : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    public KeyCode confirm;
    public KeyCode close;

    public KeyCode start;
    public KeyCode select;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        if (Input.GetKey(up))
            direction.y = 1;
        if (Input.GetKey(down))
            direction.y = -1;
        if (Input.GetKey(left))
            direction.x = -1;
        if (Input.GetKey(right))
            direction.x = 1;
        if(direction.magnitude>0)
        {
            Character character=this.GetComponent<Character>();
            character.Move(direction.normalized);
        }
    }
}
