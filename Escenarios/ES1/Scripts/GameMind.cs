using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase donde las funciones son publicas a lo largo de las escenas - vidas y puntaje -
public class GameMind : MonoBehaviour {

    // Instancia de la clase
    public static GameMind Instance;    

    // Función para quitar vidas
    public static void takeAwayLive(int l) {
        GlobalVariables.lives = GlobalVariables.lives-l;
        Debug.Log("Vidas" + GlobalVariables.lives);
    }

    // Función para sumar o restar puntos
    public static void addPoints(int n) {
    	Debug.Log(n);
    	GlobalVariables.score = GlobalVariables.score+n;
    	Debug.Log("Puntaje " + GlobalVariables.score);
    }

}
