using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public Button Jugar;
    public Button Historial;
    public Button Trofeos;
    public Button Salir;

    // Start is called before the first frame update
    void Start(){}
    // Update is called once per frame
    void Update(){}

    //
    private void OnEnable()
    {
        // El checar que los botones sean presionados, y que pasa si lo son
        Jugar.onClick.AddListener(delegate { JugarMision(); });
        //Historial.onClick.AddListener(delegate { CambiarScene(""); });
        Trofeos.onClick.AddListener(delegate { CambiarScene("Achivements"); });
        Salir.onClick.AddListener(delegate { CambiarScene("No"); });
    }

    void CambiarScene(string Cambio)
    {
        if(Cambio == "No")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(Cambio);
        }
    }

    void JugarMision()
    {
        int Rand = Random.Range(1, 2); ;        

        switch (Rand)
        {
            case 1: SceneManager.LoadScene("P1"); break;
            case 2: SceneManager.LoadScene("ES2P1"); break;
            case 3: SceneManager.LoadScene("ES3P1"); break;
            case 4: SceneManager.LoadScene("ES4P1"); break;
            case 5: SceneManager.LoadScene("ES5P1"); break;
            case 6: SceneManager.LoadScene("ES6P1"); break;
            case 7: SceneManager.LoadScene("ES7P1"); break;
            case 8: SceneManager.LoadScene("ES8P1"); break;
            case 9: SceneManager.LoadScene("ES9P1"); break;
            case 10: SceneManager.LoadScene("ES10P1"); break;

            default:
                break;
        }
    }
}

