
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovements : MonoBehaviour
{
    //player movements
    private Rigidbody2D rb;
    public float jumpForce;
    bool isGrounded;
    public Transform Groundcheck;
    public LayerMask GroundLayer;
    public int noofjump = 1;

    private Animator animator;

    //character fall
    private float fallingTime = -1f;
    private new Collider2D collider;


    //score
    public Text scoreText;
    private float startTime;

    

    //sound effects
    public AudioSource backgroundSfx;
    public AudioSource deathSfx;
    public AudioSource jumpSfx;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();

        startTime = Time.time;


        backgroundSfx.Play();
      
       
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(Groundcheck.position, 0.1f, GroundLayer);
   

        animator.SetFloat("jumping", Mathf.Abs(rb.velocity.y));
        scoreText.text = (Time.time - startTime).ToString("0.00");

    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            string Level = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Title");
        }
        if (fallingTime == -1)
        {


            if (Input.GetButtonUp("Jump") || Input.GetButtonUp("Fire1") && noofjump > 0)
            {
                if (isGrounded)
                {
                    Jump();
                    noofjump--;
                    jumpSfx.Play();
                     //
                }

            }

            void Jump()
            {
                rb.velocity = Vector2.up * jumpForce;
                
            }

        }
        else
        {
            if (Time.time > fallingTime + 2)
            {


                 string Level = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(Level);
               
            }
        }

    }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("obstacle"))
        {

            foreach (ObstacleSpawner spawner in FindObjectsOfType<ObstacleSpawner>())
            {
                spawner.enabled = false;
            }

            foreach (MoveLeft movement in FindObjectsOfType<MoveLeft>())
            {
                movement.enabled = false;
            }

            fallingTime = Time.time;
            animator.SetBool("falling", true);
            rb.velocity = Vector2.zero;
            rb.velocity = Vector2.up * jumpForce;
            collider.enabled = false;

            deathSfx.Play();

            float initialBestScore = PlayerPrefs.GetFloat("BestScore", 0);
            float initialScore = Time.time - startTime;

            if (initialScore > initialBestScore)
            {
                PlayerPrefs.SetFloat("BestScore", initialScore);
            }
        }
        else if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            noofjump = 1;
        }
       
    }

}

    
  