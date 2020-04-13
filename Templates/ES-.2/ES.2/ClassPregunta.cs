using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassPregunta : MonoBehaviour
{

    public class Questions
    {
        // Constructor that takes no arguments:
        public Questions()
        {
            string Question = "";
            string Opt1 = "";
            string Opt2 = "";
            string Opt3 = "";
            string Fail1 = "";
            string Fail2 = "";
            int Correct = 0;
        }

        // Constructor with arguments
        public Questions(string question, string opt1, string opt2, string opt3, string fail1, string fail2, int correct)
        {
            string Question = question;
            string Opt1 = opt1;
            string Opt2 = opt2;
            string Opt3 = opt3;
            string Fail1 = fail1;
            string Fail2 = fail2;
            int Correct = correct;
        }

        /*
        // Auto-implemented readonly property:
        public string Name { get; }

        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return Name;
        }
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
