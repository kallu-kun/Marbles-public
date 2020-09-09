using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    private GameObject player;
    public bool isTouching;
    private bool isKinematic;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private SpriteRenderer buttonSpriteRenderer;

    [SerializeField]
    private Sprite buttonPressed;

    [SerializeField]
    private Sprite buttonNotPressed;
    
    
    
    void Start() {
        
        player = GameObject.Find("PlayerBlueMarble(Clone)");
        
        if (player == null) {
            player = GameObject.Find("PlayerBlueMarble");
        }
    }

    void Update() {
        if (isTouching && Input.GetButtonDown("Jump") && !isKinematic) {
            isKinematic = true;
            buttonSpriteRenderer.sprite = buttonPressed;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            player.transform.parent = transform;
            Debug.Log("Static");
        } else if (isTouching && Input.GetButtonDown("Jump") && isKinematic) {
            isKinematic = false;
            buttonSpriteRenderer.sprite = buttonNotPressed;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            player.transform.parent = null;
            Debug.Log("Dynamic");
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            isTouching = true;
            Debug.Log("Entered button trigger");
        } 
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player") {
            isTouching = false;
        }
    }

    /* 
    private void OnTriggerStay2D(Collider2D col) {
        if (col.tag == "Player" && Input.GetButton("Jump") && !isKinematic) {
            isKinematic = true;
            col.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            col.transform.parent = transform;
            Debug.Log("Static");
        } else if (col.tag == "Player" && !Input.GetButton("Jump") && isKinematic) {
            isKinematic = false;
            col.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            col.transform.parent = null;
            Debug.Log("Dynamic");
        }

    

        // col.attachedRigidbody.AddForce(Vector2.up * jumpForce);
        // col.gameObject.AddComponent<FixedJoint2D>();
        // col.gameObject.GetComponent<FixedJoint2D>().connectedBody = gameObject.GetComponent<Rigidbody2D>();
    }
    */

    /* 
    private void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Jee");
        FixedJoint2D joint2D = gameObject.AddComponent<FixedJoint2D>();
        joint2D.anchor = col.contacts[0].point;
        joint2D.connectedBody = col.contacts[0].otherCollider.transform.GetComponentInParent<Rigidbody2D>();
        joint2D.enableCollision = false;
    }
    */
}
