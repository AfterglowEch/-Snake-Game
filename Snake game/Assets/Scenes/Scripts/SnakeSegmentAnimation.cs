using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegmentAnimation : MonoBehaviour
{
    [SerializeField] float scaleDiff = 0.15f;
    [SerializeField] float scaleSpeed = 0.01f;
    private bool scaleDir = true; //true - increase, false - decrease
    private float startingScale;
    [SerializeField] float appleConsumingMaxScale = 0.6f;
    [SerializeField] float appleConsumingScaleSpeed = 0.05f;
    private bool appleConsuming = false;
    private bool appleConsumingDrawback = false;

    void Awake()
    {
        Messenger.AddListener(GameEvent.APPLE_EATEN, AppleEaten);
    }
    private void Start()
    {
        startingScale = transform.localScale.x;
    }

    void FixedUpdate()
    {
        if (scaleDir)
        {
            transform.localScale = new Vector3(transform.localScale.x + scaleSpeed * startingScale, transform.localScale.y + scaleSpeed * startingScale, transform.localScale.z);
            if (transform.localScale.x >= startingScale * (1 + scaleDiff))
            {
                scaleDir = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x - scaleSpeed * startingScale, transform.localScale.y - scaleSpeed * startingScale, transform.localScale.z);
            if (transform.localScale.x <= startingScale * (1 - scaleDiff))
            {
                scaleDir = true;
            }
        }
        if (appleConsuming)
        {
            transform.localScale = new Vector3(transform.localScale.x + appleConsumingScaleSpeed * startingScale, transform.localScale.y + appleConsumingScaleSpeed * startingScale, transform.localScale.z);
            if (transform.localScale.x >= startingScale * (1 + appleConsumingMaxScale))
            {
                appleConsuming = false;
                appleConsumingDrawback = true;
            }
        }
        if (appleConsumingDrawback)
        {
            transform.localScale = new Vector3(transform.localScale.x - appleConsumingScaleSpeed * startingScale, transform.localScale.y - appleConsumingScaleSpeed * startingScale, transform.localScale.z);
            if (transform.localScale.x <= startingScale)
            {
                appleConsumingDrawback = false;
            }
        }
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.APPLE_EATEN, AppleEaten);
    }

    private void AppleEaten()
    {
        appleConsuming = true;
    }
}
