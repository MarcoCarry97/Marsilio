using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    private static GameState instance;

    public static GameState Instance
    {
        get
        {
            if (instance == null)
                instance = new GameObject("GameState").AddComponent<GameState>();
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startBattle(Enemy enemy)
    {
        SceneManager.LoadScene("BattleScene");
    }

    public void ShowBattleUI()
    {

    }

    public void ShowCharacterBattleUI(Character character)
    {

    }
}
