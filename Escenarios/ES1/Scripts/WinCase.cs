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
    string Ignorar;
    GameObject Trofeo;

    private void Start() {
        //Debug.Log("llegue a script");
        Trofeo = GameObject.Find("Trophy");
        
        if(Trofeo != null)
        {
            Trofeo.SetActive(false);
        }
        //Toma el score guardado hasta el momento y lo archiva dependiendo de la escena win or lose que se encuentre
        string Escena = SceneManager.GetActiveScene().name;
        Debug.Log(Escena);
        string highscore;
        if (Escena == "Win" || Escena == "Lose")
        {
            highscore = "HighScoreES1";
        } else {
            highscore = "HighScore" + Escena.Substring(0, 3);
        }
        

        if (GlobalVariables.score >= PlayerPrefs.GetInt(highscore, GlobalVariables.score)) {
            PlayerPrefs.SetInt(highscore, GlobalVariables.score);
        }
        
        textOption = StarNumber(GlobalVariables.score);
        Debug.Log(textOption);

        if (Escena == "Win"){
            Debug.Log(Escena);
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
                Title.text = "¡Muy bien! ¡Ahora saber cómo reparar un rodillo!";
                Database.setAchivement(1);
                // AchievementManager.GainAchievement(1);
            }
        }       
        else if (Escena == "ES2Win")
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
                Database.setAchivement(2);
                // AchievementManager.GainAchievement(2);
            }
        }
        else if (Escena == "ES3Win")
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
                Title.text = "¡Muy bien! ¡Ahora sabes como actuar cuando una bomba se sobre calenta!";
                Database.setAchivement(3);
                //AchievementManager.GainAchievement(3);
            }
        }
        else if (Escena == "ES4Win")
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
                Title.text = "¡Muy bien! ¡Ahora sabes como actuar cuando una bomba se sobre calenta!";
                Database.setAchivement(4);
                // AchievementManager.GainAchievement(4);
            }
        }
        else if (Escena == "ES5Win")
        {
            if (textOption == 0)
            {
                Title.text = "Completaste la misión pero tu desempeño no fue optímo. Guardia, aun puedes mejorar en la sobrecarga de un motor.";
            }
            else if (textOption == 1)
            {
                Title.text = "Completaste la misión pero tu desempeño puede mejorar. ¡Sigue aprendiendo!";
            }
            else if (textOption == 2)
            {
                Title.text = "Completaste la misión pero hubo mal desempeño, en caso de duda consulta los manuales ó tu superior por pasos a seguir!";
            }
            else if (textOption == 3)
            {
                Title.text = "Estas a la mitad del camino hacia un desempeño perfecto. ¡Revisa tus manuales!";
            }
            else if (textOption == 4)
            {
                Title.text = "¡Estas muy cerca de la perfección!, revisa tus pasos y consulta con superiores o manuales.";
            }
            else if (textOption == 5)
            {
                Title.text = "¡Muy bien! ¡Ahora sabes como actuar cuando un sensor está dañado!";
                Database.setAchivement(5);
                // AchievementManager.GainAchievement(5);
            }
        }
        else if(Escena == "Lose" || Escena == "ES2Lose" || Escena == "ES3Lose" || Escena == "ES4Lose" || Escena == "ES5Lose" )
        {
            if (textOption == 0)
            {
                Title.text = "Perdiste, y tuviste un pésimo desempeño. Guardia, es tiempo de volver al entrenamiento";
            }
            else if (textOption == 1)
            {
                Title.text = "Perdiste y tu desempeño fue muy malo. A este paso si no le dedicas 100% a aprender podrias perder el rango de guardia.";
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
        Stars2UI.sprite = StarSprites[StarNumber(PlayerPrefs.GetInt(highscore, GlobalVariables.score))];
    }

    // Funcion que regresa la cantidad de estrellas necesaria
    public int StarNumber(int points) {
        Debug.Log("entre a estrellas");

        int n = 0;
        string Escena = SceneManager.GetActiveScene().name;
        string Escenario;
        int Maximo;
        double newPoints = 0;
        
        if (Escena.Substring(0,1) == "W" || Escena.Substring(0, 1) == "L")
        {
            Escenario = "1";
        }
        else
        {
            Escenario = Escena.Substring(2, 1);
        }

        Ignorar = Escenario;

        switch (Escenario)
        {
            //Los Escenarios
            case "1": Maximo = 800; break;
            case "2": Maximo = 900; break;
            case "3": Maximo = 500; break;
            case "4": Maximo = 900; break;
            case "5": Maximo = 600; break;
            case "6": Maximo = 1000000; break;
            case "7": Maximo = 1000000; break;
            case "8": Maximo = 1000000; break;
            case "9": Maximo = 1000000; break;
            case "10": Maximo = 1000000; break;

            default: Maximo = 1000000; break;
        }
        Debug.Log("points " + points);
        Debug.Log("maximo " + Maximo);
        newPoints = (double)points / (double)Maximo;
        Debug.Log(newPoints);

        //Debug.Log(Maximo);
        //Debug.Log(points);

        if (newPoints <= 0) {
            n = 0;
        } else if (0 < newPoints && newPoints <= .2) {
            n = 1;
        } else if (.2 < newPoints && newPoints <= .4) {
            n = 2;
        }  else if (.4 < newPoints && newPoints <= .6) {
            n = 3;
        }  else if (.6 < newPoints && newPoints <= .8) {
            n = 4;
        }  else if (.8 < newPoints && newPoints <= 1) {
            n = 5;
            if(newPoints == 1)
            {
                Trofeo.SetActive(true);
            }
        }
        Debug.Log("n " + n);
        return n;
    } 

    // Regresar al menu principal
    public void GoToMainMenu() {
        GlobalVariables.lives = 5;
        // TODO : Cuando tengamos la escena del menu
        GlobalVariables.score = 0;
        GlobalVariables.sumPos = -20;
        GlobalVariables.pairAnswerSlot.Clear();
        GlobalVariables.items.Clear();
        SceneManager.LoadScene("Menu");
    }

    // Reiniciar el juego
    public void ResetGame() {
        GlobalVariables.lives = 5;
        GlobalVariables.score = 0;
        GlobalVariables.sumPos = -20;
        GlobalVariables.pairAnswerSlot.Clear();
        GlobalVariables.items.Clear();
        string Escena = SceneManager.GetActiveScene().name;

        int Rand = Random.Range(1, 6);
        //Debug.Log(Rand);
        while (Rand == int.Parse(Ignorar))
        {
            Rand = Random.Range(1, 6);
        }
        
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

    public void GoToAchievements()
    {
        SceneManager.LoadScene("Achivements");
    }

}
