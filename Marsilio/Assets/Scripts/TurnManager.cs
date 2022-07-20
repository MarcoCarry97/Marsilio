using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<Character> characters;

    public List<Enemy> enemies;

    public Mob currentTurn;

    private bool end;

    private int totMobs;

    private int index;

    void Start()
    {
        totMobs = characters.Count + enemies.Count;
        end = false;
        index = 0;
        currentTurn = characters[0];
    }

    void Update()
    {
        changeTurnIfFinished();
        if(!end)
        {
            characterTurn();
            enemyTurn();
        }
    }

    private void enemyTurn()
    {
        if(currentTurn is Enemy)
        {
            
        }
    }

    private void characterTurn()
    {
        if(currentTurn is Character)
        {
            showMoves();
        }
    }

    private void showMoves()
    {
        GameObject canvas = GameObject.Find("Canvas");


    }

    private void changeTurnIfFinished()
    {
        if (end)
        {
            index = (index + 1) % totMobs;
            if (index < characters.Count)
                currentTurn = characters[index];
            else currentTurn = enemies[index % enemies.Count];
        }        
    }

    public void NextTurn()
    {

    }
}
