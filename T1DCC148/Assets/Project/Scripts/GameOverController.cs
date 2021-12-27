using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private float restartTimer = 3f;
    public AudioSource gameOverMusic;
    // Start is called before the first frame update
    void Start()
    {
        gameOverMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        restartTimer -= Time.deltaTime;
        if (restartTimer <= 0f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
