using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCase : MonoBehaviour
{
    public void GoToMainMenu()
    {
        GlobalVariables.lives = 5;
        SceneManager.LoadScene("P1"); //Load first question, TODO Main Menu
    }

    public void ResetGame()
    {
        GlobalVariables.lives = 5;
        SceneManager.LoadScene("P1");
    }


}
