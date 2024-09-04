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
        //�������� Ŭ��� �ȵȻ��¸�
        if (director.GetComponent<GameDirector>().IsgameClear == false)
        {
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
        //�������� �÷��̾�� �浹
        if (collision.gameObject.name == "player")
        {
            //����ũ �ϼ��� ����
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseRate();

            Destroy(gameObject); //�浹�� ������ ����
        }
    }

}

