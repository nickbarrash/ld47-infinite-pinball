using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour
{
    public int points;
    public int multiplier = 1;
    ScoreManager manager;

    public void Awake() {
        manager = FindObjectOfType<ScoreManager>();
    }

    public void score() {
        manager.Multiplier(multiplier);
        manager.DecrementPoints(points);
    }
}
