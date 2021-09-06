using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryTracker : MonoBehaviour
{
    public float trackingTime = 0.4f;
    public List<Vector2> trajectoryPoints = new List<Vector2>();
    private int trajectoryPointsNum;
    private bool isGameOver = false;
    private Vector2 randomDirection;

    void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_OVER, GameOver);
    }
    void Start()
    {
        trajectoryPointsNum = (int)Mathf.Round(trackingTime / 0.02f);
    }

    void FixedUpdate()
    {
        if (!isGameOver)
        {
            if (trajectoryPoints.Count >= trajectoryPointsNum)
            {
                trajectoryPoints.RemoveAt(0);
            }
            trajectoryPoints.Add(this.transform.position);
        } else {
            if (GetComponent<SnakeEssentials>() == null)
            {
                transform.Translate(randomDirection * Time.deltaTime);
            }
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        randomDirection = Random.insideUnitCircle.normalized;
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_OVER, GameOver);
    }
}
