using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour {
    
    [SerializeField]
    GameObject ramp;

    private WorldCreator worldCreator;

    void Start() {
        worldCreator = FindObjectOfType<WorldCreator>();
        CreateObstacle();
    }

    
    void Update() {
        
    }

    private GameObject CreateObstacle() {

        GameObject obstacle = Instantiate(ramp);
        obstacle.transform.position = new Vector3(1, -15);
        return obstacle;
    }
}
