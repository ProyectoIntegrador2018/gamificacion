using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMind : MonoBehaviour {

    public static GameMind Instance;
    // public int score = 0;
    

    public static void takeAwayLive(int l) {
        
    }

    public static void addPoints(int n) {
    	Debug.Log(n);
    	GlobalVariables.score = GlobalVariables.score+n;
    	Debug.Log("Puntaje " + GlobalVariables.score);
    }

}
