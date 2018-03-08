using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // Player variables
    private Rigidbody2D rb;
    public float maxSpeed = 10f;
    private bool facingRight = true;

    // Score Variables
    public int playerScore = 0;
    private int highScore;
    public Text scoreText;
    public Text highScoreText;
    private int scoreMulti = 100;

    // Grounded variables
    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    // Panel variables
    bool onPanel = false;
    public Transform panelCheck;
    float panelRadius = 0.2f;
    public LayerMask whatIsPanel;
    Vector3 wallJumpVector;

    // Jump variables
    public float jumpForce = 500f;
    public float jumpSpeed = 0f;      //Controls how high player will jump after panel jump
    bool doubleJump = false;
    int doubleJumpDelay = 0;
    int doubleJumpDelayMax = 10;

    // Use this for initialization
    void Start ()
    {
        // Initialize scoring
        highScore = PlayerPrefs.GetInt("highScore", highScore);
        scoreText.text = "Score: " + playerScore.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
        // Initialize player rigid body
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        // Checking if the player is on the ground
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        grounded = groundCollider != null;

        // Checking if the player is on a panel
        Collider2D panelCollider = Physics2D.OverlapCircle(panelCheck.position, panelRadius, whatIsPanel);
        onPanel = panelCollider != null;

        if (grounded)
        {
            //anim.SetBool("Ground", true);
            doubleJump = false;
        }
        //else
        //{
            //anim.SetBool("Ground", false);
        //}

        //anim.SetFloat("vSpeed", rb.velocity.y);

        // Used for player movement keys
        float move = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(move));

        if (!doubleJump)
        {
            // Player movement
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        }
        else
        {
            // I don't fully understand what is going on here?
            if (doubleJumpDelay > 0)
            {
                doubleJumpDelay--;
            }
            else
            {
                doubleJump = false;
            }
        }
        // calls Flip function when player is changing direction
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        // Jump when on panel
        if (onPanel)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // The 10 here needs to be variabalized
                wallJumpVector = new Vector3((10 * (facingRight ? -1 : 1)), jumpSpeed, 0);
                rb.velocity = wallJumpVector;
                doubleJump = true;
                doubleJumpDelay = doubleJumpDelayMax;
            }
        }
    }

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }

        // Keeping track of the score
        if ((int)(rb.transform.position.y * scoreMulti) > playerScore)
        {
            playerScore = (int)(rb.transform.position.y * scoreMulti);
            scoreText.text = "Score: " + playerScore.ToString();
        }

        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = "High Score: " + highScore.ToString();
            PlayerPrefs.SetInt("highScore", highScore);
        }

        // To delete all saved values
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.DeleteAll();
        }
    }



    // Changes character direction
    void Flip()
    {
        facingRight = !facingRight;
        transform.RotateAround(GetComponent<Renderer>().bounds.center, new Vector3(0, 1, 0), 180);
    }
}
