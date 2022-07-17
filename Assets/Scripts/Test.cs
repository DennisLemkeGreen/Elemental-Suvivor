using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Camera camera;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position += new Vector3(0.0f, 1.0f * Time.deltaTime);
        else if (Input.GetKey(KeyCode.DownArrow))
            transform.position += new Vector3(0.0f, -1.0f * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += new Vector3(-1.0f * Time.deltaTime, 0.0f);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(1.0f * Time.deltaTime, 0.0f);
        camera.transform.position = transform.position + new Vector3(0.0f, 0.0f, -10.0f);
    }
}
