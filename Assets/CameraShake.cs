using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	public static float shake;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (shake > 0){
			shake -= Time.deltaTime * 5f;
			this.transform.localPosition = Random.insideUnitSphere * shake;
		}
		else {
			this.transform.localPosition = Vector3.zero;
			shake = 0;
		}
	}
}
