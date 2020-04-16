using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase para el manejo de preguntas tipo de decision
public class QuestionManager : MonoBehaviour {
    
    // Para manipular el Texto que se despliega
    public Text CanvasText;
    
    // Para manipular los botones
    public Button Btn1;
    public Button Btn2;
    public Button Btn3;

    public int SegundosEspera;

    // Las opciones de los botones, esto es para control mas abajo
    bool Opt1;
    bool Opt2;
    bool Opt3;

    // Vidas que se van a quitar dependiendo del error
    public int vidasFallo1;
    public int vidasFallo2;

    // Esto es para que podamos definir a que pregunta brincamos, gracias al index, solo tenemos que ponerlas en el orden correcto
    // Esta es la escena que sigue, mas abajo se define cual sera
    int SigEscena;

    // Este es el camino correcto
    public int SigEscenaCorrecto;
    
    // Este es el camino por Arriba, checar Moqup
    public int SigEscenaError1;
    
    // Este es el camino por Abajo, checar Moqup
    public int SigEscenaError2;
    
    // Esto es para cargar la pregunta correcta
    public int PreguntaActual;

    // Esta es clase Preguntas, esta aqui porque importarla tiene que ver con Visual Studio, entonces para facilitarlo la puse aqui 
    public class Preguntas {
        
        // Constructor that takes no arguments:
        public Preguntas() {
            Pregunta = "Aqui va la pregunta";
            Opc1 = "a";
            Opc2 = "";
            Vidas1 = 0;
            Vidas2 = 0;
            Opc3 = "";
            Fail1 = "";
            Fail2 = "";
            Correct = 0;
            Points = 0;
        }

        // Constructor with arguments
        public Preguntas(string pregunta, string opc1, string opc2, int vidas1, int vidas2, string opc3, string fail1, string fail2, int correct, int points) {
            Pregunta = pregunta;
            Opc1 = opc1;
            Opc2 = opc2;
            Vidas1 = vidas1;
            Vidas2 = vidas2;
            Opc3 = opc3;
            Fail1 = fail1;
            Fail2 = fail2;
            Correct = correct;
            Points = points;
        }

        // Auto-implemented readonly property:
        public string Pregunta { get; }
        public string Opc1  { get; }
        public string Opc2  { get; }
        public int Vidas1 { get; }
        public int Vidas2 { get; }
        public string Opc3  { get; }
        public string Fail1 { get; }
        public string Fail2 { get; }
        public int Correct  { get; }
        public int Points { get; }
    }
    
    // Los estados del juego, esto lo aprendi del video que estaba en la carta
    private enum States {
        Questions, trueState, falseState, falseState2
    };

    // TODAS las preguntas, las cargamos aqui luego las cargamos, dependiendo de la pregunta que sea necesitada
    Preguntas Q1 = new Preguntas("Se informa al guardia de daño en cuerpo de rodillo, ¿qué sigue?", "Va directamente a solucionar el problema", "Solicita más información sin ir al área", 4, 1, "Toma medidas de seguridad", "Incorrecta interpretación del problema y provoca preparación inadecuada. Primero debe tomar medidas de seguridad, evaluar el área y llenar el APR.", "Minimiza el problema y provoca mayor afectación. Primero debe tomar medidas de seguridad.", 3, 100);
    Preguntas Q3 = new Preguntas("Va al área del afectada y se encuentra con el rodillo, ¿qué sigue?", "No es tan importante un rodillo", "Va directamente a solucionar el problema", 3, 2, "Evalúa el daño del rodillo, apoyándose si es necesario con Producción o Calidad", "Minimiza el problema y provoca mayor afectación. Tiene que solucionar el problema, pero antes de eso debe evaluar el daño y llenar el APR para finalmente solucionar el problema.", "Existe un riesgo de accidente al no verificar la condición de operación. Tuvo que haber evaluado el daño y llenado el APR.", 3, 100);
    Preguntas Q4 = new Preguntas("El guardia recibe más información sin ir al área, ¿qué sigue?", "None", "Va directamente a solucionar el problema", 0, 3, "Va al área afectada", "None", "El guardia debe evaluar el area y llenar el APR.", 2, 100);
    Preguntas Q5 = new Preguntas("Después de la evaluación, ¿qué sigue?", "Solucionar el problema", "Ignorar el problema y asumir que no habrá afectación", 1, 2, "Llenar el APR", "Debe de llenar el APR antes de continuar.", "Minimiza el problema y provoca mayor afectación. Debe llenar el APR y después solucioanr el problema antes de generar el aviso.", 3, 100);
    Preguntas Q6 = new Preguntas("¿Ahora qué sigue?", "Informo a Calidad", "Genero una orden de Mantenimiento", 1, 1, "Genero un aviso", "Calidad no es responsable de esta parte del proceso. Se debe generar un aviso.", "Se generaría una orden de mantenimiento sin información completa del problema. Se debe generar un aviso.", 3, 100);
    Preguntas Q7 = new Preguntas("Después de la reparacion, ¿qué aviso se debe generar?", "Aviso M0", "Aviso M3", 1, 1, "Aviso M2", "Este aviso surge solo de inspecciones, se debe generar el M2.", "Este aviso se utiliza solo para guardar información de actividad en el equipo, se debe generar el M2.", 3, 100);
    Preguntas Q8 = new Preguntas("¿Qué campos deben ser llenados en el Aviso M2?", "Colocar la palabra 'vinculos' en algun campo", "Agregar multimedia", 1, 1, "Equipo, ¿qué paso?, ¿por qué paso?, ¿qué se hizo?, parte, objeto, sintoma, avería, causa y sus textos", "Esta palabra no informa el detalle de lo ocurrido. Debe llenar: equipo, ¿qué paso?, ¿por qué paso?, ¿qué se hizo?, parte, objeto, sintoma, avería, causa y sus textos.", "Es opcional agregar alguna foto al aviso. Es obligatorio llenar: equipo, ¿qué paso?, ¿por qué paso?, ¿qué se hizo?, parte, objeto, sintoma, avería, causa y sus textos.", 3, 100);
    
    // Pregunta actual
    Preguntas QA = new Preguntas();

    // Pregunta Error
    Preguntas QE = new Preguntas("ERROR", "ERROR", "ERROR", 0, 0, "ERROR", "ERROR", "ERROR", 3, 0);

    // El estado actual
    private States myState;
  
    // Start is called before the first frame update
    void Start() {
        // Cargar el estado principal
        myState = States.Questions;
        
        // Cargar la pregunta correcta
        switch(PreguntaActual) {
            case 1: QA = Q1; break;
            case 3: QA = Q3; break;
            case 4: QA = Q4; break;
            case 5: QA = Q5; break;
            case 6: QA = Q6; break;
            case 7: QA = Q7; break;
            case 8: QA = Q8; break;
            default: QA = QE; break;
        }
        
        // Revolver los cuadros de respuesta
        Revolver(QA.Correct); 
    }

    // Update is called once per frame
    void Update() {
        // Como siempre esta corriendo esto, hay que mantenerlo simple, asi que solo cambiara states
        if (myState == States.Questions){ Question(); }
        else if (myState == States.trueState){ trueState(); }
        else if (myState == States.falseState){ falseState(); }
        else if (myState == States.falseState2) { falseState2(); }
    }

    // Cuando el objeto donde esta el script, es "enabled" comienza a checar esto
    private void OnEnable() {
        // El checar que los botones sean presionados, y que pasa si lo son
        Btn1.onClick.AddListener(delegate {Opt1 = true; StartCoroutine(WaitSeconds()); });
        Btn2.onClick.AddListener(delegate {Opt2 = true; StartCoroutine(WaitSeconds()); });
        Btn3.onClick.AddListener(delegate {Opt3 = true; StartCoroutine(WaitSeconds()); });
    }

    // Desplegar la pregunta actual
    void Question() {
        //Cambiar el texto de la pregunta
        CanvasText.text = QA.Pregunta;

        Btn1.GetComponentInChildren<Text>().text = QA.Opc1;
        Btn2.GetComponentInChildren<Text>().text = QA.Opc2;
        Btn3.GetComponentInChildren<Text>().text = QA.Opc3;

        if (Opt1 == true) { 
            GameMind.takeAwayLive(QA.Vidas1);
            GameMind.addPoints(-QA.Points);
            myState = States.falseState; 
        } else if (Opt2 == true){
            GameMind.takeAwayLive(QA.Vidas2);
            GameMind.addPoints(-QA.Points);
            myState = States.falseState2;
        } else if (Opt3 == true){
            GameMind.addPoints(QA.Points);
            myState = States.trueState;  
        }
    }

    // El estado cuando le atina
    void trueState() {
        CanvasText.text = "Correcto!";
        SigEscena = SigEscenaCorrecto;  
    }

    // El estado de error 1
    void falseState() {
        CanvasText.text = "Incorrecto! " +'\n'+ QA.Fail1;
        SigEscena = SigEscenaError1;
    }

    // El estado de error 2
    void falseState2() {
        CanvasText.text = "Incorrecto! " + '\n' + QA.Fail2;
        SigEscena = SigEscenaError2;
    }

    // Es la corutina que espera 5 segundos luego cargan la escena que fue asignada
    IEnumerator WaitSeconds() {
        yield return new WaitForSeconds(SegundosEspera);
        if (GlobalVariables.lives <= 0) {
            SceneManager.LoadScene("Lose");
        } else {
            SceneManager.LoadScene(SigEscena);
        }
    }

    // Dado que seria mucho problema randomizar la respuesta y el texto 
    // de fallo especifico sera mas facil mover las posiciones de los botones
    void Revolver(int PA) {

        int Rand;

        if (PA == 2) {
            Rand = Random.Range(20, 22);
            Btn1.enabled = false;
            Btn1.gameObject.SetActive(false);
        } else {
            Rand = Random.Range(1, 7);
        }
        
        switch (Rand) {
            case 1:
                Btn1.transform.localPosition = new Vector2(730, 254);
                Btn2.transform.localPosition = new Vector2(730, 2);
                Btn3.transform.localPosition = new Vector2(730, -252);
                break;

            case 3:
                Btn2.transform.localPosition = new Vector2(730, 254);
                Btn1.transform.localPosition = new Vector2(730, 2);
                Btn3.transform.localPosition = new Vector2(730, -252);
                break;

            case 4:
                Btn2.transform.localPosition = new Vector2(730, 254);
                Btn3.transform.localPosition = new Vector2(730, 2);
                Btn1.transform.localPosition = new Vector2(730, -252);
                break;

            case 5:
                Btn3.transform.localPosition = new Vector2(730, 254);
                Btn1.transform.localPosition = new Vector2(730, 2);
                Btn2.transform.localPosition = new Vector2(730, -252);
                break;

            // Estos son para cuando solo hay 2 respuestas
            case 20:
                Btn3.transform.localPosition = new Vector2(730, 200);
                Btn2.transform.localPosition = new Vector2(730, -200);
                break;

            case 21:
                Btn2.transform.localPosition = new Vector2(730, 200);
                Btn3.transform.localPosition = new Vector2(730, -200);
                break;

            default:
                break;
        }
    }
}
