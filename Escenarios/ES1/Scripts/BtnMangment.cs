using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnMangment : MonoBehaviour
{
    //Literal una clase para manejar la interaccion de un solo Boton
    public Button Boton;
    public int SigEscena;

    private void OnEnable()
    {
        Boton.onClick.AddListener(delegate {
            //Debug.Log("Entre");
            SceneManager.LoadScene(SigEscena);
        });

    }
}
