using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Variables publicas
    public Button Continuar;
    public Button Salir;
    GameObject MainCa ;
    GameMind Script;

    private void Start()
    {
        MainCa = GameObject.Find("Main Camera");
        //Script = GameObject.Find("Main Camera").GetComponent<GameMind>.();
    }

    private void OnEnable()
    {
        Continuar.onClick.AddListener(delegate
        {
            MainCa.GetComponent<GameMind>().Pausar();
        });

        Salir.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Menu");
        });

    }
}
