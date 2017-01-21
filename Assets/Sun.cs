using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {
    float moveSpeed = 1.0f;
    float frequency = .175f;
    float magnitude = 1f;
    Vector3 axis;
    Vector3 pos;
	// Use this for initialization
	void Start () {
        Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        Debug.Log(cam.transform.position);
        transform.position = new Vector3(cam.transform.position.x - (cam.pixelWidth / 200f), cam.transform.position.y - (cam.pixelHeight / 200f), 0);
        magnitude = (cam.pixelHeight / 100) - GetComponent<SpriteRenderer>().bounds.extents.y;
        pos = transform.position;
        axis = Vector3.up;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        pos += Vector3.right * Time.smoothDeltaTime * moveSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
	}
}
