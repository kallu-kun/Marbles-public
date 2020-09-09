using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int playerLives = 3;
    private bool isDead;

    public bool DecreaseLives() {
        playerLives--;
        if (playerLives <= 0) {
            return isDead = true;
        } else {
            return isDead = false;
        }
    }

    public void IncreaseLives() {
        if (playerLives <= 9) {
            playerLives++;
        }
    }

    public bool PlayerDead() {
        return isDead;
    }

    public void ResetLives() {
        playerLives = 3;
    }
}
