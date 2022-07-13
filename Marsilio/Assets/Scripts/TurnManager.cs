using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private List<int> moves;

    private int currentMove;

    private bool end;

    // Start is called before the first frame update
    void Start()
    {
        moves = new List<Mob>();
        end = false;
        currentMove = 1; 
    }

    // Update is called once per frame
    void Update()
    {
        if(end)
        {

        }
    }

    private void ShowSelectPanel()
    {

    }

    private void EndTurn()
    {
        end = true;
    }
}
