using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text scoreText;
    public Text livesText;
    public Text timeText;
    public Text healthText;
    public Transform[] spawnPoints;
    public int currentSpawnPoint = 0;
    public bool isHit = false;
    

    private Rigidbody rb;
    private int score;
    private int lives;
    private int time;
    private int secondCountdown;
    private int health;

    public LayerMask groundLayers;
    public float jumpForce = 7;
    public SphereCollider col;
    public bool isGrounded;

    public AudioClip twenty;
    public AudioClip fifty;
    public AudioClip hundred;
    public AudioClip fiveHundred;
    public AudioClip thousand;
    public AudioClip jump;
    public AudioClip wallBump;
    public AudioClip hazardHit;
    public AudioClip die;
    public AudioClip checkpoint;
    public AudioClip finish;
    public AudioClip interactiveswitch;
    public AudioSource source;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();

        score = 0;
        lives = 5;
        time = 700;
        secondCountdown = 35;
        health = 3;
        SetCountText();
        SetLivesText();
        SetTimeText();
        SetHealthText();
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        isGrounded = IsGrounded();

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            source.PlayOneShot(jump, 1f);
        }

        secondCountdown = secondCountdown - 1;
        if(secondCountdown == 0)
        {
            secondCountdown = 35;
            time = time - 1;
            SetTimeText();
        }

        if (time == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    private bool IsGrounded()
    {
        //return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
        return Physics.CheckSphere(new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f);
    }

    void Awake()
    {
        //source = GetComponent<AudioSource>();
    }
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup20"))
        {
            other.gameObject.SetActive(false);
            score = score + 20;
            SetCountText();
            source.PlayOneShot(twenty, 1f);
        }

        if (other.gameObject.CompareTag("Pickup50"))
        {
            other.gameObject.SetActive(false);
            score = score + 50;
            SetCountText();
            source.PlayOneShot(fifty, 1f);
        }

        if (other.gameObject.CompareTag("Pickup100"))
        {
            other.gameObject.SetActive(false);
            score = score + 100;
            SetCountText();
            source.PlayOneShot(hundred, 1f);
        }

        if (other.gameObject.CompareTag("Pickup500"))
        {
            other.gameObject.SetActive(false);
            score = score + 500;
            SetCountText();
            source.PlayOneShot(fiveHundred, 1f);
        }

        if (other.gameObject.CompareTag("Pickup1000"))
        {
            other.gameObject.SetActive(false);
            score = score + 1000;
            SetCountText();
            source.PlayOneShot(thousand, 1f);
        }

        if (other.gameObject.CompareTag("KillPlane"))
        {
            Respawn();
        }

        if (other.gameObject.CompareTag("Spawn2"))
        {
            currentSpawnPoint = 1;
            source.PlayOneShot(checkpoint, 1f);
        }

        if (other.gameObject.CompareTag("Spawn3"))
        {
            currentSpawnPoint = 2;
            source.PlayOneShot(checkpoint, 1f);
        }

        if (other.gameObject.CompareTag("Spawn4"))
        {
            currentSpawnPoint = 3;
            source.PlayOneShot(checkpoint, 1f);
        }

        if (other.gameObject.CompareTag("Spawn5"))
        {
            currentSpawnPoint = 4;
            source.PlayOneShot(checkpoint, 1f);
        }

        if (other.gameObject.CompareTag("Spawn6"))
        {
            currentSpawnPoint = 5;
            source.PlayOneShot(checkpoint, 1f);
        }

        if (other.gameObject.CompareTag("Spawn7"))
        {
            currentSpawnPoint = 6;
            source.PlayOneShot(checkpoint, 1f);
        }

        if (other.gameObject.CompareTag("Switch"))
        {
            source.PlayOneShot(interactiveswitch, 1f);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            source.PlayOneShot(finish, 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            if (isHit == false)
            {
                isHit = true;
                health = health - 1;
                SetHealthText();
                isHit = false;
                if (health == 0)
                {
                    Respawn();
                }
                source.PlayOneShot(hazardHit, 1f);
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            source.PlayOneShot(wallBump, 1f);
        }
    }


    void SetCountText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    void SetTimeText()
    {
        timeText.text = "Time: " + time.ToString();
    }

    void SetHealthText()
    {
        if (health == 3)
        {
            healthText.text = "Health:<3<3<3";
        }
        if (health == 2)
        {
            healthText.text = "Health:<3<3";
        }
        if (health == 1)
        {
            healthText.text = "Health:<3";
        }
    }

    void Respawn()
    {
        if (lives == 1)
        {
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            health = 3;
            lives = lives - 1;
            SetHealthText();
            SetLivesText();
            transform.position = spawnPoints[currentSpawnPoint].position;
            source.PlayOneShot(die, 1f);
        }
    }
}