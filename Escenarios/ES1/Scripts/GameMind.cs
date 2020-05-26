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

    // Función para agregar al usuario
    public static void logOn(string u, string p) {
        // Debug.Log("a ver " + Database.login(u,p));
        int id=Database.login(u,p);
        if(id!=-1) {
            GlobalVariables.username = u;
            GlobalVariables.usernameId = id;
    	    Debug.Log("usuario " + GlobalVariables.username);
            SceneManager.LoadScene("Menu");
        }
        // Database.makeUser("test11","test11");
    }

     // Función para hacer logoff al usuario
    public static void logOff() {
        GlobalVariables.username = null;
    	Debug.Log("usuario " + GlobalVariables.username);
    }

     // Función para des usuario
    public static bool getAchivement(int achivementId) {
        return Database.getAchivement(achivementId);
    }

    public static void setAchivement(int achivementId) {
        Database.setAchivement(achivementId);
    }

    public static int getScore(int scoreId) {
       return  Database.getScore(scoreId);

    }

    public static void setScore(int scoreId, int score) {
        Database.setScore(scoreId, score);

    }

    public static bool getTutorial() {
        return Database.getTutorial();
    }

    public static void setTutorial() {
        Database.setTutorial();
    }
}
