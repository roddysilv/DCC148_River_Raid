using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZenvaVR;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Player player;
    public GameObject enemyPrefab;
    public GameObject enemyHPrefab;
    public float enemySpawnInterval = 1f;
    public float horizontalLimit = 2.8f;
    private float enemySpawnTimer;
    private int score;
    private float fuel = 100f;
    public GameObject gameCamera;
    public Text scoreText;
    public Text fuelText;
    public float fuelDecreaseSpeed = 5f;
    public GameObject fuelPrefab;
    public float fuelSpawnInterval = 9f;
    private float fuelSpawnTimer;
    private float restartTimer = 3f;
    public ObjectPool enemyPool;
    public ObjectPoolH enemyPoolH;


    // Start is called before the first frame update
    void Start()
    {
        enemySpawnTimer = enemySpawnInterval;
        player.OnFuel += OnFuel;
        fuelSpawnTimer = Random.Range(0f, fuelSpawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            enemySpawnTimer -= Time.deltaTime;
            if (enemySpawnTimer <= 0)
            {
                enemySpawnTimer = enemySpawnInterval;
                //GameObject enemyInstance = enemyPool.GetObj ();
                GameObject enemyInstance = Instantiate(enemyPrefab);
                enemyInstance.transform.SetParent(transform);
                enemyInstance.transform.position = new Vector2(Random.Range(-horizontalLimit, horizontalLimit), player.transform.position.y + Screen.height / 100f);
                enemyInstance.GetComponent<Enemy>().OnKill += OnEnemyKill;

                //GameObject enemyHInstance = enemyPoolH.GetObj ();
                GameObject enemyHInstance = Instantiate(enemyHPrefab);
                enemyHInstance.transform.SetParent(transform);
                enemyHInstance.transform.position = new Vector2(Random.Range(-horizontalLimit, horizontalLimit), player.transform.position.y + Screen.height / 100f);
                enemyHInstance.GetComponent<EnemyH>().OnKill += OnEnemyKill;

            }
            fuelSpawnTimer -= Time.deltaTime;
            if (fuelSpawnTimer <= 0)
            {
                fuelSpawnTimer = fuelSpawnInterval;
                GameObject fuelInstance = Instantiate(fuelPrefab);
                fuelInstance.transform.SetParent(transform);
                fuelInstance.transform.position = new Vector2(
                Random.Range(-horizontalLimit, horizontalLimit),
                player.transform.position.y + Screen.height / 100f);
            }

            fuel -= Time.deltaTime * fuelDecreaseSpeed;
            fuelText.text = "Fuel: " + (int)fuel;
            if (fuel <= 0)
            {
                fuelText.text = "Fuel: 0";
                Destroy(player.gameObject);
            }
        }
        else
        {
            restartTimer -= Time.deltaTime;
            if (restartTimer <= 0f)
            {
                SceneManager.LoadScene("Game");
            }
        }
        // Delete enemies.
        foreach (Enemy enemy in GetComponentsInChildren<Enemy>())
        {
            if (gameCamera.transform.position.y - enemy.transform.position.y > Screen.height / 100f)
            {
                enemy.gameObject.SetActive(false);
                //Destroy(enemy.gameObject);
            }

        }

        foreach (EnemyH enemyH in GetComponentsInChildren<EnemyH>())
        {
            if (gameCamera.transform.position.y - enemyH.transform.position.y > Screen.height / 100f)
            {
                enemyH.gameObject.SetActive(false);
            }
        }
    }

    void OnEnemyKill()
    {
        score += 25;
        scoreText.text = "Score: " + score;
    }

    void OnFuel()
    {
        fuel = 100f;
    }

}

