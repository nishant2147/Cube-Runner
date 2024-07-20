using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallmoving : MonoBehaviour
{
    public float speed = 2.0f;
    private float startX = -2.02f;
    private float endX = 2.02f;
    private bool movingRight = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= endX)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= startX)
            {
                movingRight = true;
            }
        }
    }
}
