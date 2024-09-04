using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongItemController : MonoBehaviour
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
        if (director.GetComponent<GameDirector>().IsgameClear == false)
        {
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
        //아이템이 플레이어와 충돌
        if (collision.gameObject.name == "player")
        {
            //케이크 완성도 감소
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseRate();

            Destroy(gameObject); //충돌한 아이템 제거
        }
    }

}

