using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Transform playerPos;
    Vector3 cameraPosition;
    [SerializeField]
    float cameraMoveSpeed;

    float  height,width;
    [SerializeField]
    float left,right,up,down;//맵 크기
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");;

        playerPos = player.GetComponent<Transform>();
        cameraPosition = new Vector3(0, 0, -10);

        //카메라가 비추는 가로세로 절반
        this.height = Camera.main.orthographicSize;
        this.width = height * Screen.width / Screen.height;

    }

    void LimitCameraArea()
    {
        transform.position = Vector3.Lerp(transform.position, playerPos.position + cameraPosition, cameraMoveSpeed * Time.deltaTime);

        
        float clampX = Mathf.Clamp(transform.position.x, -(left - width), right - width);
        float clampY = Mathf.Clamp(transform.position.y, -(down - height), up - height);

        transform.position = new Vector3(clampX, clampY, -10);
    }

        

    // Update is called once per frame
    void Update()
    {
        LimitCameraArea();
    }
}
