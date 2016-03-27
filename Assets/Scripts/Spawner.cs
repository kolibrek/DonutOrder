using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnObject;
	GameObject clone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Spawn() {
		clone = Instantiate<GameObject>(spawnObject);
		clone.transform.SetParent(this.transform.parent);
		clone.transform.position = Input.mousePosition;
	}
}
