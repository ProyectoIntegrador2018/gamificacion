using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.IO;

public class DragDrops : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
    
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 defaultPos;
    public bool droppedOnSlot = false;
    private bool itemWasHere = false;
    

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        defaultPos = GetComponent<RectTransform>().localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        droppedOnSlot = false;
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (droppedOnSlot == false && itemWasHere == true) {
        	Debug.Log("Out of area");
        	rectTransform.anchoredPosition = defaultPos; 
        	GlobalVariables.pairAnswerSlot.Remove(int.Parse(this.gameObject.tag));
        	Debug.Log("Count: " + GlobalVariables.pairAnswerSlot.Count);
        }
        if (droppedOnSlot == false && itemWasHere == false) {
            Debug.Log("Out of area");
            rectTransform.anchoredPosition = defaultPos;
            Debug.Log("Count: " + GlobalVariables.pairAnswerSlot.Count);
        }
        if (droppedOnSlot == true) {
        	Debug.Log("Inside of area");
        	itemWasHere = true;
        	int intTag = int.Parse(this.gameObject.tag);
        	Debug.Log(intTag);
        	GlobalVariables.pairAnswerSlot.Add(intTag, GlobalVariables.currentTagItem);
        	Debug.Log("Count: " + GlobalVariables.pairAnswerSlot.Count);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    public static string statusAnswer() {
    	string answer;
        foreach(KeyValuePair<int, int> x in GlobalVariables.pairAnswerSlot) {
        	// Debug.Log(x.Key);
        	// Debug.Log(x.Value);
        	if (x.Key == x.Value) {
        		Debug.Log("Correct");
        		answer = "Correct";
        	} else {
        		Debug.Log("Incorrect");
        		return "Incorrect";
        		break;
        	}
        }
        return "Correct";
    }
}
