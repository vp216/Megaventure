using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadtxt1 : MonoBehaviour {
	public string txtFile = "2005";
	string txtContents;

	// Use this for initialization
	void Start () {
		TextAsset txtAssets = (TextAsset)Resources.Load (txtFile);
		txtContents = txtAssets.text;
		
	}

	void OnGUI () {
		GUILayout.Label (txtContents);
	}

}
