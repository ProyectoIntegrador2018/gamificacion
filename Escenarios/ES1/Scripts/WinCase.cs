using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Clase para cuando el jugador gana o pierde
public class WinCase : MonoBehaviour {

    // Variables publicas
    public Text HighScore;
    public Text YourScore;
    public Sprite[] StarSprites;
    public Image Stars1UI;
    public Image Stars2UI;
    public int textOption;
    public Text Title;

    private void Start() {   
        if (GlobalVariables.score >= PlayerPrefs.GetInt("Highscore", GlobalVariables.score)) {
            PlayerPrefs.SetInt("Highscore", GlobalVariables.score);
        }
        
        textOption = StarNumber(GlobalVariables.score);

        if (SceneManager.GetActiveScene().name == "Win"){
            if (textOption == 0) {
                Title.text = "Completaste la misión pero tu desempeño fue pésimo. Guardia, es tiempo de volver al entrenamiento";
            } else if (textOption == 1) {
                Title.text = "Completaste la misión pero tu desempeño fue muy malo. A este paso si no le dedicas 100% a aprender podrias perder el rango de guardia ";
            } else if (textOption == 2) {
                Title.text = "Completaste la misión pero hubo mal desempeño, enfocate mucho en los manuales y busca alguien que te supervise";
            } else if (textOption == 3) {
                Title.text = "Desempeño promedio, esfuerzate un poco más en los manuales y trata de perfeccionar la mision";
            } else if (textOption == 4) {
                Title.text = "Muy cerca de la perfección, busca apoyo de un supervisor para mejorar";
            } else if (textOption == 5) {
                Title.text = "¡Muy bien! ¡Ahora sabes cómo reparar un rodillo!";
            }
        }
        else if (SceneManager.GetActiveScene().name == "Lose") {
            if (textOption == 0) {
                Title.text = "Perdiste, y tuviste un pésimo desempeño. Guardia, es tiempo de volver al entrenamiento";
            } else if (textOption == 1) {
                Title.text = "Perdiste y tu desempeño fue muy malo. A este paso si no le dedicas 100% a aprender podrias perder el rango de guardia ";
            } else if (textOption == 2) {
                Title.text = "Perdiste hubo un mal desempeño, enfocate mucho en los manuales para ganar la misión";
            } else if (textOption == 3) {
                Title.text = "Perdiste y tu desempeño fue promedio, esfuerzate un poco más en los manuales y trata de ganar la misión";
            } else if (textOption == 4) {
                Title.text = "Perdiste pero estás cerca de la perfección, busca apoyo de un supervisor para mejorar";
            } else if (textOption == 5) {
                Title.text = "";
            }
        }

        //ES2
        if (SceneManager.GetActiveScene().name == "ES2Win")
        {
            if (textOption == 0)
            {
                Title.text = "Completaste la misión pero tu desempeño fue pésimo. Guardia, es tiempo de volver al entrenamiento";
            }
            else if (textOption == 1)
            {
                Title.text = "Completaste la misión pero tu desempeño fue muy malo. A este paso si no le dedicas 100% a aprender podrias perder el rango de guardia ";
            }
            else if (textOption == 2)
            {
                Title.text = "Completaste la misión pero hubo mal desempeño, enfocate mucho en los manuales y busca alguien que te supervise";
            }
            else if (textOption == 3)
            {
                Title.text = "Desempeño promedio, esfuerzate un poco más en los manuales y trata de perfeccionar la mision";
            }
            else if (textOption == 4)
            {
                Title.text = "Muy cerca de la perfección, busca apoyo de un supervisor para mejorar";
            }
            else if (textOption == 5)
            {
                Title.text = "¡Muy bien! ¡Ahora sabes como actuar cuando escuches una averia!";
            }
        }
        else if (SceneManager.GetActiveScene().name == "ES2Lose")
        {
            if (textOption == 0)
            {
                Title.text = "Perdiste, y tuviste un pésimo desempeño. Guardia, es tiempo de volver al entrenamiento";
            }
            else if (textOption == 1)
            {
                Title.text = "Perdiste y tu desempeño fue muy malo. A este paso si no le dedicas 100% a aprender podrias perder el rango de guardia ";
            }
            else if (textOption == 2)
            {
                Title.text = "Perdiste hubo un mal desempeño, enfocate mucho en los manuales para ganar la misión";
            }
            else if (textOption == 3)
            {
                Title.text = "Perdiste y tu desempeño fue promedio, esfuerzate un poco más en los manuales y trata de ganar la misión";
            }
            else if (textOption == 4)
            {
                Title.text = "Perdiste pero estás cerca de la perfección, busca apoyo de un supervisor para mejorar";
            }
            else if (textOption == 5)
            {
                Title.text = "";
            }
        }


        Stars1UI.sprite = StarSprites[textOption];
        Stars2UI.sprite = StarSprites[StarNumber(PlayerPrefs.GetInt("Highscore", GlobalVariables.score))];
    }

    // Funcion que regresa la cantidad de estrellas necesaria
    public int StarNumber(int points) {

        int n = 0;
        string Escena = SceneManager.GetActiveScene().name;
        string Escenario;
        int Maximo;

        if (Escena.Substring(0,1) == "W" || Escena.Substring(0, 1) == "L")
        {
            Escenario = "1";
        }
        else
        {
            Escenario = Escena.Substring(2, 1);
        }

        switch (Escenario)
        {
            //ES1
            case "1": Maximo = 800; break;
            case "2": Maximo = 900; break;
            case "3": Maximo = 1000000; break;
            case "4": Maximo = 1000000; break;
            case "5": Maximo = 1000000; break;
            case "6": Maximo = 1000000; break;
            case "7": Maximo = 1000000; break;
            case "8": Maximo = 1000000; break;
            case "9": Maximo = 1000000; break;
            case "10": Maximo = 1000000; break;

            default: Maximo = 1000000; break;
        }

        points = points / Maximo;

        //Debug.Log(Maximo);
        //Debug.Log(points);

        if (points <= 0) {
            n = 0;
        } else if (0 < points && points <= .2) {
            n = 1;
        } else if (.2 < points && points <= .4) {
            n = 2;
        }  else if (.4 < points && points <= .6) {
            n = 3;
        }  else if (.6 < points && points <= .8) {
            n = 4;
        }  else if (.8 < points && points <= 1) {
            n = 5;
        }

        return n;
    } 

    // Regresar al menu principal
    public void GoToMainMenu() {
        GlobalVariables.lives = 5;
        // TODO : Cuando tengamos la escena del menu
        Application.Quit();
    }

    // Reiniciar el juego
    public void ResetGame() {
        GlobalVariables.lives = 5;
        GlobalVariables.score = 0;
        GlobalVariables.sumPos = -20;
        GlobalVariables.pairAnswerSlot.Clear();
        GlobalVariables.items.Clear();
        SceneManager.LoadScene("P1");
    }
}
