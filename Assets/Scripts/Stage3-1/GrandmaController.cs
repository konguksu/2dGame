using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaController : MonoBehaviour
{
    string state;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //top��� ����
        if(state != "Top")
        {
            //�����Ӹ��� �ö��
            this.GoUp();

            //y��ǥ 1������ ���� Top����
            if (this.transform.position.y >= 1f)
            {
                state = "Top";

            }
        }
        //���� Top�Ǹ� 
        else
        {
            Invoke("GoDown", Random.Range(1f, 2f)); //1��-2�� ���� ������ �ð� ��ٷȴٰ� ������.

            //������ �������� ����
            if(this.transform.position.y <= -2.2f){
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
