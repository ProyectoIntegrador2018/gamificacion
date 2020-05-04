using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase donde las funciones son publicas a lo largo de las escenas - vidas y puntaje -
public class GameMind : MonoBehaviour {

    // Instancia de la clase
    public static GameMind Instance;
    GameObject MenuPausa;
    GameObject MPausa;
    public bool Pausado = false;

    MonoBehaviour[] comps;


    // Start is called before the first frame update
    void Start()
    {
        MenuPausa = Resources.Load<GameObject>("Prefabs/Menu");
        //(GameObject)Resources.Load("Assets/Menu/Prefabs/Menu", typeof(GameObject)); ;
        comps = GetComponents<MonoBehaviour>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape) ) { Pausar(); }
    }

    public void Pausar()
    {
        if (!Pausado)
        {
            //Debug.Log("LE PIco ESC a la v");
            MPausa = Instantiate(MenuPausa, new Vector2(0, 0), Quaternion.identity) as GameObject;
            MPausa.transform.SetParent(GameObject.Find("Canvas").transform, false);
            Pausado = true;
        }
        else
        {
            Destroy(MPausa);
            Pausado = false;
        }

    }

  

    // Cuando el objeto donde esta el script, es "enabled" comienza a checar esto
    private void OnEnable()
    {
       
    }

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
