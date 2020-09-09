using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    private GameObject player;

    [SerializeField]
    private SpriteRenderer launcherSpriteRenderer;

    [SerializeField]
    private Sprite launcherPressed;

    [SerializeField]
    private Sprite launcherNotPressed;
    public bool isTouching;

    [SerializeField]
    private float jumpForce;

    void Start() {
        player = GameObject.Find("PlayerBlueMarble(Clone)");
        if (player == null) {
            player = GameObject.Find("PlayerBlueMarble");
            Debug.Log("Launcheri = PlayerBlueMarble(ei klooni)");
        }
    }

    void Update() {
        if (isTouching && Input.GetButtonDown("Jump")) {
            player.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * jumpForce);
            Debug.Log("Launcher launched!");
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            isTouching = true;
            launcherSpriteRenderer.sprite = launcherPressed;
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player") {
            isTouching = false;
            launcherSpriteRenderer.sprite = launcherNotPressed;
        }
    }
}
