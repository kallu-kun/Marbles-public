using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    private PlayerInfo lives;

    private void Start() {
        lives = FindObjectOfType<PlayerInfo>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            lives.IncreaseLives();
            Debug.Log("Lives: " + lives.playerLives);
            gameObject.SetActive(false);
        }
    }

}
