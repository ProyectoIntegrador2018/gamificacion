using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchievementManager : MonoBehaviour
{

    public const int  NUMACHIVEMENTS = 7; //TODO: Change the achivmentes menu from the one using the user login system

    public GameObject AchievementPrefab;
    public GameObject AchievementPrefabLose;

    public GameObject AchivementDescription;

    public class Achievement
    {
        //TODO: Agregar la capacidad de cambiar el sprite del achivement
        public Achievement()
        {
            Title = "";
            Description = "";
            DescriptionMala = "";
            Achieved = false;
        }

        public Achievement(string title, string description, string descripcionMala, bool achived)
        {
            Title = title;
            Description = description;
            DescriptionMala = descripcionMala;
            Achieved = achived;
        }

        public string Title { get; }
        public string Description { get; }
        public string DescriptionMala { get; }
        public bool Achieved;

    }

    //Todos los achievements son declarados aquí
    public static Achievement[] achievementsArr = new Achievement[NUMACHIVEMENTS]
    {
    new Achievement("Veo mis logros, con otros ojos.","Por revisar tu progreso. ¡El primer paso siempre cuenta!", "", true),
    new Achievement("Yo mero, con el rodillo.", "Por probar tu eficiencia en el caso de cambio de un rodillo antiderrapante. \n ¡El primer paso siembre cuenta!", "Haz intentado completar el reto del rodillo?", false),
    new Achievement("El acoplo que no acopla.", "¡Por su eficacia en el caso avería del aclopamiento!", "¿Has probado reparar algo que no acopla?", false),
    new Achievement("¿Hace calor aquí?", "Por probar tus habilidades en el caso inspección de sobrecalentamiento.", "La temperatura no parece la correcta, ¿la prodrías revisar?", false),
    new Achievement("El sensor de proximidad se demora.", "Has demostrado eficiencia en el caso de sensor de proximidad tardio. ¡Bien Hecho!", "¿Ya se tardo, no? ¿Haz pensado en checarlo?", false),
    new Achievement("¡Relajaté, motor!", "Tus habilidades en el caso sobrecarga de motor causa demorá, son bien notadas!", "Termina el caso \"Sobrecarga de Motor causa demora\" con 5 estrellas.", false),
    new Achievement("No mucho aceite.", "Por pasar el caso, \"Avería por Nivel de Aceite\" con 5 estrellas.", "Termina el caso \"Avería por nivel de Aceite\" con 5 estrellas.", false),
    };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NUMACHIVEMENTS; i++)
        {
            achievementsArr[i].Achieved = Database.getAchivement(i);
            CreateAchivement("Achivement Container", achievementsArr[i].Title, achievementsArr[i].Description, achievementsArr[i].DescriptionMala, achievementsArr[i].Achieved);
        }
        Debug.Log(GlobalVariables.usernameId);
    
    }

    // Update is called once per frame
    void Update()
    {
        SetDescription();
    }

    public void CreateAchivement(string category, string title, string description, string descripcionMala, bool achived)
    {

        GameObject achivement;
        //Render either a resolved or not resolved (black Achivement)
        if (achived)
        {
           achivement = (GameObject)Instantiate(AchievementPrefab);
        } else {
           achivement = (GameObject)Instantiate(AchievementPrefabLose);
        }


        SetAchivementInfo(category, achivement, title, description, descripcionMala, achived);
    }

    public void SetAchivementInfo(string category, GameObject achivement, string title, string description, string descripcionMala, bool achieved)
    {
        achivement.transform.SetParent(GameObject.Find(category).transform);
        //Transformation values chose by hand / experimentation
        achivement.transform.localScale = new Vector3( (float)0.8723583, (float)1.006147, 1);
        achivement.transform.GetChild(1).GetComponent<Text>().text = title;
        if (achieved)
        {
            achivement.transform.GetChild(2).GetComponent<Text>().text = description;
        } else
        {
            achivement.transform.GetChild(2).GetComponent<Text>().text = descripcionMala;
        }
        
    }

    public static void GainAchievement(int AchievementIndex)
    {
        achievementsArr[AchievementIndex].Achieved = true;
    }

    public void SetDescription()
    {
        AchivementDescription.transform.GetChild(0).GetComponent<Text>().text = AchivementFunction.Description;
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
