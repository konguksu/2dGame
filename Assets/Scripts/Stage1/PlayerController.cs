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
        //���� ����Ű�� ������ �������� �̵�
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            //ȭ�� ������ ����� �ʰ� ���� ����
            if (transform.position.x > -7.3)
            {
                transform.Translate(-1, 0, 0);
            }
            
        }

        //������ ����Ű�� ������ �������� �̵�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //ȭ�� ������ ����� �ʰ� ���� ����
            if (transform.position.x < 7.3)
            {
                transform.Translate(1, 0, 0);
            }
            
        }
    }
}
