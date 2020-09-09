using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    private bool hasDied;
    Rigidbody2D rb;

    
    void Start() {
        hasDied = false;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "DeathCollider") {
            hasDied = true;
            StartCoroutine("Die");
        } else if (col.gameObject.tag == "Finish") {
               Debug.Log("Finished level");
        }
    }
    
    IEnumerator Die() {
        Debug.Log("Player has fallen");
        yield return new WaitForSeconds(1);
        Debug.Log("Player has died");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        hasDied = false;
    }

}
