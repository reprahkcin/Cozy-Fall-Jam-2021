using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        CanvasManager.instance.ActivateIntroPanel();
    }


    void FixedUpdate()
    {
        // if game is unpaused
        if (GameManager.instance.gamePaused == false && time > 0)
            time -= Time.deltaTime;
    }



    // --------------------------------------------------
    // Game Variables
    // --------------------------------------------------

    // Defense Points
    public int defensePoints = 10;

    // time/clock
    public float time;
    public void AdjustTime(float amount) => time += amount;

    // Current Level
    public int currentLevel;




    // --------------------------------------------------
    // Game States and Settings
    // --------------------------------------------------


    // TODO: Add Game States
    public bool gamePaused = true;

    public void ToggleGamePaused() => gamePaused = !gamePaused;

    public void StartGame()
    {
        // TODO: Any clocks or timers should be addressed here
        // TODO: 3...2...1...GO! animation
        CanvasManager.instance.ActivateHUDPanel();
        StartCoroutine(CountdownOverlay());
        Debug.Log("Game Started");
    }

    IEnumerator CountdownOverlay()
    {
        CanvasManager.instance.SetFeedback("3", 1.0f);
        yield return new WaitForSeconds(1.0f);
        CanvasManager.instance.SetFeedback("2", 1.0f);
        yield return new WaitForSeconds(1.0f);
        CanvasManager.instance.SetFeedback("1", 1.0f);
        yield return new WaitForSeconds(1.0f);
        CanvasManager.instance.SetFeedback("GO!", 1.0f);
        yield return new WaitForSeconds(1.0f);
        gamePaused = false;
        SpawnWave();
    }
    public void LoseGame()
    {
        gamePaused = true;
        Debug.Log("You Lose!");
        CanvasManager.instance.SetFeedback("You Lose!", 3.0f);
        CanvasManager.instance.ActivateLosePanel();
    }

    public void WinGame()
    {
        //gamePaused = true;
        Debug.Log("You Win!");
        CanvasManager.instance.SetFeedback("You Win!", 3.0f);
        CanvasManager.instance.ActivateWinPanel();
    }

    public void RestartGame()
    {
        // TODO: Reset all the parameters and values, but maybe keep the score?
        gamePaused = true;
        Debug.Log("Restarting Game");
        CanvasManager.instance.ActivateIntroPanel();
    }

    public void ResetComplete() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



    // --------------------------------------------------
    // Enemy Spawning
    // --------------------------------------------------
    public Transform spawnPoint;

    public GameObject enemyPrefab;

    public int enemiesInWave = 10;

    public int currentWave = 0;

    public int numWaves = 3;

    public float waveDelay = 5.0f;

    public float interEnemyDelay = 1f;

    public List<GameObject> enemies;

    // Spawns an enemy at the spawn point
    public void SpawnEnemy()
    {
        // Instantiate enemy at spawn point
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Add enemy to list
        enemies.Add(enemy);
    }

    // Spawns a wave of enemies
    public void SpawnWave()
    {
        // Spawn enemies
        StartCoroutine(SpawnEnemies());

        // Increment wave
        currentWave++;

        // If we've reached the end of the waves, win the game
        if (currentWave >= numWaves)
        {
            //WinGame();

            Debug.Log("All Waves Completed");
        }
    }

    // Delay between spawns
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesInWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(interEnemyDelay);

        }

        // Delay between waves
        yield return new WaitForSeconds(waveDelay);
        if (currentWave < numWaves)
        {
            SpawnWave();
        }


    }




}
