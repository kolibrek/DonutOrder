using UnityEngine;
using UnityEngine.UI;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GridInventory : MonoBehaviour {

	public GameObject[] slots;

	public GameObject thanksPanel;
	public Text totalCostDisplay;
	public float tax = 0.15f;
	public float deliveryFee = 3f;
	float totalCost = 0;

	// Use this for initialization
	void Start () {
		thanksPanel.SetActive(false);
		slots = new GameObject[12];
		for (int i = 0; i < transform.childCount; i++) {
			slots[i] = transform.GetChild(i).gameObject;
		}
	}

	public void Purchase() {
		ClearSlots();
		thanksPanel.SetActive(true);
		thanksPanel.GetComponentInChildren<Text>().text += "\n Your Total: " + totalCost.ToString("C2");
		Invoke("Quit", 2);
	}

	public void ClearSlots() {
		foreach (GameObject slot in slots) {
			if (slot.transform.childCount > 0) {
				Destroy(slot.transform.GetChild(0).gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		float subtotalCost = 0;
		int donutCount = 0;
		foreach (GameObject slot in slots) {
			if (slot.transform.childCount > 0) {
				Donut donut = slot.GetComponentInChildren<Donut>();
				subtotalCost += donut.price;
				donutCount++;
			}
		}

		float taxTotal = donutCount * tax;
		float fee = (donutCount > 0)? deliveryFee : 0f;

		totalCostDisplay.text = "Subtotal: " + subtotalCost.ToString("C2");
		totalCostDisplay.text += "\nTax: " + taxTotal.ToString("C2");
		totalCostDisplay.text += "\nDelivery Fee: " + fee.ToString("C2");
		totalCost = subtotalCost + fee + taxTotal;
		totalCostDisplay.text += "\nTotal Cost: " + totalCost.ToString("C2");
	}

	public void Quit() {
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}
