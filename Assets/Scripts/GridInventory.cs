using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridInventory : MonoBehaviour {

	public GameObject[] slots;
	public Text totalCostDisplay;
	public float totalCost;

	// Use this for initialization
	void Start () {
		slots = new GameObject[12];
		for (int i = 0; i < transform.childCount; i++) {
			slots[i] = transform.GetChild(i).gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		totalCost = 0;
		foreach (GameObject slot in slots) {
			if (slot.transform.childCount > 0) {
				Donut donut = slot.GetComponentInChildren<Donut>();
				totalCost += donut.price;
			}
		}
		totalCostDisplay.text = "Total Cost: " + totalCost.ToString("C2");
	}
}
