using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    TextMeshProUGUI points;
    TextMeshProUGUI time;
    TextMeshProUGUI best;
    TextMeshProUGUI popup;
    TextMeshProUGUI multiplier;
    TextMeshProUGUI soundButton;

    Image blackOverlay;

    float VISIBLE_DURATION = 2;
    float FADE_DURATION = 1;

    float visibleTimer = 0;
    float fadeTimer = 0;

    float gameTime = 0;
    float bestTime = -1;

    float PANEL_VISIBLE_DURATION = 7f;
    float PANEL_FADE_DURATION = 1f;

    float panelVisibleTimer;
    float panelFadeTimer;

    float WIN_CONDITION_DELAY = 3f;
    float winConditionTimer = 0;

    void Awake()
    {
        points = GameObject.Find("GameOverlay/Points").GetComponent<TextMeshProUGUI>();
        multiplier = GameObject.Find("GameOverlay/Multiplier").GetComponent<TextMeshProUGUI>();
        time = GameObject.Find("GameOverlay/Time").GetComponent<TextMeshProUGUI>();
        best = GameObject.Find("GameOverlay/Best").GetComponent<TextMeshProUGUI>();
        popup = GameObject.Find("GameOverlay/Popup").GetComponent<TextMeshProUGUI>();

        blackOverlay = GameObject.Find("GameOverlay/Panel").GetComponent<Image>();
        soundButton = GameObject.Find("GameOverlay/SoundButton/SoundLabel").GetComponent<TextMeshProUGUI>();

        winConditionTimer = WIN_CONDITION_DELAY;
    }

    void IntroScreen1() {
        popupMessage("Infinite Pinball\n\nby nick barrash", 2);
        panelVisibleTimer = PANEL_VISIBLE_DURATION;
    }

    void Start() {
        setBest(-1);
        IntroScreen1();
        blackOverlay.color = new Color32(0, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (winConditionTimer > 0) {
            winConditionTimer -= Time.deltaTime;
            if (winConditionTimer <= 0) {
                popupMessage("Get 999999 points to win", 3);
            }
        }

        if (panelFadeTimer > 0) {
            panelFadeTimer -= Time.deltaTime;

            byte visible = (byte)(255f - Mathf.Lerp(PANEL_FADE_DURATION, 0f, panelFadeTimer) * 255f);
            blackOverlay.color = new Color32(0, 0, 0, visible);
        }

        if(panelVisibleTimer > 0) {
            panelVisibleTimer -= Time.deltaTime;
            if (panelVisibleTimer <= 0) {
                popupMessage("CONTROLS ARE:\n\nZ and M", 5);
                panelFadeTimer = PANEL_FADE_DURATION;
            }
        }

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
    public void popupMessage(string message, float visTime) {
        visibleTimer = visTime;
        fadeTimer = FADE_DURATION;

        popup.text = message;
        popup.color = new Color32(255, 255, 255, 255);
    }

    public void setPoints(int currentPoints, int currentMult) {
        points.text = currentPoints.ToString();
        multiplier.text = "x" + currentMult.ToString();
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

    public void setSound(bool sound) {
        soundButton.text = sound ? "Sound On" : "Sound Off";
    }
}
