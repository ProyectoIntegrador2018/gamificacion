﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.IO;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

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
            if (GlobalVariables.cont > 0) {
                GlobalVariables.items.Remove(this.gameObject);
                Debug.Log("Removed");
            }
        }
        if (droppedOnSlot == false && itemWasHere == false) {
            Debug.Log("Out of area");
            rectTransform.anchoredPosition = defaultPos;  
        }
        if (droppedOnSlot == true) {
            Debug.Log("Inside of area");
            GlobalVariables.items.Add(this.gameObject);
            Debug.Log("Added");
            itemWasHere = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }

    public static string statusAnswer() {
        Debug.Log(GlobalVariables.items.Count);
        if (GlobalVariables.items.Exists(x => x.name == "Item1") && 
            GlobalVariables.items.Exists(x => x.name == "Item2") && 
            GlobalVariables.items.Exists(x => x.name == "Item3") && 
            GlobalVariables.items.Exists(x => x.name == "Item4") && 
            GlobalVariables.items.Count == 4) {
            Debug.Log("Correct");
            return "Correct";
        } else {
            Debug.Log("Incorrect");
            return "Incorrect";
        }
    }
}
