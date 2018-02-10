using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTouch : MonoBehaviour {

	public int sceneToChangeTo = 1;

	// Use this for initialization
	void Start () {
		//interactableObject = GetComponentInParent<VRTK_InteractableObject> ();
		//interactableObject.InteractableObjectGrabbed += new InteractableObjectEventHandler (ChangeScene);
	}

	// Update is called once per frame
	void OnTiggerEnter (Collider other) {

		if (other.gameObject.tag == "GameController") {
			ChangeScene ();
		}

	}

	void ChangeScene(){
		SceneManager.LoadScene (sceneToChangeTo);
	}
}