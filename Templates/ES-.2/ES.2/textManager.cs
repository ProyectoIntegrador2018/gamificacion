using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class textManager : MonoBehaviour
{
    public Text CanvasText;
    public Button BtnTrue;
    public Button BtnFalse;
    public Button Btn3;

    public bool Opt1;
    public bool Opt2;
    public bool Opt3;
    public bool change;

    public class Preguntas
    {
        // Constructor that takes no arguments:
        public Preguntas()
        {
            Pregunta = "Aqui Va la pregunta";
            Opc1 = "a";
            Opc2 = "";
            Opc3 = "";
            Fail1 = "";
            Fail2 = "";
            Correct = 0;
        }

        // Constructor with arguments
        public Preguntas(string pregunta, string opc1, string opc2, string opc3, string fail1, string fail2, int correct)
        {
            Pregunta = pregunta;
            Opc1 = opc1;
            Opc2 = opc2;
            Opc3 = opc3;
            Fail1 = fail1;
            Fail2 = fail2;
            Correct = correct;
        }


        // Auto-implemented readonly property:
        public string Pregunta { get; }
        public string Opc1  { get; }
        public string Opc2  { get; }
        public string Opc3  { get; }
        public string Fail1 { get; }
        public string Fail2 { get; }
        public int Correct  { get; }


        // Method that overrides the base class (System.Object) implementation.
        // public override string ToString() { return Pregunta; }


    }

    private enum States
    {
        Questions, trueState, falseState, falseState2
    };

    Preguntas Q1 = new Preguntas("Se informa a Guardia de daño en cuerpo de rodillo", "Siempre sucede ya se que hacer", "Solicito me informen todo el detalle por radio", "Verifico personalmente en el área el daño del rodillo tomando las medidas de seguridad adecuadas", "Minimizar el problema y provocar mayor afectación", "Incorrecta interpretación del problema y provocar preparación inadecuada", 3);
    Preguntas Q2 = new Preguntas("Al verificar personalmente", "Me dispongo a cambiarlo de inmediato", "Asumo unilateralmente que el daño no es importante", "Evaluó el daño apoyándome si es necesario con Producción o Calidad", "Riesgo de accidente al no verificar la condición de operación", "Minimizar el problema y provocar mayor afectación", 3);
    Preguntas Q3 = new Preguntas("Una vez evaluado el problema", "Atender de inmediato", "Ignorar el problema y asumir que no habrá afectación", "Llenar el APR y proceder a solucionar el problema", "Riesgo de accidente al no verificar la condición de operación", "Minimizar el problema y provocar mayor afectación", 3);
    Preguntas Q4 = new Preguntas("Después de evaluar el daño", "Genero una orden de Mantenimiento", "Informo a Calidad", "Genero un aviso", "Orden de mantenimiento sin información completa del problema", "Calidad no es responsable de esta parte del proceso", 3);
    Preguntas Q5 = new Preguntas("Que tipo de aviso debo generar", "Aviso M0", "Aviso M3", "Aviso M2", "Este aviso surge solo de Inspecciones", "Este aviso se utiliza solo para guardar información de actividad en el equipo", 3);
    Preguntas Q6 = new Preguntas("Cual reporte de falla es el mas importante", "Pintados", "Laminacion", "Galvanizado", "no", "no", 3);
    Preguntas Q7 = new Preguntas("Cual reporte de falla es el menos importante", "Galvanizado", "Laminacion", "Pintados", "no", "no", 3);
    Preguntas Q8 = new Preguntas("Por lo general a quien se manda primero a checar la falla", "Administrador de zona", "Guardia Mecancio", "Guardia Electrico", "no", "no", 3);
    Preguntas QA = new Preguntas();

    private States myState;
  
    // Start is called before the first frame update
    void Start()
    {
        //Aprender a importar de Archivo
        myState = States.Questions;
        QA = Q1;

    }

    // Update is called once per frame
    void Update()
    {
        if(myState == States.Questions){ Question(); }
        else if (myState == States.trueState){ trueState(); }
        else if (myState == States.falseState){ falseState(); }
        else if (myState == States.falseState2) { falseState2(); }

    }

    private void OnEnable()
    {
        BtnTrue.onClick.AddListener(delegate  {Opt1 = true; StartCoroutine(WaitSeconds()); });
        BtnFalse.onClick.AddListener(delegate {Opt2 = true; StartCoroutine(WaitSeconds()); });
        Btn3.onClick.AddListener(delegate     {Opt3 = true; StartCoroutine(WaitSeconds()); });

    }

    void Question()
    {
        CanvasText.text = QA.Pregunta;

        BtnTrue.GetComponentInChildren<Text>().text = QA.Opc1;
        BtnFalse.GetComponentInChildren<Text>().text = QA.Opc2;
        Btn3.GetComponentInChildren<Text>().text = QA.Opc3;

        if (Opt1 == true){ myState = States.falseState; }
        else if (Opt2 == true){ myState = States.falseState2; }
        else if (Opt3 == true) { myState = States.trueState; }
    }

    void trueState()
    {
        CanvasText.text = "CORRECTO!";
        
        
       // QA = Q2;
    }

    void falseState()
    {
        CanvasText.text = "INCORRECTO " +'\n'+ QA.Fail1;
       
        //StartCoroutine(WaitSeconds());
        //QA = Q3;
    }

    void falseState2()
    {
        CanvasText.text = "INCORRECTO " + '\n' + QA.Fail2;
     
       // StartCoroutine(WaitSeconds());
        //QA = Q3;
    }

    IEnumerator WaitSeconds()
    {
        //change = true;
        yield return new WaitForSeconds(5);

        NuevaPregunta();
    }

    void NuevaPregunta()
    {
        //Debug.Log("Pase");
        if (QA == Q1) { QA = Q2;}
        else if (QA == Q2) { QA = Q3; }
        else if (QA == Q3) { QA = Q4; }
        else if (QA == Q4) { QA = Q5; }
        else if (QA == Q5) { QA = Q6; }
        else if (QA == Q6) { QA = Q7; }

        myState = States.Questions;
        Opt1 = false;
        Opt2 = false;
        Opt3 = false;
        //BtnTrue.navigation.mode = Navigation.Mode.None;
    }
}
