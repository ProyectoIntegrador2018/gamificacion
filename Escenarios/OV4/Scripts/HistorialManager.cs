using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HistorialManager : MonoBehaviour
{

    public const int NUMMISIONS = 10;

    public GameObject MisionPrefab;
    public GameObject MisionPrefabLose;

    public GameObject MisionDescription;

    public GameObject MisionScore;

    public Sprite[] StarSprites;
    public Image Stars1UI;


    public class Mision
    {
        public Mision()
        {
            Title = "";
            Description = "";
            DescriptionMala = "";
            Achieved = false;
            Score = -1;
        }

        public Mision(string title, string description, string descripcionMala, bool achived, int score)
        {
            Title = title;
            Description = description;
            DescriptionMala = descripcionMala;
            Achieved = achived;
            Score = score;
        }

        public string Title { get; }
        public string Description { get; }
        public string DescriptionMala { get; }
        public bool Achieved;
        public int Score;
    }

    public static Mision[] misionsArr = new Mision[NUMMISIONS]
{
    new Mision("¡Avería en el Rodillo!","Repara correctamente un rodillo antiderrapante.", "???", false, 0),
    new Mision("¡Avería en Acoplamiento!", "Repara correctamente una avería de acoplamiento.", "Haz intentado completar el reto del rodillo?", false, 0),
    new Mision("El Sobrecalentamiento en Bomba.", "Juego de Sobrecalentamiento de Bombas", "???", false, 0),
    new Mision("El Sensor de Proximidad genera demoras.", "Escenario donde el sensor de proximidad genera demoras.", "???", false, 0),
    new Mision("¡Sobrecarga de Motor hace demoras!", "Escenario donde la sobrecarga de un motor genera demoras!", "???", false, 0),
    new Mision("¡Avería: Sobrecarga de motor!", "Escenario de una sobrecarga de motor!", "???", false, 0),
    new Mision("¡Emergencia PM10, Guardia!", "¡Escenario de emergencia PM10!", "???", false, 0),
    new Mision("Correctivo programado PM11, Inspector.", "Correctivo programado PM11, Inspector.", "???", false, 0),
    new Mision("Aviso M3, Inspector", "Aviso M3 Para el inspector!", "???", false, 0),
    new Mision("Aviso M6, Inspector", "Aviso M6 Para el inspector!", "???", false, 0),
};


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <6; i++)
        {
            // misionsArr[i].Achieved = GameMind.getAchivement(i);
            if (Database.getStarted(i))
            {
                CreateMision(i, "Mision Container", misionsArr[i].Title, misionsArr[i].Description, misionsArr[i].DescriptionMala, misionsArr[i].Achieved = Database.getStarted(i), misionsArr[i].Score = Database.getScore(i));
            }
        }
        //Debug.Log(GlobalVariables.usernameId);
    }

    // Update is called once per frame
    void Update()
    {
        SetInfo();
    }

    public void CreateMision(int id, string category, string title, string description, string descripcionMala, bool achived, int score)
    {

        GameObject mision;
        //Render either a resolved or not resolved (black Achivement)
        if (achived)
        {
            mision = (GameObject)Instantiate(MisionPrefab);
        }
        else
        {
            mision = (GameObject)Instantiate(MisionPrefabLose);
        }


        SetMisionInfo(id, category, mision, title, description, descripcionMala, achived, score);
    }

    public void SetMisionInfo(int id, string category, GameObject mision, string title, string description, string descripcionMala, bool achieved, int score)
    {
        mision.transform.SetParent(GameObject.Find(category).transform);
        //Transformation values chose by hand / experimentation
        mision.transform.localScale = new Vector3((float)0.8723583, (float)1.006147, 1);
        mision.transform.GetChild(1).GetComponent<Text>().text = title;
        if (achieved)
        {
            mision.transform.GetChild(2).GetComponent<Text>().text = description;
        }
        else
        {
            mision.transform.GetChild(2).GetComponent<Text>().text = descripcionMala;
        }

        mision.transform.GetChild(3).GetComponent<Text>().text = score.ToString();

    }

    public static void AchiveMision(int index)
    {
        misionsArr[index].Achieved = true;
    }

    public void SetInfo()
    {
        MisionDescription.transform.GetComponent<Text>().text = MisionFunction.Description;
        MisionScore.transform.GetComponent<Text>().text = MisionFunction.Score;
        Stars1UI.sprite = StarSprites[StarNumber(int.Parse(MisionFunction.Score), MisionFunction.Escenario)];
    }


    public int StarNumber(int points, int Escenario)
    {
        int n = 0;
        int Maximo;
        double newPoints = 0;

        switch (Escenario)
        {
            //Los Escenarios
            case 1: Maximo = 800; break;
            case 2: Maximo = 900; break;
            case 3: Maximo = 500; break;
            case 4: Maximo = 900; break;
            case 5: Maximo = 600; break;
            case 6: Maximo = 1000000; break;
            case 7: Maximo = 1000000; break;
            case 8: Maximo = 1000000; break;
            case 9: Maximo = 1000000; break;
            case 10: Maximo = 1000000; break;

            default: Maximo = 1000000; break;
        }
        //Debug.Log("points " + points);
        //Debug.Log("maximo " + Maximo);
        newPoints = (double)points / (double)Maximo;
        //Debug.Log(newPoints);

        if (newPoints <= 0)
        {
            n = 0;
        }
        else if (0 < newPoints && newPoints <= .2)
        {
            n = 1;
        }
        else if (.2 < newPoints && newPoints <= .4)
        {
            n = 2;
        }
        else if (.4 < newPoints && newPoints <= .6)
        {
            n = 3;
        }
        else if (.6 < newPoints && newPoints <= .8)
        {
            n = 4;
        }
        else if (.8 < newPoints && newPoints <= 1)
        {
            n = 5;
        }
        return n;
    }


    public void GoToMainMenu()
    {
        GlobalVariables.lives = 5;
        // TODO : Cuando tengamos la escena del menu
        GlobalVariables.score = 0;
        GlobalVariables.pairAnswerSlot.Clear();
        GlobalVariables.items.Clear();
        SceneManager.LoadScene("Menu"); //TODO: Add an option to go back
    }

}
