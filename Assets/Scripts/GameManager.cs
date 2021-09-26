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
        //DisableOutlines();
        UnhighlightAll();
    }

    private void Update()
    {
        // If # of nutsToThrow is less than 2
        if (GameManager.instance.nutsToThrow < 2)
        {
            CanvasManager.instance.SetFeedback("Go restock at your home tree!", 2.0f);
        }
        // Debug.Log the tag of any object clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                // if the tag is a Tower
                if (hit.transform.tag == "Tower")
                {
                    VacateTowers();
                    UnhighlightAll();

                    //hit.transform.parent.GetComponent<Tower>().EnableOutline();
                    hit.transform.parent.GetComponent<Tower>().HighlightTower();

                    // Move Squirrel to tower position at Squirrel.instance.speed
                    Squirrel.instance.ChangeTarget(hit.transform.parent);

                    hit.transform.parent.GetComponent<Tower>().Occupy();
                }

                // if the tag is "HomeTower"
                if (hit.transform.tag == "HomeTower")
                {
                    VacateTowers();
                    UnhighlightAll();
                    HomeTower.instance.Occupy();
                    HomeTower.instance.HighlightTower();
                    if (GameManager.instance.nutsToThrow < 9)
                    {
                        GameManager.instance.AddNuts(2);
                        CanvasManager.instance.SetFeedback("+2 acorns!", 2.0f);
                    }

                    if (GameManager.instance.nutsToThrow < 10)
                    {
                        GameManager.instance.AddNuts(1);
                        CanvasManager.instance.SetFeedback("+1 acorn!", 2.0f);
                    }
                    else
                    {
                        CanvasManager.instance.SetFeedback("You have as many acorns as you can carry!", 3.0f);
                    }

                    Squirrel.instance.ChangeTarget(hit.transform.parent);


                }
            }
        }
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



    // time/clock
    public float time;
    public void AdjustTime(float amount) => time += amount;

    // Current Level
    public int currentLevel;

    public GameObject[] towers;

    public GameObject homeTower;




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

    public GameObject enemyPrefab;

    public float enemySpeed = 1.0f;

    public int enemiesInWave = 10;

    public int currentWave = 0;

    public int numWaves = 3;

    public float waveDelay = 5.0f;

    public float interEnemyDelay = 1f;

    public List<GameObject> enemies;




    // Spawns an enemy at the spawn point
    public void SpawnEnemy()
    {
        List<Transform> path = new List<Transform>(WayPointManager.instance.RandomPath());
        //List<Transform> path = new List<Transform>(WayPointManager.instance.pathA);

        // Instantiate enemy at WayPointManager.instance.pathA[0].position
        GameObject enemy = Instantiate(enemyPrefab, path[0].position, Quaternion.identity);
        enemy.GetComponent<Enemy>().SetPath(path);

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


    // Set all towers isOccupied to false
    public void VacateTowers()
    {
        foreach (GameObject tower in towers)
        {
            tower.GetComponent<Tower>().Vacate();
            // DisableOutlines();
        }
        HomeTower.instance.Vacate();
    }

    // public void DisableOutlines()
    // {
    //     foreach (GameObject tower in towers)
    //     {
    //         tower.GetComponent<Tower>().DisableOutline();

    //     }
    // }

    public void UnhighlightAll()
    {
        foreach (GameObject tower in towers)
        {
            tower.GetComponent<Tower>().UnhighlightTower();

        }
        HomeTower.instance.UnhighlightTower();
    }




    // --------------------------------------------------
    // Player Stats
    // --------------------------------------------------

    public int nutsToThrow = 10;

    public void AddNuts(int nuts) => nutsToThrow += nuts;

    public void RemoveNuts(int nuts) => nutsToThrow -= nuts;



}
