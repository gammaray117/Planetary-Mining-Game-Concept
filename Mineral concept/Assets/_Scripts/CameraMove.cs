using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	private Vector3 startPos = new Vector3(0,0,0);
	public Vector3 endPos = new Vector3(100,0,0);
	static float moveTime = 0;
	public float moveFactor = 0.01f;
	private GameManager gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindObjectOfType<GameManager>();
		startPos = transform.localPosition;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Mathf.Lerp(transform.position.x,endPos.x,moveTime),transform.position.y,transform.position.z);
		moveTime += moveFactor * Time.deltaTime * gm.gameSpeed;
	}
}
