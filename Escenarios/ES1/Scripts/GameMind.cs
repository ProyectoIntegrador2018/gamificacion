using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMind : MonoBehaviour {
    //Esta sera un Script Global
    //Aqui tengo que meter 
    //El Score
    //Las Vidas
    public static GameMind Instance;
    void start () {
        lives= 3;
    }
    void Awake () {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this) {
            Destroy (gameObject);
        }
    }

    public int lives = 3;
    public int score = 0;

    public void takeAwayLive(int l) {
        lives=lives-l; 
        if (lives<=0) {
            SceneManager.LoadScene(3);
        }
    }
    
}
