using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Bring up Start/Intro Screen

    }

    // Update is called once per frame
    void Update()
    {
        CanvasManager.instance.UpdateHealthBar();
    }


    // --------------------------------------------------
    // Player
    // --------------------------------------------------

    // Player Health
    public float playerHealth = 100;

    // Player Damage
    public float playerDamage = 10;

    // Player Speed
    public float playerSpeed = 5f;

    public void AdjustPlayerHealth(int amount)
    {
        playerHealth += amount;
    }


    // --------------------------------------------------
    // Game States and Settings
    // --------------------------------------------------

    // TODO: Add Game States
    public bool gamePaused = false;

    public void ToggleGamePaused()
    {
        gamePaused = !gamePaused;
    }



    // points
    public int score;

    // time/clock
    public float time;


}
