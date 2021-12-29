using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndingController : MonoBehaviour
{
    // Start is called before the first frame update
    private float restartTimer = 3f;
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
        /*if (restartTimer <= 0f)
        {
            SceneManager.LoadScene("MainMenu");
        }*/
    }
}
