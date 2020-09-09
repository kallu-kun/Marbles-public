using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            Debug.Log("asdad");
            audioSource.Play();
            this.transform.parent.gameObject.SetActive(false);
        }
    }
}
