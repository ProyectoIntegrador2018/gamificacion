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
            if (DragDrop.statusAnswer() == "Correct") {
                DialogueText.text = "Correcto! El guardia ahora tiene su equipo de seguridad puesto.";
                StartCoroutine(WaitSeconds(5));
            }
            if (DragDrop.statusAnswer() == "Incorrect") {
                DialogueText.text = "Incorrecto! El guardia debe tener puesto su casco de seguridad con barbiquejo, lentes de seguridad, guantes combinados de carnaza y botines de seguridad con casquillo";
                StartCoroutine(WaitSeconds(5));
            }
            if (DragDrops.statusAnswer() == "Correct" && GlobalVariables.pairAnswerSlot.Count == 7) {
                DialogueText.text = "Correcto! El guardia siguió el orden adecuado y el rodillo será arreglado.";
                StartCoroutine(WaitSeconds(5));
            }
            if (DragDrops.statusAnswer() == "Correct" && GlobalVariables.pairAnswerSlot.Count != 7) {
                DialogueText.text = "Incorrecto! Te faltaron pasos, el orden correcto sería ...";
                StartCoroutine(WaitSeconds(5));
            }
            if (DragDrops.statusAnswer() == "Incorrect" && GlobalVariables.pairAnswerSlot.Count == 7) {
                DialogueText.text = "Incorrecto! El orden correcto sería ...";
                StartCoroutine(WaitSeconds(5));
            }
            if (DragDrops.statusAnswer() == "Incorrect" && GlobalVariables.pairAnswerSlot.Count != 7) {
                DialogueText.text = "Incorrecto! Te faltaron pasos y el orden correcto sería ...";
                StartCoroutine(WaitSeconds(5));
            }
        });

    }

    IEnumerator WaitSeconds(int seconds) {
        Boton.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SigEscena);
    }
}
