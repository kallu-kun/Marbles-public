using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool isGrounded;

    [SerializeField]
    private float fallMultiplier = 2;

    [SerializeField]
    private float lowJumpMultiplier = 2;

    [SerializeField]
    private float jumpVelocity = 5;
    private SpriteRenderer sb;

    [SerializeField]
    private float speed = 10;
    private float movement;
    private Rigidbody2D rb;

    [SerializeField]
    private LayerMask groundLayer;
    private float slopeVelocity = 0.5f;
    private Vector2 currentPosition;
    private Vector2 lastPosition;

    private PlayerInfo playerInfo;
    private GameMaster gameMaster;

    private Level9LonelySpikeBall Level9LonelySpikeBall;

    [SerializeField]
    private GameObject deadScreen;

    private bool jumpBufferHit;

    private AudioSource audioSource;
    private float timerDuration;
    private bool jumpBuffer;
    private MovinSpikes[] movingSpikes;
    private List<Vector2> originalPos = new List<Vector2>();

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sb = GetComponentInChildren<SpriteRenderer>();
        playerInfo = FindObjectOfType<PlayerInfo>();
        gameMaster = FindObjectOfType<GameMaster>();
        Level9LonelySpikeBall = FindObjectOfType<Level9LonelySpikeBall>();
        audioSource = GetComponent<AudioSource>();
        movingSpikes = FindObjectsOfType<MovinSpikes>();
        
        
        
        for (int i = 0; i < movingSpikes.Length; i++) {
            // Debug.Log(movingSpikes[i].transform.position);
            originalPos.Add(movingSpikes[i].transform.position);
        }
    }

    private void Update() {
        movement = Input.GetAxis("Horizontal");
        // Debug.Log(transform.hasChanged);
    }

    private void FixedUpdate() {
        // MoveCharater(movement);
        Move();
        Jump();
        
    }

    private void Move() {
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        // currentPosition.x = transform.position.x;
        System.Math.Round(currentPosition.x, 2);
        System.Math.Round(transform.position.x, 2);
        currentPosition.x = transform.position.x;
        if (currentPosition.x > lastPosition.x && !Input.GetButton("Horizontal")) {
            sb.transform.Rotate(0, 0, -1 * slopeVelocity * speed);
        } else if (currentPosition.x < lastPosition.x && !Input.GetButton("Horizontal")) {
            sb.transform.Rotate(0, 0, 1 * slopeVelocity * speed);
        }

        // rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        if (rb.velocity.magnitude > 0) {
            sb.transform.Rotate(0, 0, -1 * movement * speed);
        }

        lastPosition.x = currentPosition.x;
        transform.hasChanged = false;
        
    }

    private void DoTheJump() {
        if (Input.GetAxis("Horizontal") > 0) {
            rb.velocity = new Vector2(0.5f, 1) * jumpVelocity;
        } else if (Input.GetAxis("Horizontal") < 0) {
            rb.velocity = new Vector2(-0.5f, 1) * jumpVelocity;
        } else if (Input.GetAxis("Horizontal") == 0) {
            rb.velocity = new Vector2(0,1) * jumpVelocity;
        }
    }
    
    private void Jump() {

        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.4f;

        if (gameObject.transform.localScale.x == 1) {
            distance = 0.6f;
            slopeVelocity = 0.3f;
        }

        RaycastHit2D hit;
        RaycastHit2D hit2;
        RaycastHit2D hit3;

        RaycastHit2D topGroundCheck1;
        RaycastHit2D topGroundCheck2;
        RaycastHit2D topGroundCheck3;

        RaycastHit2D jumpBufferCheck;
        RaycastHit2D jumpBufferCheck2;
        RaycastHit2D jumpBufferCheck3;

        jumpBufferCheck = Physics2D.Raycast(position, direction, 10f, groundLayer);
        jumpBufferCheck2 = Physics2D.Raycast(position + new Vector2(0.15f, 0), direction + new Vector2(0.15f, 0), 10f, groundLayer);
        jumpBufferCheck3 = Physics2D.Raycast(position + new Vector2(-0.15f, 0), direction + new Vector2(-0.15f, 0), 10f, groundLayer);

        if (jumpBufferCheck.collider != null && Input.GetButtonDown("Jump")
            || jumpBufferCheck2.collider != null && Input.GetButtonDown("Jump")
            || jumpBufferCheck3.collider != null && Input.GetButtonDown("Jump")) {
            jumpBufferHit = true; 
        }
        
        hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        hit2 = Physics2D.Raycast(position + new Vector2(0.15f, 0), direction + new Vector2(0.15f, 0), distance, groundLayer);
        hit3 = Physics2D.Raycast(position + new Vector2(-0.15f, 0), direction + new Vector2(-0.15f, 0), distance, groundLayer);

        topGroundCheck1 = Physics2D.Raycast(position, -direction, distance, groundLayer);
        topGroundCheck2 = Physics2D.Raycast(position + new Vector2(0.10f, 0), -direction + new Vector2(0.10f, 0), distance, groundLayer);
        topGroundCheck3 = Physics2D.Raycast(position + new Vector2(-0.10f, 0), -direction + new Vector2(-0.10f, 0), distance, groundLayer);

        if (hit.collider != null && isGrounded && Input.GetButton("Jump")
            || hit2.collider != null && isGrounded && Input.GetButton("Jump")
            || hit3.collider != null && isGrounded && Input.GetButton("Jump")) {

                DoTheJump();
                // jumpBufferHit = false; 
            // rb.velocity = new Vector2(1,1) * jumpVelocity;
            // rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
        }

        if (jumpBufferHit && hit.collider != null && isGrounded
            || jumpBufferHit && hit2.collider != null && isGrounded
            || jumpBufferHit && hit3.collider != null && isGrounded) {

                DoTheJump();
                jumpBufferHit = false;
        }

        if (hit.collider == null
            || hit2.collider == null
            || hit3.collider == null) {

                timerDuration += Time.deltaTime;
                if (timerDuration < 0.15f) {
                    jumpBuffer = true;
                    // Debug.Log(timerDuration);
                } else {
                    jumpBuffer = false;
                }
        } else {
            timerDuration = 0;
        }

        if (jumpBuffer && Input.GetButtonDown("Jump")) {
            DoTheJump();
            jumpBufferHit = false;
        }

        if (topGroundCheck1.collider != null || topGroundCheck2.collider != null || topGroundCheck3.collider != null) {
            isGrounded = false;
            jumpBuffer = false;
            jumpBufferHit = false;
        } else {
            isGrounded = true;
        }

              
        /* 
        if (Input.GetButton("Jump") && isGrounded) {
            rb.velocity = Vector2.up * jumpVelocity;
            isGrounded = false;
        }
        */

        if (rb.velocity.y < 0) {
            rb.gravityScale = fallMultiplier;
            // rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.gravityScale = lowJumpMultiplier;
            // rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        } else {
            rb.gravityScale = 1;
        }
    }

    /* 
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Vector3 temp = new Vector3(5,0);
        
        Gizmos.DrawLine(transform.position + new Vector3(-0.3f,0), transform.position + new Vector3(-0.3f,0) + Vector3.down * 0.8f);
        Gizmos.DrawLine(transform.position + new Vector3(0.3f,0), transform.position + new Vector3(0.3f,0) + Vector3.down * 0.8f);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 0.8f);
    }
    */


    // private PlayerInfo playerInfo = new PlayerInfo();

    private void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "DeathCollider") {
            playerInfo.DecreaseLives();
            if (Level9LonelySpikeBall != null) {
                Level9LonelySpikeBall.SetStartingPosition();
            }
            Debug.Log("Lives: " + playerInfo.playerLives);
            // Kun menettää elämän, niin menee checkpointin positioon
            gameObject.transform.position = gameMaster.lastCheckpoint;
            for (int i = 0; i < movingSpikes.Length; i++) {
                movingSpikes[i].transform.position = originalPos[i];
            }

            Debug.Log("Player spawned at: " + gameObject.transform.position);
            if (playerInfo.PlayerDead()) {
                deadScreen.SetActive(true);
                Time.timeScale = 0f;
                // deathScreen.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Life") {
            Debug.Log("ÄÄNEN PITÄIS TULLA HUUTIA!!!");
            audioSource.Play();
            
        }
    }



}
