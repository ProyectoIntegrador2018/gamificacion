using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ItemSlots : MonoBehaviour, IDropHandler {

	int intTag;

	public void OnDrop(PointerEventData eventData) {
    	eventData.pointerDrag.GetComponent<DragDrops>().droppedOnSlot = true;
    	
        Debug.Log("OnDrop");
        GameObject droppedObject = eventData.pointerDrag;
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            intTag = int.Parse(this.gameObject.tag);
	    	Debug.Log(intTag);
	    	GlobalVariables.currentTagItem = intTag;
        }
    }
}