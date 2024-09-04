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
        //�������� Ŭ��� �ȵȻ��¸�
        if (director.GetComponent<GameDirector>().IsgameClear == false) {
            //�����Ӹ��� ��� ����
            transform.Translate(0, -0.01f, 0);
        }
        

        //�ٴڿ� ������ ������ ����
        if (transform.position.y < -3.5f)
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�ùٸ� ���� �÷��̾�� �浹
        if(collision.gameObject.name == "player")
        {
            //�浹�� ������ ������ �´� ���� ������ �̹��� ����
            if(gameObject.tag == "wheat") { director.GetComponent<GameDirector>().ChangeImage(1); }
            else if (gameObject.tag == "butter") { director.GetComponent<GameDirector>().ChangeImage(2); }
            else if(gameObject.tag == "egg") { director.GetComponent<GameDirector>().ChangeImage(3); }
            else if(gameObject.tag == "strawberry") { director.GetComponent<GameDirector>().ChangeImage(4); }
            else if(gameObject.tag == "milk") { director.GetComponent<GameDirector>().ChangeImage(5); }
            
            //�浹�� ������ ����
            Destroy(gameObject);
        }
        
    }

}
