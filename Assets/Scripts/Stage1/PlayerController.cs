using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //왼쪽 방향키를 누르면 좌측으로 이동
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            //화면 밖으로 벗어나지 않게 범위 설정
            if (transform.position.x > -7.3)
            {
                transform.Translate(-1, 0, 0);
            }
            
        }

        //오른쪽 방향키를 누르면 우측으로 이동
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //화면 밖으로 벗어나지 않게 범위 설정
            if (transform.position.x < 7.3)
            {
                transform.Translate(1, 0, 0);
            }
            
        }
    }
}
