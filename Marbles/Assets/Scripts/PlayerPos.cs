using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    private PlayerInfo hp;
    public GameObject deathscreen;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        hp = FindObjectOfType<PlayerInfo>();
        transform.position = gm.lastCheckpoint;
        // hp = new PlayerInfo();
        gm.startCheckpoint = transform.position;
    }

    private void Update() {
        /* 
        if (hp.DecreaseLives()) {
            Debug.Log("jee");
            gameObject.transform.position = gm.lastCheckpoint;
        }
        */

        /* 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hp.DecreaseLives();
            if (hp.PlayerDead())
            {
                gm.lastCheckpoint = gm.startCheckpoint;
                deathscreen.SetActive(true);
            }
            transform.position = gm.lastCheckpoint;
        }
        */
    }
}
