using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject rotatingWorld;

    // Start is called before the first frame update
    void Awake() {
        CreateWorld();
        CreatePlayer();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private GameObject CreateWorld() {
        GameObject world = Instantiate(rotatingWorld);
        // world.transform.position = transform.position;

        return world;
    }

    private GameObject CreatePlayer() {
        GameObject marble = Instantiate(player);
        // marble.transform.position = transform.position;
        marble.transform.position = new Vector3(1, -15);

        return marble;
    }

    public void CompleteLevel ()
    {
        Debug.Log("LEVEL COMPLETE!");
    }
}
