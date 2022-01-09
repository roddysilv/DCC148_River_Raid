using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed;
    public float bulletSpeed;
    public float shootingInterval = 6f;
    private int bossHealth = 10;
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
        if (shootingTimer <= 0f) // controla os tiros do boss
        {
            shootingTimer = shootingInterval;
            GameObject bulletInstance = Instantiate(bulletPrefab);
            bulletInstance.transform.SetParent(transform.parent);
            bulletInstance.transform.position = transform.position;
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
            Destroy(bulletInstance, 3f);

            GameObject bulletInstance1 = Instantiate(bulletPrefab);
            bulletInstance1.transform.SetParent(transform.parent);
            bulletInstance1.transform.position = transform.position;
            bulletInstance1.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, bulletSpeed);
            Destroy(bulletInstance1, 3f);

            GameObject bulletInstance2 = Instantiate(bulletPrefab);
            bulletInstance2.transform.SetParent(transform.parent);
            bulletInstance2.transform.position = transform.position;
            bulletInstance2.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, bulletSpeed);
            Destroy(bulletInstance2, 3f);

            GameObject bulletInstance3 = Instantiate(bulletPrefab);
            bulletInstance3.transform.SetParent(transform.parent);
            bulletInstance3.transform.position = transform.position;
            bulletInstance3.GetComponent<Rigidbody2D>().velocity = new Vector2(-6f, bulletSpeed);
            Destroy(bulletInstance3, 3f);

            GameObject bulletInstance4 = Instantiate(bulletPrefab);
            bulletInstance4.transform.SetParent(transform.parent);
            bulletInstance4.transform.position = transform.position;
            bulletInstance4.GetComponent<Rigidbody2D>().velocity = new Vector2(6f, bulletSpeed);
            Destroy(bulletInstance4, 3f);
        }
        // Se a vida do boss chegar a zero, o boss morre
        if (bossHealth <= 0)
        {
            gameObject.SetActive(false); // remove da cena
            Destroy(gameObject); // destroi o objeto (desativado pois o GameController usa essa variável)
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "PlayerBullet")
        {
            gameObject.SetActive(false);
            Destroy(otherCollider.gameObject);
            bossHealth -= 1;
        }
        if (otherCollider.tag == "Player")
        {
            gameObject.SetActive(false);
            Destroy(otherCollider.gameObject);
        }
    }

    public int GetBossHealth()
    {
        return bossHealth;
    }
}
