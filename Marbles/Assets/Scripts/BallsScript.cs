using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallsScript : MonoBehaviour
{
    private static int totalBalls;
    private TMPro.TextMeshProUGUI balls;
    private GameObject[] ringList;
    private PlayerInfo playerInfo;

    void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
        totalBalls = playerInfo.playerLives;
        balls = FindObjectOfType<TMPro.TextMeshProUGUI>();
        ringList = GameObject.FindGameObjectsWithTag("Ring");
        //totalCount = ringList.Length;
    }


    void Update()
    {
        balls.text = "Balls: " + playerInfo.playerLives + "/" + totalBalls;
    }

}
