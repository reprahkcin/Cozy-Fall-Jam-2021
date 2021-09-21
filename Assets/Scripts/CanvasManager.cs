using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    // Singleton
    public static CanvasManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // --------------------------------------------------
    // HUD - UI Text Readouts
    // --------------------------------------------------

    // points
    public int score;
    public TextMeshProUGUI pointsText;

    // Update points in HUD
    public void UpdateScore()
    {
        pointsText.text = "Score: " + score;
    }


    // time
    public float time;
    public TextMeshProUGUI timeText;
    public void SetTime(int time)
    {
        this.time = time;
    }

    // Update time in HUD
    public void UpdateTime()
    {
        timeText.text = "Time: " + time.ToString("F2"); // F2 = 2 decimal places
    }

    // feedback
    public TextMeshProUGUI feedbackText;

    public void AddPoints(int points)
    {
        this.score += points;
    }

    public void SetFeedback(string feedback)
    {
        feedbackText.text = feedback;
        StartCoroutine(ClearFeedback(3.0f));
    }

    IEnumerator ClearFeedback(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        feedbackText.text = "";
    }

    // Health Bar
    public Image healthBar;

    // Update Health Bar in HUD
    public void UpdateHealthBar()
    {
        // Get Player health
        float health = GameManager.instance.playerHealth / 100;

        // if health is less than 0, set health to 0
        if (health < 0)
        {
            health = 0;
        }

        // if health is greater than 1, set health to 1
        if (health > 1)
        {
            health = 1;
        }

        // Set health bar to health
        healthBar.transform.localScale = new Vector3(health, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    // --------------------------------------------------
    // HUD - UI Buttons
    // --------------------------------------------------
    // TODO: Navigation buttons, start, exit, etc.
    // pause button
    public Button pauseButton;

    // Update pause button in HUD
    public void UpdatePauseButton()
    {
        if (GameManager.instance.gamePaused)
        {
            pauseButton.GetComponentInChildren<TextMeshProUGUI>().text = "Resume";
        }
        else
        {
            pauseButton.GetComponentInChildren<TextMeshProUGUI>().text = "Pause";
        }
    }


    // --------------------------------------------------
    // HUD - UI Panels
    // --------------------------------------------------

    public GameObject[] panels;

    // Set panel to active
    public void SetPanelActive(int index)
    {
        // For each panel, deactivate
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // Activate panel at index
        panels[index].SetActive(true);
    }

}
