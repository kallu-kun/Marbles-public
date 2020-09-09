using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameMaster gm;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite checkpointNotHit;

    [SerializeField]
    private Sprite checkpointHit;

    private AudioSource audioSource;

    private bool isHit;

    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = checkpointNotHit;
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && !isHit)
        {
            audioSource.Play();
            Debug.Log("New lastposition");
            gm.lastCheckpoint = other.transform.position;
            
            spriteRenderer.sprite = checkpointHit;
            isHit = true;
        }
    }
}
