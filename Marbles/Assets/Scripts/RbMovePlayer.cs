using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbMovePlayer : MonoBehaviour {

    private bool isGrounded;
    public float fallMultiplier = 2;
    public float lowJumpMultiplier = 2;
    public float jumpVelocity = 5;
    private SpriteRenderer sb;
    [SerializeField]
    private float speed = 10;

    private Vector2 movement;

    private Rigidbody2D rb;

    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        sb = GetComponentInChildren<SpriteRenderer>();
        
    }

    private void Update() {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0);
    }

    private void FixedUpdate() {
        MoveCharater(movement);
        Jump();
        
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "World" && isGrounded == false) {
            isGrounded = true;
            Debug.Log(isGrounded);
        }
    }

    private void MoveCharater(Vector2 direction) {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        // rb.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));
        sb.transform.Rotate(0, 0, -1 * direction.x * speed);
    }

    private void Jump() {
        if (Input.GetButton("Jump") && isGrounded) {
            rb.velocity = Vector2.up * jumpVelocity;
            isGrounded = false;
        }

        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
