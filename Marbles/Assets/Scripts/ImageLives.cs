using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLives : MonoBehaviour {

    private Image[] images;
    private int removedImageCount;
    

    private void Start() {
        images = GetComponentsInChildren<Image>();

        // Debug.Log(ScoreScript.ringCount);
        
        for (int i = images.Length - 1; i > ScoreScript.ringCount - 1; i--) {
            images[i].enabled = false;
        }

    }

    public void RemoveImage() {
        
        for (int i = ScoreScript.ringCount - removedImageCount - 1; i >= 0;) {
            images[i].enabled = false;
            break;
        }

        removedImageCount++;

    }

}
