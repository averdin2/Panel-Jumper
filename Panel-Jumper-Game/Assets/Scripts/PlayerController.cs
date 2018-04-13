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
    bool onDefaultPanel = false;
    bool onBoostPanel = false;
    bool onBadPanel = false;
    bool onUltraPanel = false;
    public Transform panelCheck;
    float panelRadius = 0.2f;
    public LayerMask whatIsDefaultPanel;
    public LayerMask whatIsBoostPanel;
    public LayerMask whatIsBadPanel;
    public LayerMask whatIsUltraPanel;
    Vector3 wallJumpVector;

    // Jump variables
    public float jumpForce = 500f;
    public float defaultJump = 15f;      //Controls how high player will jump after panel jump
    public float boostJump = 25f;
    public float badJump = 1f;
    public float ultraJump = 100f;
    public int panelJumpX = 350;

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

        // Checking if the player is on a panel (default, boost, bad, or ultra)
        Collider2D defaultPanelCollider = Physics2D.OverlapCircle(panelCheck.position, panelRadius, whatIsDefaultPanel);
        onDefaultPanel = defaultPanelCollider != null;
        Collider2D boostPanelCollider = Physics2D.OverlapCircle(panelCheck.position, panelRadius, whatIsBoostPanel);
        onBoostPanel = boostPanelCollider != null;
        Collider2D badPanelCollider = Physics2D.OverlapCircle(panelCheck.position, panelRadius, whatIsBadPanel);
        onBadPanel = badPanelCollider != null;
        Collider2D ultraPanelCollider = Physics2D.OverlapCircle(panelCheck.position, panelRadius, whatIsUltraPanel);
        onUltraPanel = ultraPanelCollider != null;


    }

    void Update()
    {
        if (grounded)
        {
            //anim.SetBool("Ground", true);
        }
        //else
        //{
        //anim.SetBool("Ground", false);
        //}

        //anim.SetFloat("vSpeed", rb.velocity.y);

        // Used for player movement keys
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        //anim.SetFloat("Speed", Mathf.Abs(move));

        // calls Flip function when player is changing direction
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        // Jump mechanics
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Jump when on panel
        if (onDefaultPanel || onBoostPanel || onBadPanel || onUltraPanel)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
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

    public int GetPlayerScore()
    {
        return playerScore;
    }

    // Controls player jump
    void Jump()
    {
        if (grounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }

        if (onDefaultPanel)
        {
            wallJumpVector = new Vector3(0, defaultJump, 0);
            rb.velocity = wallJumpVector;
            rb.AddForce(new Vector3((panelJumpX * (facingRight ? -1 : 1)), 0, 0));
        }
        if (onBoostPanel)
        {
            wallJumpVector = new Vector3(0, boostJump, 0);
            rb.velocity = wallJumpVector;
            rb.AddForce(new Vector3((panelJumpX * (facingRight ? -1 : 1)), 0, 0));
        }
        if (onBadPanel)
        {
            wallJumpVector = new Vector3(0, badJump, 0);
            rb.velocity = wallJumpVector;
            rb.AddForce(new Vector3((panelJumpX * (facingRight ? -1 : 1)), 0, 0));
        }
        if (onUltraPanel)
        {
            wallJumpVector = new Vector3(0, ultraJump, 0);
            rb.velocity = wallJumpVector;
            rb.AddForce(new Vector3((panelJumpX * (facingRight ? -1 : 1)), 0, 0));
        }
    }
}
