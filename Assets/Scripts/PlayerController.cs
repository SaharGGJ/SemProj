using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource footstepsAudioSource;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] int flightTime;
    [SerializeField] float gravityMultiplier;
    [SerializeField] float speed = 5.0f;
    //[SerializeField] Camera cam;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float jumpPower = 10f;
    [SerializeField] Object knifeSpawn;
    public bool isFacingRight = true;
    public bool spawnFacingRight;
    private Vector2 facingRight;
    float movementSpeed;
    private Vector2 moveDirection;
    private float _gravity = 9.81f;
    private float velocity;
    bool isGrounded = true;
    private void Start()
    {
        facingRight = new Vector2(transform.localScale.x, transform.localScale.y);
        if(spawnFacingRight)
        {
            transform.localScale = facingRight;
            isFacingRight = true;
        }

    }
    public void FlipPlayer()
    {
        if(isFacingRight)
        {
                transform.localScale = facingRight;
        }
        if(!isFacingRight)
        {
            transform.localScale = new Vector2(-transform.localScale.x,transform.localScale.y);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        rigidBody.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        if(isGrounded)
        {
            rigidBody.gravityScale= gravityMultiplier;
            if(Input.GetKey(KeyCode.Space))
            {
                rigidBody.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
            }
        }
        else
        {
            rigidBody.gravityScale = _gravity;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseGame();
        }

    }
    public void pauseGame()
    {
        if (!pauseMenu.activeSelf)
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
    public void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, 0).normalized;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if(isFacingRight)
            {
                isFacingRight= false;
                FlipPlayer();
            }
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if(!isFacingRight)
            {
                isFacingRight= true;
                FlipPlayer();
            }
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            {
                footstepsAudioSource.Play();
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            {
                footstepsAudioSource.Stop();
            }
        }
        else
            footstepsAudioSource.Stop();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
            Debug.Log("OnGround");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
            Debug.Log("And we are off!");
        }
    }

}
