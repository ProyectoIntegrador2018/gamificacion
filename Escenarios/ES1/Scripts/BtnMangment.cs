using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Clase para manejar los botones en P2 y P6 - escenas que tienen funcionalidad de drag and drop
public class BtnMangment : MonoBehaviour
{
    // Variables publicas
    public Button Boton;
    public int SigEscena;
    public Text DialogueText;

    private void OnEnable()
    {
        Boton.onClick.AddListener(delegate 
        {
            // Si la escena en juego es la P2
            if (SceneManager.GetActiveScene().name == "P2") {
                if (DragDrop.statusAnswer() == "Correct") {
                DialogueText.text = "Correcto! El guardia ahora tiene su equipo de seguridad puesto.";
                // Suma puntos
                GameMind.addPoints(100);
                StartCoroutine(WaitSeconds(5));
                }
                else if (DragDrop.statusAnswer() == "Incorrect") {
                    DialogueText.text = "Incorrecto! El guardia debe tener puesto su casco de seguridad con barbiquejo, lentes de seguridad, guantes combinados de carnaza y botines de seguridad con casquillo.";
                    // Quita vida y suma puntos
                    GameMind.takeAwayLive(1);
                    GameMind.addPoints(-100);
                    StartCoroutine(WaitSeconds(5));
                }
            }
            // Si la escena en juego es la P6
            if (SceneManager.GetActiveScene().name == "P6") {
                if (DragDrops.statusAnswer() == "Correct" && GlobalVariables.pairAnswerSlot.Count == 7) {
                DialogueText.text = "Correcto! El guardia siguió el orden adecuado y el rodillo será arreglado.";
                // Suma puntos
                GameMind.addPoints(100);
                StartCoroutine(WaitSeconds(5));
                }
                else if (DragDrops.statusAnswer() == "Correct" && GlobalVariables.pairAnswerSlot.Count != 7) {
                    DialogueText.text = "Incorrecto! Te faltaron pasos, el orden correcto sería ...";
                    // Quita vida y suma puntos
                    GameMind.takeAwayLive(1);
                    GameMind.addPoints(-100);
                    StartCoroutine(WaitSeconds(5));
                }
                else if (DragDrops.statusAnswer() == "Incorrect" && GlobalVariables.pairAnswerSlot.Count == 7) {
                    DialogueText.text = "Incorrecto! El orden correcto sería ...";
                    // Quita vida y suma puntos
                    GameMind.takeAwayLive(1);
                    GameMind.addPoints(-100);
                    StartCoroutine(WaitSeconds(5));
                }
                else if (DragDrops.statusAnswer() == "Incorrect" && GlobalVariables.pairAnswerSlot.Count != 7) {
                    DialogueText.text = "Incorrecto! Te faltaron pasos y el orden correcto sería ...";
                    // Quita vida y suma puntos
                    GameMind.takeAwayLive(1);
                    GameMind.addPoints(-100);
                    StartCoroutine(WaitSeconds(5));
                }
            }
        });
    }

    // Coroutine donde se espera 5 segundos para que el usuario pueda leer el feedback
    IEnumerator WaitSeconds(int seconds) {
        Boton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(seconds);
        // Si las vidas es 0 o menos se cargara la escena de perder, sino la siguiente escena
        if (GlobalVariables.lives <= 0) {
            SceneManager.LoadScene("Lose");
        } else {
            SceneManager.LoadScene(SigEscena);
        }
    }
}
