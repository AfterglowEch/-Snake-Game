using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePositionUnrel = Input.mousePosition;
        Vector3 positionOnScreenUnrel = Camera.main.WorldToScreenPoint(transform.position);
        mousePositionUnrel.x -= positionOnScreenUnrel.x;
        mousePositionUnrel.y -= positionOnScreenUnrel.y;
        float angle = Mathf.Atan2(mousePositionUnrel.y, mousePositionUnrel.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), Time.deltaTime * rotationSpeed);
    }
}
