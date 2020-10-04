using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    GameManager manager;

    public int points = 0;

    public int multiplier = 1;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        manager = FindObjectOfType<GameManager>();
    }

    void Start() {
        ResetPoints();
    }

    public void Multiplier(int newMultiplier) {
        if (newMultiplier > 1) {
            multiplier *= newMultiplier;
        }
    }

    void ResetPoints() {
        multiplier = 1;
        points = 999999;
        manager.setPoints(points, multiplier);
    }

    public void DecrementPoints(int pointsChange) {
        points -= pointsChange * multiplier * 7;
        manager.setPoints(points, multiplier);

        if (points <= 0) {
            GameOver();
        }
    }

    public void GameOver() {
        manager.popupMessage("Victory in " + manager.getGameTime() + "\nBut can you go faster?", 5);
        audioManager.play("victory-1");
        manager.finishGame();
        ResetPoints();

        foreach(ScoreableComponent component in FindObjectsOfType<ScoreableComponent>()) {
            component.resetState();
        }
    }
}
