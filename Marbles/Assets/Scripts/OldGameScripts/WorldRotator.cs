using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotator : MonoBehaviour {

    
    public GameObject world;

    private float speed;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float maxSpeed;

    private float minSpeed;
    
    [SerializeField]
    private float acceleration;

    [SerializeField]
    private float deceleration;
    private GameObject player;

    void Awake() {

    }

    
    void Start() {

        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        player = GameObject.Find("BallSmallFinal");
        if (player == null) {
            player = GameObject.Find("PlayerBlueMarble");
            Debug.Log("Player = marble(ei klooni)");
            
        }

        minSpeed = maxSpeed * -1;
    }

    
    void FixedUpdate() {
        RotateWorld();

    }
    
    private void RotateWorld() {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Horizontal") && speed <= maxSpeed && speed >= minSpeed) {

            speed += acceleration * horizontalMovement;

            if (horizontalMovement > 0 && speed < 0) {
                speed += acceleration * horizontalMovement;
            } else if (horizontalMovement < 0 && speed > 0) {
                speed += acceleration * horizontalMovement;
            }

            if (speed > maxSpeed) {
                speed = maxSpeed;
            } else if (speed < minSpeed) {
                speed = minSpeed;
            }

        } else if (!Input.GetButton("Horizontal") && speed > 0) {
            speed += deceleration;

        } else if (!Input.GetButton("Horizontal") && speed < 0) {
            speed -= deceleration;
        } 

        // Debug.Log(speed);

        float rotation;
        rotation = horizontalMovement;

        world.transform.Translate(speed * Time.deltaTime,0,0);
        spriteRenderer.transform.Rotate(0, 0, rotation * Time.deltaTime);
        
    }
}
