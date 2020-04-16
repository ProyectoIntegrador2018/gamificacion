using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public Sprite[] LivesSprites;
    public Image LivesUI;
    public Text Score;

    void Start()
    {
        Score.text = "0";
    }

    void Update()
    {
        if (GlobalVariables.lives > 0) {
            LivesUI.sprite = LivesSprites[GlobalVariables.lives];
        } else {
            LivesUI.sprite = LivesSprites[0];
        }

        Score.text = GlobalVariables.score.ToString();
        
    }

    public void ResetGame() //TODO Beutify the reset button with a warning
    {
        GlobalVariables.lives = 5;
        GlobalVariables.score = 0;
        SceneManager.LoadScene("P1"); //TODO : Replace for Main Menu
    }

}
