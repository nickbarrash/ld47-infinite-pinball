using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    GameManager manager;

    int points = 10;

    // Start is called before the first frame update
    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void Start() {
        ResetPoints();
    }

    void ResetPoints() {
        points = 10;
        manager.setPoints(points);
    }

    public void DecrementPoints(int pointsChange) {
        points -= pointsChange;
        manager.setPoints(points);

        if (points <= 0) {
            GameOver();
        }
    }

    public void GameOver() {
        manager.finishGame();
        ResetPoints();
        manager.popupMessage("But can you do it faster?");
    }
}
