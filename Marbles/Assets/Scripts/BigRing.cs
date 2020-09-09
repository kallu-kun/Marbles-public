using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigRing : MonoBehaviour {


    [SerializeField]
    private SpriteRenderer[] renderersInChildren;

    [SerializeField]
    private Sprite[] newSprite;

    private bool ballHasHit = false;
    private ScoreScript scoreScript;
    private ImageLives images;
    private AudioSource audioSource;
    
 
    private void Start() {
        scoreScript = FindObjectOfType<ScoreScript>();
        images = FindObjectOfType<ImageLives>();
        audioSource = GetComponent<AudioSource>();
        
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player" && !ballHasHit) {
            for (int i = 0; i < renderersInChildren.Length; i++) {
            renderersInChildren[i].sprite = newSprite[i];
            }

            audioSource.Play();
            images.RemoveImage();
            scoreScript.AddScore(1);
            ballHasHit = true;
        }
    }
}
