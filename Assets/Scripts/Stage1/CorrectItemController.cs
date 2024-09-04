using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectItemController : MonoBehaviour
{
    GameObject director;
    

    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        
    }

    // Update is called once per frame
    void Update()
    {
        //스테이지 클리어가 안된상태면
        if (director.GetComponent<GameDirector>().IsgameClear == false) {
            //프레임마다 등속 낙하
            transform.Translate(0, -0.01f, 0);
        }
        

        //바닥에 닿으면 아이템 제거
        if (transform.position.y < -3.5f)
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //올바른 재료랑 플레이어랑 충돌
        if(collision.gameObject.name == "player")
        {
            //충돌한 아이템 종류에 맞는 남은 아이템 이미지 변경
            if(gameObject.tag == "wheat") { director.GetComponent<GameDirector>().ChangeImage(1); }
            else if (gameObject.tag == "butter") { director.GetComponent<GameDirector>().ChangeImage(2); }
            else if(gameObject.tag == "egg") { director.GetComponent<GameDirector>().ChangeImage(3); }
            else if(gameObject.tag == "strawberry") { director.GetComponent<GameDirector>().ChangeImage(4); }
            else if(gameObject.tag == "milk") { director.GetComponent<GameDirector>().ChangeImage(5); }
            
            //충돌한 아이템 제거
            Destroy(gameObject);
        }
        
    }

}
