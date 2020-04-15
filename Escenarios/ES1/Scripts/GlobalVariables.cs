using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int cont = 0;
    public static int sumPos = -20;
    public static List<GameObject> items = new List<GameObject>();
    public static Dictionary<int, int> pairAnswerSlot = new Dictionary<int, int>();
    public static int currentTagItem = 0;
}
