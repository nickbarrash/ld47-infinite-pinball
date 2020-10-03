using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TextMeshProUGUI points;
    TextMeshProUGUI time;
    TextMeshProUGUI best;
    TextMeshProUGUI popup;

    float VISIBLE_DURATION = 3;
    float FADE_DURATION = 1;
    float visibleTimer = 0;
    float fadeTimer = 0;

    float gameTime = 0;
    float bestTime = -1;

    void Awake()
    {
        points = GameObject.Find("GameOverlay/Points").GetComponent<TextMeshProUGUI>();
        time = GameObject.Find("GameOverlay/Time").GetComponent<TextMeshProUGUI>();
        best = GameObject.Find("GameOverlay/Best").GetComponent<TextMeshProUGUI>();
        popup = GameObject.Find("GameOverlay/Popup").GetComponent<TextMeshProUGUI>();
    }

    void Start() {
        popupMessage("CONTROLS ARE:\nLEFT SHIFT + RIGHT SHIFT");
        setBest(-1);
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        setTime();

        if (visibleTimer > 0) {
            visibleTimer -= Time.deltaTime;
        } else if (fadeTimer > 0) {
            fadeTimer -= Time.deltaTime;
            byte visible = (byte)(255f - Mathf.Lerp(FADE_DURATION, 0f, fadeTimer) * 255f);
            popup.color = new Color32(255, 255, 255, visible);
        }
    }
    public void popupMessage(string message) {
        visibleTimer = VISIBLE_DURATION;
        fadeTimer = FADE_DURATION;

        popup.text = message;
        popup.color = new Color32(255, 255, 255, 255);
    }

    public void setPoints(int currentPoints) {
        points.text = currentPoints.ToString();
    }

    public string timerToString(float timer) {
        return string.Format(
            "{0}:{1}", Mathf.Floor(timer / 60).ToString("00"), (timer % 60).ToString("00")
        );
    }

    public void setTime() {
        time.text = timerToString(gameTime);
    }

    public void finishGame() {
        setBest(gameTime);
        gameTime = 0;
    }

    public void setBest(float newTime) {
        if (newTime < 0) {
            best.gameObject.SetActive(false);
            return;
        }

        best.gameObject.SetActive(true);
        bestTime = bestTime < 0 ? newTime : Mathf.Min(bestTime, newTime);
        best.text = "(Best) " + timerToString(bestTime);
    }
}
