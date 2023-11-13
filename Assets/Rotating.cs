using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotationSpeed = 45.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for 'A' or 'D' key presses
        float rotationAmount = 0.0f;

        if (Input.GetKey("d"))
        {
            rotationAmount = -rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("a"))
        {
            rotationAmount = rotationSpeed * Time.deltaTime;
        }
        transform.Rotate(0.0f, 0.0f, rotationAmount, Space.Self);
    }
}
