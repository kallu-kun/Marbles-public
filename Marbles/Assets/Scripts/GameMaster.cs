using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckpoint;
    public Vector2 startCheckpoint;
    
    public GameObject ScoreCounter;
    private GameObject player;

    /* 
    private void Awake()
    {   
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    */

    private void Start()
    {   
        player = GameObject.Find("BallSmallFinal");
        if (player == null) {
            player = GameObject.Find("BallBigFinal");
        }

        Debug.Log(player);
        startCheckpoint = player.transform.position;
        lastCheckpoint = player.transform.position;
        Time.timeScale = 1f;
        // Instantiate(ScoreCounter);
        // hp = new PlayerInfo();
    }

}
