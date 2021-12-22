using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    private float restartTimer = 3f;
    // Start is called before the first frame update
    void Start()
    {

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
