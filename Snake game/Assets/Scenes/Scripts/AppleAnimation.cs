using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleAnimation : MonoBehaviour
{
    [SerializeField] float animationMaxRotation = 0.1f;
    [SerializeField] float animationSpeed = 0.8f;
    [SerializeField] float yScaleDiff = 0.15f;
    [SerializeField] float yScaleSpeed = 0.01f;
    private bool rotationDir = true; //true - left, false - right
    private bool scaleDir = true; //true - increase, false - decrease
    void FixedUpdate()
    {
        if (scaleDir)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + yScaleSpeed, transform.localScale.z);
            if (transform.localScale.y >= 1 + yScaleDiff)
            {
                scaleDir = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - yScaleSpeed, transform.localScale.z);
            if (transform.localScale.y <= 1 - yScaleDiff)
            {
                scaleDir = true;
            }
        }
        if (rotationDir)
        {
            transform.Rotate(0, 0, animationSpeed);
            if (transform.rotation.z >= animationMaxRotation)
            {
                rotationDir = false;
            }
        }
        else
        {
            transform.Rotate(0, 0, -animationSpeed);
            if (transform.rotation.z <= -animationMaxRotation)
            {
                rotationDir = true;
            }
        }
    }
}
