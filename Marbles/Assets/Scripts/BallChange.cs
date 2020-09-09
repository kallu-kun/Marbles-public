using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BallChange : MonoBehaviour
{

    public GameObject SmallBall;
    public GameObject BigBall;

    public CinemachineVirtualCamera SmallCamera;
    public CinemachineVirtualCamera BigCamera;


    public void Start() {   

        if (SmallBall.activeSelf) {
            BigCamera.gameObject.SetActive(false);
            SmallCamera.VirtualCameraGameObject.SetActive(true);
        } else if (BigBall.activeSelf) {
            SmallBall.gameObject.SetActive(false);
            BigCamera.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BallChange" && SmallBall.activeInHierarchy)
        {

            BigBall.transform.position = SmallBall.transform.position;

            SmallCamera.VirtualCameraGameObject.SetActive(false);
            SmallBall.gameObject.SetActive(false);

            BigCamera.VirtualCameraGameObject.SetActive(true);
            BigBall.gameObject.SetActive(true);

        }
        if (other.gameObject.tag == "BallChange2" && BigBall.activeInHierarchy)
        {

            SmallBall.transform.position = BigBall.transform.position;

            SmallCamera.VirtualCameraGameObject.SetActive(true);
            BigCamera.VirtualCameraGameObject.SetActive(false);

            SmallBall.gameObject.SetActive(true);
            BigBall.gameObject.SetActive(false);

        }
    }
}
