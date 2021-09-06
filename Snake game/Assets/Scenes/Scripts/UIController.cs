using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{
    private int score;
    public Text scoreLabel;
    public GameObject restartButtonPrefab;
    public GameObject canvas;
    private bool isGameOver = false;
    void Awake()
    {
        Messenger.AddListener(GameEvent.APPLE_EATEN, AppleEaten);
        Messenger.AddListener(GameEvent.GAME_OVER, GameOver);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.APPLE_EATEN, AppleEaten);
        Messenger.RemoveListener(GameEvent.GAME_OVER, GameOver);
    }
    void Start()
    {
        score = 0;
        scoreLabel.text = "Score: " + score.ToString();
    }
    private void AppleEaten()
    {
        if (!isGameOver)
        {
            score += 1;
            scoreLabel.text = "Score: " + score.ToString();
        }
    }

    private void GameOver()
    {
        GameObject newButton = Instantiate(restartButtonPrefab);
        newButton.transform.SetParent(canvas.transform, false);
    }
    public void OnPlayClick()
    {
        Messenger.Broadcast(GameEvent.GAME_BEGINS);
    }
}