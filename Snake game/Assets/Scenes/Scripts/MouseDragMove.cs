using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MouseDragMove : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float speed = 10f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 objectPosition = transform.position;
        Vector2 direction = normalizedDirection(mousePosition, objectPosition);
        rigidBody.velocity = new Vector2(direction.x * speed, direction.y * speed);
        //transform.Translate(speed * Time.deltaTime, 0, 0, Space.Self);
    }

    private Vector2 normalizedDirection(Vector2 mousePosition, Vector2 objectPosition)
    {
        Vector2 direction = (mousePosition - objectPosition);
        float normalizingFactor = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
        Vector2 normalizedDirection;
        if (normalizingFactor > 0.01f)
        {
            normalizedDirection = new Vector2((direction.x / normalizingFactor), (direction.y / normalizingFactor));
        } else {
            normalizedDirection = new Vector2(1, 0);
        }
        return normalizedDirection;
    }
}
