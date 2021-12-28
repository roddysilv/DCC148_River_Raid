using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bossPrefab;
    public float horizontalLimit = 2.8f;
    /*public delegate void KillHandler();
    public event KillHandler OnKill;*/
    // Start is called before the first frame update
    void Start()
    {
        GameObject bossInstance = Instantiate(bossPrefab);
        bossInstance.transform.SetParent(transform);
        //bossInstance.transform.position = new Vector2(Random.Range(-horizontalLimit, horizontalLimit), boss.transform.position.y + Screen.height / 100f);
        bossInstance.transform.position = new Vector2(Random.Range(-horizontalLimit, horizontalLimit), Screen.height / 100f);
        //bossInstance.GetComponent<Boss>().OnKill += OnEnemyKill;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Add boss movement
    }
    void OnEnemyKill()
    {
        //
    }
}
