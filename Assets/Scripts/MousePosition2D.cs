using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition2D : MonoBehaviour
{
    Vector2 direction;
    private float time;

    public bool _facingRight = true;

    public float offset;

    

    

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if ((difference.x < 0 && _facingRight) || (difference.x > 0 && !_facingRight))
        {   
            transform.rotation = Quaternion.Euler(180f, 0f, -rotZ + offset);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
    }

    
}