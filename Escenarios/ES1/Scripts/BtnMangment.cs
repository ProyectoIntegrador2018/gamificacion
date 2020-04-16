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
    public Text DialogueText;

    private void OnEnable()
    {
        Boton.onClick.AddListener(delegate 
        {
            if (SceneManager.GetActiveScene().name == "P2") {
                if (DragDrop.statusAnswer() == "Correct") {
                DialogueText.text = "Correcto! El guardia ahora tiene su equipo de seguridad puesto.";
                GameMind.addPoints(100);
                StartCoroutine(WaitSeconds(5));
                }
                else if (DragDrop.statusAnswer() == "Incorrect") {
                    DialogueText.text = "Incorrecto! El guardia debe tener puesto su casco de seguridad con barbiquejo, lentes de seguridad, guantes combinados de carnaza y botines de seguridad con casquillo.";
                    
                    GameMind.addPoints(-100);
                    StartCoroutine(WaitSeconds(5));
                }
            }
            if (SceneManager.GetActiveScene().name == "P6") {
                if (DragDrops.statusAnswer() == "Correct" && GlobalVariables.pairAnswerSlot.Count == 7) {
                DialogueText.text = "Correcto! El guardia siguió el orden adecuado y el rodillo será arreglado.";
                GameMind.addPoints(100);
                StartCoroutine(WaitSeconds(5));
                }
                else if (DragDrops.statusAnswer() == "Correct" && GlobalVariables.pairAnswerSlot.Count != 7) {
                    DialogueText.text = "Incorrecto! Te faltaron pasos, el orden correcto sería ...";
                    
                    GameMind.addPoints(-100);
                    StartCoroutine(WaitSeconds(5));
                }
                else if (DragDrops.statusAnswer() == "Incorrect" && GlobalVariables.pairAnswerSlot.Count == 7) {
                    DialogueText.text = "Incorrecto! El orden correcto sería ...";
                   
                    GameMind.addPoints(-100);
                    StartCoroutine(WaitSeconds(5));
                }
                else if (DragDrops.statusAnswer() == "Incorrect" && GlobalVariables.pairAnswerSlot.Count != 7) {
                    DialogueText.text = "Incorrecto! Te faltaron pasos y el orden correcto sería ...";
                    
                    GameMind.addPoints(-100);
                    StartCoroutine(WaitSeconds(5));
                }
            }



        });
    }

    IEnumerator WaitSeconds(int seconds) {
        Boton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(seconds);
        if (GlobalVariables.lives <= 0)
        {
            SceneManager.LoadScene("losecaso1"); //Load Lose
        } else {
            SceneManager.LoadScene(SigEscena);
        }
    }
}
