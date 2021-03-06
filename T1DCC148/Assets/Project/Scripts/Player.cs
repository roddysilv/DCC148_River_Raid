using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void FuelHandler();

    public event FuelHandler OnFuel;

    public GameObject bulletPrefab;

    public float bulletSpeed = 2f;

    public float horizontalSpeed = 3f;

    public float verticalSpeed = 1f;

    public float horizontalLimit = 2.8f;

    private bool fired = false;

    private Animator animator;

    private SpriteRenderer spriterenderer;

    public AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal");

        // Move the player.
        GetComponent<Rigidbody2D>().velocity =
            new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed,
                verticalSpeed);

        // Keep the player within bounds.
        if (transform.position.x > horizontalLimit)
        {
            transform.position =
                new Vector2(horizontalLimit, transform.position.y);
        }
        else if (transform.position.x < -horizontalLimit)
        {
            transform.position =
                new Vector2(-horizontalLimit, transform.position.y);
        }
        if (Input.GetAxis("Fire1") == 1f)
        {
            if (fired == false)
            {
                fired = true;
                //shootSound.Play(); // TODO, not implemented yet
                GameObject bulletInstance = Instantiate(bulletPrefab);
                bulletInstance.transform.SetParent(transform.parent);
                bulletInstance.transform.position = transform.position;
                bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed);
                Destroy(bulletInstance, .72f);
            }
        }
        else
        {
            fired = false;
        }

        //Animacao do aviao
        if (dx > 0)
        {
            spriterenderer.flipX = true;
        }
        else if (dx < 0)
        {
            spriterenderer.flipX = false;
        }
        if (Mathf.Abs(dx) > 0.001)
        {
            animator.SetBool("Virando", true);
        }
        else
        {
            animator.SetBool("Virando", false);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "EnemyBullet" || otherCollider.tag == "Enemy")
        {
            Destroy (gameObject);
            Destroy(otherCollider.gameObject);
        }
        else if (otherCollider.tag == "Fuel")
        {
            Destroy(otherCollider.gameObject);
            if (OnFuel != null)
            {
                OnFuel();
            }
        }
    }
}
