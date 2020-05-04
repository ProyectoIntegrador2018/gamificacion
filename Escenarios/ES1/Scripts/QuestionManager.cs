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
    public string Escena;

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
    string SigEscena;

    // Este es el camino correcto
    public string SigEscenaCorrecto;
    
    // Este es el camino por Arriba, checar Moqup
    public string SigEscenaError1;
    
    // Este es el camino por Abajo, checar Moqup
    public string SigEscenaError2;
    
    // Esto es para cargar la pregunta correcta
    //public int PreguntaActual;

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
    //ES1
    Preguntas ES1Q1 = new Preguntas("Se informa al guardia de daño en cuerpo de rodillo, ¿qué sigue?", "Va directamente a solucionar el problema", "Solicita más información sin ir al área", 4, 1, "Toma medidas de seguridad", "Incorrecta interpretación del problema y provoca preparación inadecuada. Primero debe tomar medidas de seguridad, evaluar el área y llenar el APR.", "Minimiza el problema y provoca mayor afectación. Primero debe tomar medidas de seguridad.", 3, 100);
    Preguntas ES1Q3 = new Preguntas("Va al área del afectada y se encuentra con el rodillo, ¿qué sigue?", "No es tan importante un rodillo", "Va directamente a solucionar el problema", 3, 2, "Evalúa el daño del rodillo, apoyándose si es necesario con Producción o Calidad", "Minimiza el problema y provoca mayor afectación. Tiene que solucionar el problema, pero antes de eso debe evaluar el daño y llenar el APR para finalmente solucionar el problema.", "Existe un riesgo de accidente al no verificar la condición de operación. Tuvo que haber evaluado el daño y llenado el APR.", 3, 100);
    Preguntas ES1Q4 = new Preguntas("El guardia recibe más información sin ir al área, ¿qué sigue?", "None", "Va directamente a solucionar el problema", 0, 3, "Va al área afectada", "None", "El guardia debe evaluar el area y llenar el APR.", 2, 100);
    Preguntas ES1Q5 = new Preguntas("Después de la evaluación, ¿qué sigue?", "Solucionar el problema", "Ignorar el problema y asumir que no habrá afectación", 1, 2, "Llenar el APR", "Debe de llenar el APR antes de continuar.", "Minimiza el problema y provoca mayor afectación. Debe llenar el APR y después solucioanr el problema antes de generar el aviso.", 3, 100);
    Preguntas ES1Q6 = new Preguntas("¿Ahora qué sigue?", "Informo a Calidad", "Genero una orden de Mantenimiento", 1, 1, "Genero un aviso", "Calidad no es responsable de esta parte del proceso. Se debe generar un aviso.", "Se generaría una orden de mantenimiento sin información completa del problema. Se debe generar un aviso.", 3, 100);
    Preguntas ES1Q7 = new Preguntas("Después de la reparacion, ¿qué aviso se debe generar?", "Aviso M0", "Aviso M3", 1, 1, "Aviso M2", "Este aviso surge solo de inspecciones, se debe generar el M2.", "Este aviso se utiliza solo para guardar información de actividad en el equipo, se debe generar el M2.", 3, 100);
    Preguntas ES1Q8 = new Preguntas("¿Qué campos deben ser llenados en el Aviso M2?", "Colocar la palabra 'vinculos' en algun campo", "Agregar multimedia", 1, 1, "Equipo, ¿qué paso?, ¿por qué paso?, ¿qué se hizo?, parte, objeto, sintoma, avería, causa y sus textos", "Esta palabra no informa el detalle de lo ocurrido. Debe llenar: equipo, ¿qué paso?, ¿por qué paso?, ¿qué se hizo?, parte, objeto, sintoma, avería, causa y sus textos.", "Es opcional agregar alguna foto al aviso. Es obligatorio llenar: equipo, ¿qué paso?, ¿por qué paso?, ¿qué se hizo?, parte, objeto, sintoma, avería, causa y sus textos.", 3, 100);
    //ES2
    Preguntas ES2Q1 = new Preguntas("En un recorrido por el área, el guardia escucha un ruido anormal", "Es la hora de la comida y llevo prisa, continuo mi camino sin prestar atención.", "Alguien debe estar haciendo alguna actividad", 1, 3, "Tomando las precauciones de seguridad, identifico la fuente del ruido", "Minimizar el problema y provocar mayor afectación", "Incorrecta interpretación del posible problema", 3, 100);
    Preguntas ES2Q2 = new Preguntas("Al identificar la Fuente", " Trato de sentir alguna vibración con la mano", " No es tan fuerte o raro el ruido, continuo con mi día", 1, 2, " Evaluó el daño, utilizando los 5 sentidos de forma segura", " Riesgo de accidente al tocar equipo en movimiento", " Minimizar el problema y provocar mayor afectación", 3, 100);
    Preguntas ES2Q4 = new Preguntas("Una vez evaluado el problema", " Atender de inmediato, interviniendo el equipo en cuanto deje de moverse", " No informar la anormalidad y dejar que alguien más se encargue", 1, 2, " Llenar el APR, realizar bloqueos efectivos e identificar las actividades necesarias para la solución", " Riesgo de accidente al no realizar el bloqueo efectivo", " Minimizar el problema y provocar mayor afectación", 3, 100);
    //Checar la de abajo
    Preguntas ES2Q6 = new Preguntas("Después de solucionado el daño", " Genero una orden de Mantenimiento", " Informo a Programación para que indique el paro de línea", 4, 4, " Genero un aviso", " Orden de mantenimiento sin información completa del problema", " Programación no es responsable de esta parte del proceso", 3, 100);
    Preguntas ES2Q7 = new Preguntas("Qué tipo de aviso debo generar", " Aviso MB", " Aviso M0", 3, 3, " Aviso M2, sin tilde de Parada", " Este aviso se utiliza para solicitar actividades a un sector diferente al propio", " Este aviso lo genera el Inspector", 3, 100);
    Preguntas ES2Q8 = new Preguntas("¿Que campos deben ser llenados en el Aviso M2?", " Colocar la palabra Vínculos en algún campo", " Agregar multimedia", 2, 2, " Equipo, ¿Qué paso?, ¿Por qué paso?, ¿Qué se hizo?, PARTE OBJETO, SINT.AVERIA y CAUSA", " Esta palabra no informa el detalle de lo ocurrido", " Es opcional, agregar alguna foto al aviso.", 3, 100);
    Preguntas ES2Q9 = new Preguntas("En caso de colocar *OTROS* como Sint.avería o Causa ¿Qué debo colocar en Texto?", " Colocar palabras clave o abreviadas", " Colocar el TAG del equipo", 1, 1, " Agregar el texto con el detalle del problema", " No todas las personas reconocen el significado de nuestras abreviaciones", " Puede ser un dato no rastreable en Sistema", 3, 100);
    Preguntas ES2Q10 = new Preguntas("Sigue caminando y se encuentra al lado de una máquina dañada", "None", " Alguien más se encargara y tengo mucha hambre", 5, 5, " Dado que no traigo equipo de seguridad hago una evaluación rápida con mis 5 sentidos", "None", " Negligencia de tus actividades como guardia", 2, 100);
    Preguntas ES2Q11 = new Preguntas("Otro guardia está haciendo una reparación y se percata que la maquina sigue operando", "None", " La actividad no debe tener nada que ver con la máquina", 4, 4, " Busco que se haga un bloque efectivo de la maquina", "None", " Incorrecta interpretación del posible problema y riesgo de accidente al no realizar el bloqueo efectivo", 2, 100);



    //Template
    //Preguntas tempD3 = new Preguntas("Pre", "Opc1", "Opc2", 0, 0, "Correcta", "Fail1", "Fail2", 3, 0);
    //Preguntas tempD2 = new Preguntas("P1", "None", "Opc1", 0, 0, "Correcta", "None", "Fail1", 2, 0);
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

        Escena = SceneManager.GetActiveScene().name;

        //Debug.Log(Escena.Substring(0,1));
        //Debug.Log(Escena.Substring(0,3));
        //Debug.Log(Escena.Substring(2, 1));

        // Cargar la pregunta correcta
        switch (Escena) {
            //ES1
            case "P1": QA = ES1Q1; break;
            case "P3": QA = ES1Q3; break;
            case "P4": QA = ES1Q4; break;
            case "P5": QA = ES1Q5; break;
            case "P6.5": QA = ES1Q6; break;
            case "P7": QA = ES1Q7; break;
            case "P8": QA = ES1Q8; break;

            //ES2
            case "ES2P1": QA = ES2Q1; break;
            case "ES2P2": QA = ES2Q2; break;
            case "ES2P4": QA = ES2Q4; break;
            case "ES2P6": QA = ES2Q6; break;
            case "ES2P7": QA = ES2Q7; break;
            case "ES2P8": QA = ES2Q8; break;
            case "ES2P9": QA = ES2Q9; break;
            case "ES2P10": QA = ES2Q10; break;
            case "ES2P11": QA = ES2Q11; break;

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

            //string Escena = SceneManager.GetActiveScene().name;

            if(Escena.Substring(0,1) == "P")
            {
                SceneManager.LoadScene("Lose");
            }
            else if(Escena.Substring(0,3) == "ES2")
            {
                SceneManager.LoadScene("ES2Lose");
            }
            //SceneManager.LoadScene("Lose");
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
