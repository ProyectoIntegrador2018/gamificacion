using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] LivesSprites;
    public Image LivesUI;
    public Text Score;

    void Start()
    {
        
    }

    void Update()
    {
        

        Score.text = GlobalVariables.score.ToString();
        
    }
}
