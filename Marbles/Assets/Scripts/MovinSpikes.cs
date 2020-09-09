using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinSpikes : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public bool horizontal;
    private Vector3 suunta;

    private void Start()
    {   
        
        if(vertical)
        {
            suunta = Vector3.up;
        }
        else if(horizontal)
        {
            suunta = Vector3.right;
        }
        
    }

    private void Update()
    {
        Move(suunta);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int x = 1;
        if (collision.gameObject.tag != "Player")
        {
            if (x == 1)
            {
                suunta *= -x;
            }
            else if(x == 0)
            {
                suunta *= x;
            }
            x = 0;
        }
    }
    private void Move(Vector3 suunta)
    {
        transform.Translate(suunta * speed * Time.deltaTime);
    }
}
