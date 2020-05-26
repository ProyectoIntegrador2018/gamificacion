using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    static string[] LosQueAyudaron = new string[100];
    static int CuantosHay = 0;

    //Nombre de Escena
    string NamingConv;

    GameObject BtnAyuda ;
    GameObject BA;


    // Start is called before the first frame update
    void Start()
    {
        string Caso = GlobalVariables.Caso.ToString();
        string CurrentScene = SceneManager.GetActiveScene().name;

        BtnAyuda = Resources.Load<GameObject>("Prefabs/Pregunta");
        LoadInfo(Caso);

        //Debug.Log("Start" + CuantosHay);

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public static void ExisteAyuda( string Escena)
    {
        LoadInfo(Escena);
    }

    public static string Ask4Help()
    {
        if(CuantosHay == 0)
        {
            return "Nadie";
        }
        else
        {
            int Rand = Random.Range(0, CuantosHay+1);

            return LosQueAyudaron[Rand];
        }
    }

    //Literal solo traer la info
    static void LoadInfo(string Escena)
    {
        string escenarios_path = "Assets/M2/TextFile/Escenarios.txt";
        string personas_path =  "Assets/M2/TextFile/Personas.txt";
        StreamReader Escenarios = new StreamReader(escenarios_path);
        StreamReader Personas = new StreamReader(personas_path);
        int i = 0;
        string line1;
        string line2;

        while (!Escenarios.EndOfStream)
        {
            line1 = Escenarios.ReadLine();
            line2 = Personas.ReadLine();
            
            if(line1 == Escena.ToString())
            {
                LosQueAyudaron[CuantosHay] = line2;
                CuantosHay++;
                GlobalVariables.ExisteAyuda = true;
            }
            
            LosQueAyudaron[i] = line2;
            i++;
        }

        Personas.Close();
        Escenarios.Close();

        //Debug.Log(GlobalVariables.ExisteAyuda);
        //Debug.Log(GlobalVariables.Caso);
    }

    //Liteal solo escribir la info
    static void WriteInfo()
    {
        string escenarios_path = "Assets/M2/TextFile/Escenarios.txt";
        string personas_path = "Assets/M2/TextFile/Personas.txt";
        //Write some text to the test.txt file
        StreamWriter Escenarios = new StreamWriter(escenarios_path, true);
        StreamWriter Personas = new StreamWriter(personas_path, true);

        //Preguntas.WriteLine("");
        //Personas.WriteLine("");
        Escenarios.WriteLine(GlobalVariables.Caso.ToString());
        Personas.WriteLine(LosQueAyudaron[CuantosHay-1]);
        
        
        //Re-import the file to update the reference in the editor
        //AssetDatabase.ImportAsset(escenarios_path);
        //TextAsset asset = Resources.Load("test");
        //Print the text from the file
        //Debug.Log(asset.text);
        //UnityEditor.AssetDatabase.ImportAsset(escenarios_path);
        //UnityEditor.AssetDatabase.ImportAsset(personas_path);

        Personas.Close();
        Escenarios.Close();
    }
    
    static public void AgregarAyuda(string Nombre, string Caso)
    {
        LosQueAyudaron[CuantosHay] = Nombre;
        CuantosHay++;
        WriteInfo();
    }
}
