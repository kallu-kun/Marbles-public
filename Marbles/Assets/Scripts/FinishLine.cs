using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

    public GameObject finishScreen;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite nextLevelNotOpen;

    [SerializeField]
    private Sprite nextLevelOpen;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = nextLevelNotOpen;
    }

    private void LevelFinished() {
        spriteRenderer.sprite = nextLevelOpen;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player" && ScoreScript.LevelFinished == true) {

            Time.timeScale = 0f;
            finishScreen.SetActive(true);
            ScoreScript.ResetLevel();
            
            // Time.timeScale = 0f;
        }
    }
}
