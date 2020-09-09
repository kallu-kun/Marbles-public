using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpike : MonoBehaviour {
    
    private PlayerInfo lives;

    private void Start() {
        lives = FindObjectOfType<PlayerInfo>();
    }
    
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "SmallBalls" || col.gameObject.tag == "BigBalls") {
            lives.DecreaseLives();
            Debug.Log("Lives: " + lives.playerLives);
        }
    }
}
