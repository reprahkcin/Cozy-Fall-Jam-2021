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

    private void Update()
    {
        UpdateAcorns();
    }

    // --------------------------------------------------
    // HUD - UI Text Readouts
    // --------------------------------------------------


    public TextMeshProUGUI acornsText;

    public void UpdateAcorns()
    {
        acornsText.text = "Acorns: " + GameManager.instance.nutsToThrow;
    }

    // feedback
    public TextMeshProUGUI feedbackText;

    public void SetFeedback(string feedback, float duration)
    {
        feedbackText.text = feedback;
        StartCoroutine(ClearFeedback(duration));
    }

    IEnumerator ClearFeedback(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        feedbackText.text = "";
    }


    // --------------------------------------------------
    // HUD - UI Buttons
    // --------------------------------------------------
    // TODO: Navigation buttons, start, exit, etc.
    // pause button
    //public Button pauseButton;




    // --------------------------------------------------
    // HUD - UI Panels
    // --------------------------------------------------

    public GameObject[] panels;

    // Intro Panel
    public GameObject introPanel;

    // Lose Panel
    public GameObject losePanel;

    // Win Panel
    public GameObject winPanel;

    // HUD Panel
    public GameObject hudPanel;

    // Pause/Instructions Panel
    public GameObject pausePanel;

    // Deactivate all panels
    // TODO: Load all panels into array, even specific panels above
    public void DeactivateAllPanels()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    // Activate Intro Panel
    public void ActivateIntroPanel()
    {
        DeactivateAllPanels();
        introPanel.SetActive(true);
    }

    // Activate Lose Panel
    public void ActivateLosePanel()
    {
        DeactivateAllPanels();
        losePanel.SetActive(true);
    }

    // Activate Win Panel
    public void ActivateWinPanel()
    {
        DeactivateAllPanels();
        winPanel.SetActive(true);
    }

    // Activate HUD Panel
    public void ActivateHUDPanel()
    {
        DeactivateAllPanels();
        hudPanel.SetActive(true);
    }

    // Activate Pause Panel
    public void ActivatePausePanel() => pausePanel.SetActive(true);

    // Deactivate Pause Panel
    public void DeactivatePausePanel() => pausePanel.SetActive(false);

}
