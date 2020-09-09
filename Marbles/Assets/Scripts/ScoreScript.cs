using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private static int scoreCount;
    public static int ringCount;
    private TMPro.TextMeshProUGUI[] texts;
    private BigRing[] bigRing;
    private SmallRing[] smallRing;
    private PlayerInfo playerInfo;
    private static bool levelFinished = false;
    private int oldLivesCount;
    private AudioSource audioSource;

    public static bool LevelFinished {
        get {
            return levelFinished;
        }
        set {
            if (scoreCount == ringCount) {
                levelFinished = true;
            } else {
                levelFinished = false;
            }
        }
    }


    
    void Awake() {
        texts = GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        smallRing = FindObjectsOfType<SmallRing>();
        bigRing = FindObjectsOfType<BigRing>();
        playerInfo = FindObjectOfType<PlayerInfo>();
        audioSource = GetComponent<AudioSource>();

        ringCount = bigRing.Length + smallRing.Length;
        oldLivesCount = playerInfo.playerLives;
        
        // texts[0].text = "Rings: " + scoreCount + "/" + ringCount;
        texts[1].text = "x" + playerInfo.playerLives;

    }

    
    void Update() {   
        LevelDone();
        UpdateTexts();
    }

    public void LevelDone() {
        if (scoreCount == ringCount && LevelFinished == false) {
            LevelFinished = true;
            // audioSource.Play();
            StartCoroutine(PlayFinishedLevelClip());
            Debug.Log("Level done: " + LevelFinished);
        }
    }

    IEnumerator PlayFinishedLevelClip() {
        yield return new WaitForSeconds(0.1f);
        audioSource.Play();
    }
    
    public void AddScore(int newScoreValue) {
        scoreCount += newScoreValue;
        // texts[0].text = "Rings: " + scoreCount + "/" + ringCount;
    }

    public static void ResetLevel() {
        scoreCount = 0;
        LevelFinished = false;
    }

    private void UpdateTexts() {
        if (oldLivesCount != playerInfo.playerLives) {
            texts[1].text = "x" + playerInfo.playerLives;
            oldLivesCount = playerInfo.playerLives;
        }
    }
}
