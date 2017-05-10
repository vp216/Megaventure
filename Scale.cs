using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour {

	public float maxScale = 10.0f;
	public float minScale = 2.0f;
	public float shrinkSpeed = 1.0f;    

	private float targetScale;
	private Vector3 v3Scale;

	void Start() {
		v3Scale = transform.localScale;    
	}

	void Update()
	{
		RaycastHit hit;
		Ray ray;

		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.transform == transform) {
				targetScale = minScale;
				v3Scale = new Vector3(targetScale, targetScale, targetScale);
			}

		}

		if (Input.GetMouseButtonDown (1)) {
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.transform == transform) {
				targetScale = maxScale;
				v3Scale = new Vector3(targetScale, targetScale, targetScale);
			}
		}

		transform.localScale = Vector3.Lerp(transform.localScale, v3Scale, Time.deltaTime*shrinkSpeed);
	}
}