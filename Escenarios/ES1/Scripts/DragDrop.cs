using System.Collections;
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
    public List<GameObject> items;
    public int cont = 0;

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
        if (droppedOnSlot == false) {
            Debug.Log("Out of area");
            rectTransform.anchoredPosition = defaultPos;  
            if (cont == 0) {
                items.Remove(this.gameObject);
                Debug.Log("Removed");
            }
            if (cont > 0) {
                items.Remove(this.gameObject);
                Debug.Log("Removed");
                cont--;
            }
        }
        if (droppedOnSlot == true) {
            Debug.Log("Inside of area");
            items.Add(this.gameObject);
            Debug.Log("Added");
            cont++;
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("OnPointerDown");
    }
}

