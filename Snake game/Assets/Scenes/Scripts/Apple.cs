using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour  
{
    private bool active = true;
    public Sprite stub;
    public Sprite apple;
    private SpriteRenderer spriteRenderer;
    private int inactiveTime = 5;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && active)
        {
            Phase();
        }
    }

    public void Phase()
    {
        if (active)
        {
            active = false;
            spriteRenderer.sprite = stub;
            Messenger.Broadcast(GameEvent.APPLE_EATEN);
            GetComponent<Collider2D>().isTrigger = false;
            StartCoroutine(Countdown(inactiveTime));
        } else {
            active = true;
            spriteRenderer.sprite = apple;
            GetComponent<Collider2D>().isTrigger = true;
        }
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {
            yield return new WaitForSeconds(1);
            count--;
        }
        Phase();
    }
}
