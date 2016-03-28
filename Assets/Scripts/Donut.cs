using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Donut : MonoBehaviour {

	public float price;
	public Shape shape;
	public Glaze glaze;
	public List<Toppings> toppings;

	void Start () {
		toppings = new List<Toppings>();
	}

	public void SetShape(Shape shapeType) {
		shape = shapeType;
	}

	public void SetGlaze(Glaze glazeType) {
		glaze = glazeType;
	}

	public void AddTopping(Toppings toppingType) {
		toppings.Add (toppingType);
	}

	public void RemoveTopping(Toppings toppingType) {
		toppings.Remove (toppingType);
	}

	public override string ToString() {
		string info = "Donut: \n";
		info += shape.ToString () + '\n';
		info += glaze.ToString () + '\n';
		for (int i = 0; i < toppings.Count; i++) {
			info += toppings[i].ToString () + '\n';
		}
		info += "Price: " + price.ToString("c2");

		return info;
	}
}

public enum Shape {
	Loop,
	Filled
}

public enum Glaze {
	None,
	Glaze,
	Maple,
	Chocolate
}

public enum Toppings {
	Sprinkles,
	Drizzle,
	ChocolateChip,
	CookieCrumble
}
