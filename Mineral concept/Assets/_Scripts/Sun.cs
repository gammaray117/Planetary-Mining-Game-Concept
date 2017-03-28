using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {

	private DayNightCycle dayNight;

	public float minAngle = 0f;
	public float maxAngle = 90f;
	public float angle = 0f;

	// Use this for initialization
	void Start () {
		dayNight = GameObject.FindObjectOfType<DayNightCycle>();
	}
	
	// Update is called once per frame
	void Update () {
		angle = Mathf.Lerp(minAngle,maxAngle,dayNight.lerpTValue);
		transform.eulerAngles = new Vector3(0,0,angle);

	}

}
