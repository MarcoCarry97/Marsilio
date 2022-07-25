using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandController : MonoBehaviour
{
    public KeyCode up,left,down, right;
    public KeyCode start, select;

    private Character mainCharacter;

    private float step;

    public enum State
    {
        CharacterControl,
        DialogControl,
        Pause

    }

    State state;

    // Start is called before the first frame update
    void Start()
    {
        mainCharacter=GameObject.Find("MainCharacter").GetComponent<Character>();
        state=State.CharacterControl;
        step = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.DialogControl: DialogControl(); break;
            case State.CharacterControl: CharacterControl(); break;
        }
    }

    private void CharacterControl()
    {
        Vector3 direction = Vector3.zero;
        if(Input.anyKey)
        {
            if (Input.GetKey(up))
                direction.y = 1;
            if (Input.GetKey(left))
                direction.x = -1;
            if (Input.GetKey(down))
                direction.y = -1;
            if (Input.GetKey(right))
                direction.x = 1;
        }
        else direction=Vector3.zero;
        mainCharacter.Move(direction);
    }

    private void DialogControl()
    {

    }

    public void ChangeState(State s)
    {
        state = s;
    }
}
