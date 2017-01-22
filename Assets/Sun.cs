using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour
{
    Camera cam;

    bool day = true;

    float moveSpeed = 1.0f;
    float frequency;
    float magnitude = 1f;
    float camWidth;
    float camHeight;
    float index = 0f;

    Vector3 axis;
    Vector3 pos;
    Vector3 move;
    Vector3 bottomLeftCam;
    Vector3 camPos;
    Vector3 sunOffset;
    private Vector3 bottomRightCam;

    // Use this for initialization
    void Start()
    {
        // Find the camera
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        camWidth = cam.pixelWidth / 100f;
        camHeight = cam.pixelHeight / 100f;

        // Change to bottom left corner
        bottomLeftCam = new Vector3(cam.transform.position.x - (camWidth / 2), cam.transform.position.y - (camHeight / 2.0f));
        transform.position = bottomLeftCam;

        // Calculate the magnitude and the frequency 
        magnitude = camHeight - GetComponent<SpriteRenderer>().bounds.extents.y;
        //frequency =((camWidth / camHeight) / Mathf.PI);
        frequency = (cam.pixelHeight / 200f) / (Mathf.PI * 10.35f);
        

        // Adjust pos and axis
        pos = transform.position;
        axis = Vector3.up;

        sunOffset = new Vector3(-camWidth * 1.5f, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        //camPos = new Vector3(cam.transform.position.x, cam.transform.position.y);
        //bottomLeftCam = new Vector3(cam.transform.position.x - (camWidth / 2), cam.transform.position.y - (camHeight / 2));
        //bottomRightCam = new Vector3(camPos.x + (camWidth / 2), camPos.y - (camHeight / 2), 0);
        //index += Time.deltaTime;
        //Debug.Log(bottomRightCam);
        //if (transform.position.x > bottomRightCam.x && transform.position.y < bottomRightCam.y)
        //{
        //    //Debug.Log(transform.position);
        //    sunOffset = new Vector3(cam.transform.position.x - (camWidth / 2), cam.transform.position.y - (camHeight / 2));

        //    pos = sunOffset;
        //    move = sunOffset;
        //    transform.position = sunOffset;
        //    day = false;
        //}
        //else
        //{
        //    pos += Vector3.right * Time.smoothDeltaTime * moveSpeed;
        //    move = pos + axis * Mathf.Sin((index) * frequency) * magnitude;
        //}


        if (day)
        {
            transform.position += move;
        }
        //else
        //{
        //    Debug.Log(move);
        //    sunOffset = new Vector3(cam.transform.position.x - (camWidth / 2), cam.transform.position.y - (camHeight / 2));
        //    transform.position = sunOffset;
        //    if (move.y >= bottomRightCam.y + .05f)
        //    {
        //        //Debug.Log(transform.position);
        //        index = 0;
        //        pos = sunOffset;
        //        move = sunOffset;
        //        transform.position = sunOffset;
        //        day = true;
        //    }
        //}
    }
}
