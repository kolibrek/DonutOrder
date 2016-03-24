using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Donut : MonoBehaviour {

	float price;
	Shape shape;
	Dough dough;
	Glaze glaze;
	List<Toppings> toppings;

	public Donut() {
		price = 1.00f;
		shape = Shape.Loop;
		dough = Dough.Original;
		glaze = Glaze.None;
		toppings = new List<Toppings> ();
	}

	public void SetShape(Shape shapeType) {
		shape = shapeType;
	}

	public void SetDough(Dough doughType) {
		dough = doughType;
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
		info += dough.ToString () + '\n';
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
	Bar,
	Filled
}

public enum Dough {
	Original,
	SourCream,
	Chocolate,
	Cake
}

public enum Glaze {
	None,
	Glaze,
	Maple,
	Powdered,
	Chocolate,
	StrawberryIce
}

public enum Toppings {
	None,
	Sprinkles,
	Drizzle,
	ChocolateChip,
	CookieCrumble
}
