using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {

	private GameManager gm;
	public float cloudSpeed = 1;
	private float speed = 1;
//	private float origPos;
//	private float newPos;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindObjectOfType<GameManager>();
		speed = cloudSpeed * gm.gameSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.localPosition.x > -160){
			transform.Translate(Vector3.left*speed*Time.deltaTime);
		} else{
			transform.localPosition = new Vector3(160,0,0);

		}
	}
}
