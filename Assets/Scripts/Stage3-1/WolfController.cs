using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    string state;
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //top찍기 전에
        if (state != "Top")
        {
            //프레임마다 올라옴
            this.GoUp();

            //y좌표 1.4찍으면 상태 Top으로
            if (this.transform.position.y >= 1.4f)
            {
                state = "Top";

            }
        }
        //상태 Top되면 
        else
        {
            Invoke("GoDown", Random.Range(1f, 2f)); //1초-2초 사이 랜덤한 시간 기다렸다가 내려감.

            //완전히 내려가면 제거
            if (this.transform.position.y <= -1.7f)
            {
                Destroy(gameObject);

            }


        }

        
    }

    void GoUp()
    {
        transform.Translate(0, 0.03f, 0);
    }
    void GoDown()
    {
        transform.Translate(0, -0.05f, 0);
    }

   
}
