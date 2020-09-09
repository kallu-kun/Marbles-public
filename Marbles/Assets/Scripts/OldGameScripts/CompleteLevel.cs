using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour {

    Animator animator;
    ParticleSystem explosion;

    private void Start() {
        animator = gameObject.GetComponent<Animator>();
        explosion = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            StartCoroutine("PlayExplosionAnimation");
            StartCoroutine("FinishLevel");
        }
    }

    IEnumerator FinishLevel() {
        animator.Play("CannonFinish");
        Debug.Log("Level finished waiting");
        yield return new WaitForSeconds(2);
        Debug.Log("Level finished");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator PlayExplosionAnimation() {
        yield return new WaitForSeconds(1);
        explosion.Play();
    }


}
