using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour
{
    public int points;

    ScoreManager manager;

    public void Awake() {
        manager = FindObjectOfType<ScoreManager>();
    }

    public void score() {
        manager.DecrementPoints(points);
    }
}
