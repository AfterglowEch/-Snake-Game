using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeEssentials : MonoBehaviour
{
    public List<GameObject> segments = new List<GameObject>();
    public List<Vector2> trajectoryPoints = new List<Vector2>();
    public GameObject segmentPrefab;
    private float speedSave;
    private bool isGameOver = false;

    void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_BEGINS, GameBegins);
        Messenger.AddListener(GameEvent.GAME_OVER, GameOver);
        speedSave = GetComponent<MouseDragMove>().speed;
        GetComponent<MouseDragMove>().speed = 0f;
    }
    void Start()
    {
        segments.Add(gameObject);
    }

    void FixedUpdate()
    {
        if (!isGameOver) {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].transform.position = segments[i - 1].
                    GetComponent<TrajectoryTracker>().trajectoryPoints[(int)Mathf.Round(
                        segments[i - 1].GetComponent<TrajectoryTracker>().trajectoryPoints.Count / 2)];
            }
        }
    }

    public void Grow()
    {
        GameObject segmentInstantiated = Instantiate(segmentPrefab);
        segmentInstantiated.GetComponent<TrajectoryTracker>().trackingTime = GetComponent<TrajectoryTracker>().trackingTime;
        TrajectoryTracker lastTracker = segments.Last().GetComponent<TrajectoryTracker>();
        segmentInstantiated.transform.position = lastTracker.trajectoryPoints[(int)Mathf.Round(lastTracker.trajectoryPoints.Count / 2)];
        segments.Add(segmentInstantiated);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
        }
        else if (other.CompareTag("Obstacle"))
        {
            Messenger.Broadcast(GameEvent.GAME_OVER);
        }
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_BEGINS, GameBegins);
        Messenger.RemoveListener(GameEvent.GAME_OVER, GameOver);
    }

    private void GameBegins()
    {
        GetComponent<MouseDragMove>().speed = speedSave;
    }
    private void GameOver()
    {
        //Destroy(GetComponent<MouseDragMove>());
        GetComponent<MouseDragMove>().speed = 0f;
        Destroy(GetComponent<MouseRotate>());
        isGameOver = true;
    }
}
