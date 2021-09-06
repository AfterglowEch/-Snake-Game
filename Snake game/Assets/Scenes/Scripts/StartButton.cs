using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_BEGINS, GameBegins);
    }
    
    private void GameBegins()
    {
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_BEGINS, GameBegins);
    }
}
