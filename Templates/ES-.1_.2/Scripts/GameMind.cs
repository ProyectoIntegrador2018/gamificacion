using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMind : MonoBehaviour {

    public static GameMind Instance;
    void start () {
        lives= 3;
    }
    public int lives;
    public int score;

    void Awake () {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this) {
            Destroy (gameObject);
        }
    }
    }

    void Update()
    {

    }
    
}
