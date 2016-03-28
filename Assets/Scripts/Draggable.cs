using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	Vector3 initialPosition;


	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData) {
		initialPosition = this.transform.position;
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData) {
		this.transform.position = eventData.position;
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData) {

		GameObject slot = CheckDrop(eventData);

		if (slot != null) {
			if (!gameObject.name.Contains("(Clone)")) {
				if (slot.name != "Trash") {
					GameObject clone = Instantiate<GameObject>(this.gameObject);
					clone.transform.SetParent(slot.transform);
					clone.transform.localPosition = new Vector3(25f,-25f,0f);
				}
				this.transform.position = initialPosition;
			} else {
				if (slot.gameObject.name == "Trash") {
					Destroy(this.gameObject);
				} else {
					this.transform.SetParent(slot.transform);
					this.transform.localPosition = new Vector3(25f,-25f,0f);
				}
			}
		} else {
			this.transform.position = initialPosition;
		}
	}

	#endregion

	GameObject CheckDrop(PointerEventData eventData) {

		List<RaycastResult> raycastResults = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, raycastResults);
		
		if (raycastResults.Count > 2) {
			foreach (RaycastResult result in raycastResults) {
				if (result.gameObject.name.Contains("Slot") || result.gameObject.name == "Trash") {
					return result.gameObject;
				}
			}
		}
		return null;
	}
}
