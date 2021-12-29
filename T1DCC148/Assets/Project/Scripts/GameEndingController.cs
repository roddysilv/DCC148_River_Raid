using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingController : MonoBehaviour
{
    // Start is called before the first frame update
    private float restartTimer = 14f; // tempo da música terminar
    public AudioSource gameEndingMusic;
    // Start is called before the first frame update
    void Start()
    {
        gameEndingMusic.Play();
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
