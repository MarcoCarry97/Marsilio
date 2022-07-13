using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenPanel : MonoBehaviour
{
    private Button play;

    // Start is called before the first frame update

    void Start()
    {
        play = this.transform.GetChild(1).GetComponent<Button>();
        play.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        SceneManager.LoadScene("PlayScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
