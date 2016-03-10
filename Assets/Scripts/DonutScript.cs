using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DonutScript : MonoBehaviour {

	List<Donut> donuts;
	public Text donutInfo;

	// Use this for initialization
	void Start () {
		donutInfo = GameObject.Find ("DonutInfo").GetComponent<Text> ();
		donuts = new List<Donut> ();
	}

	// Update is called once per frame
	void Update () {
		if (donuts.Count > 0) {
			Display();
		}
	}

	public void Display() {
		string donutList = "";
		for (int i = 0; i < donuts.Count; i++) {
			donutList += "[\n";
			donutList += donuts[i].ToString();
			donutList += "\n]";
		}
		donutInfo.text = donutList;
	}

	public void AddDonut() {
		Donut new_donut = ScriptableObject.CreateInstance<Donut>();
		donuts.Add (new_donut);
	}
}
