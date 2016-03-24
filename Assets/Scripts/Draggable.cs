using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public GameObject clone;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		clone = Instantiate<GameObject> (gameObject);
		clone.transform.SetParent(this.transform.parent);
		clone.transform.position = this.transform.position;
		//throw new System.NotImplementedException ();
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		clone.transform.position = eventData.position;
		//throw new System.NotImplementedException ();
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		clone = null;
		//throw new System.NotImplementedException ();
	}

	#endregion
}
