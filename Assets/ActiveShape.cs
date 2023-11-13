using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShape : MonoBehaviour
{
    public Transform[] objects;
    public Transform[] targetObjects;
    public GameObject particleEffect;
    private int activeObjectIndex = 0;
    public float rotationSpeed = 45.0f;
    private int alignmentErrorThreshold = 5;
    public GameObject winEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){
        bool isCapsuleSimilar = isSimilarCapsule(0);
        bool isCubeSimilar = isSimilarCube(1);

        Debug.Log("Capsule Similar: " + isCapsuleSimilar);
        Debug.Log("Cube Similar: " + isCubeSimilar);


        if (isCapsuleSimilar && isCubeSimilar) {
            winEffect.SetActive(true);
        } else {
            winEffect.SetActive(false);
        }


        float rotationAmount = 0.0f;


        if (Input.GetKeyDown("w"))  
        {
            SwitchObject(-1);
        }
        else if (Input.GetKeyDown("s"))
        {
            SwitchObject(1);
        }

    
        else if (Input.GetKey("d"))
        {
            rotationAmount = -rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey("a"))
        {
            rotationAmount = rotationSpeed * Time.deltaTime;
        }
        objects[activeObjectIndex].gameObject.transform.Rotate(0.0f, 0.0f, rotationAmount, Space.Self);
    }

    void SwitchObject(int direction)
    {
        //objects[activeObjectIndex].gameObject.SetActive(false);
        activeObjectIndex += direction;

        if (activeObjectIndex < 0)
        {
            activeObjectIndex = objects.Length - 1;
        }
        else if (activeObjectIndex >= objects.Length)
        {
            activeObjectIndex = 0;
        }
        particleEffect.transform.position = objects[activeObjectIndex].gameObject.transform.position;
        particleEffect.SetActive(false);
        particleEffect.SetActive(true);

        //objects[activeObjectIndex].gameObject.SetActive(true);
    }

    bool isSimilarCube(int index) {
        Transform targetObject = targetObjects[index];
        Transform manipulatedObject = objects[index];
        float zRotationDifference = Math.Abs(targetObject.localEulerAngles.z - manipulatedObject.localEulerAngles.z);
        if (zRotationDifference < alignmentErrorThreshold || Math.Abs(zRotationDifference - 90) < alignmentErrorThreshold || Math.Abs(zRotationDifference - 180) < alignmentErrorThreshold || Math.Abs(zRotationDifference - 270) < alignmentErrorThreshold){
            return true;
        }
        return false;
    }

    bool isSimilarCapsule(int index) {
        Transform targetObject = targetObjects[index];
        Transform manipulatedObject = objects[index];
        float zRotationDifference = Math.Abs(targetObject.localEulerAngles.z - manipulatedObject.localEulerAngles.z);
        if (zRotationDifference < alignmentErrorThreshold || Math.Abs(zRotationDifference - 180) < alignmentErrorThreshold){
            return true;
        }
        return false;
    }
 


}

