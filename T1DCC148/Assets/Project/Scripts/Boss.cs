using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed;
    public float bulletSpeed;
    public float shootingInterval = 6f;
    /*public delegate void KillHandler();
    public event KillHandler OnKill;*/
    public int bossHealth = 100;

    private float shootingTimer;
    // Start is called before the first frame update
    void Start()
    {
        shootingTimer = Random.Range(0f, shootingInterval);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0f)
        {
            shootingTimer = shootingInterval;
            GameObject bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.transform.SetParent(transform.parent);
            bulletInstance.transform.position = transform.position;
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
            Destroy(bulletInstance, 3f);
        }
        // Se a vida do boss chegar a zero, o boss morre
        if (bossHealth <= 0)
        {
            gameObject.SetActive(false); // remove da cena
            //Destroy(gameObject); // destroi o objeto (desativado pois o GameController usa essa variável)
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "PlayerBullet")
        {
            gameObject.SetActive(false);
            Destroy(otherCollider.gameObject);
            bossHealth -= 10;
        }
        if (otherCollider.tag == "Player")
        {
            gameObject.SetActive(false);
            Destroy(otherCollider.gameObject);
        }
        /*if (OnKill != null)
        {
            OnKill();
        }*/
    }
}
