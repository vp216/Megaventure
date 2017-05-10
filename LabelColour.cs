using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelColour : MonoBehaviour {

	public InputField labelToChange;
	GUIText label;

	/*
	 * The label variable is checked for a null value as the Search Functionality may have been used previously.
	 * If so, the existing label colour is reset to white.
	 * 
	 * The searched for rides' label is then found and its colour set to a black highlight.
	 * 
	 * 
	 */

	public void ChangeColour()
	{
		if (label != null)
			label.color = Color.white;
		GameObject labelObject = transform.Find (labelToChange.text + " Label").gameObject ;
		label = labelObject.GetComponent<GUIText> ();
		label.color = Color.black;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
