using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFlagBlocker : MonoBehaviour {

    private bool blockDestroyed;

    private void Start() {
        blockDestroyed = false;
    }

    private void Update() {
        if (ScoreScript.LevelFinished == true && !blockDestroyed) {
            blockDestroyed = false;
            Destroy(gameObject);
        }
    }

}
