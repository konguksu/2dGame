using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //�´� ��� ������ 5��
    public GameObject wheatPrefab; //�� 
    public GameObject butterPrefab; //����
    public GameObject eggPrefab; //�ް�
    public GameObject milkPrefab; //����
    public GameObject strawberryPrefab; //����

    GameObject[] correctItem; //�迭

    //Ʋ�� ��� ������ 6��
    public GameObject wrongItem1P;
    public GameObject wrongItem2P;
    public GameObject wrongItem3P;
    public GameObject wrongItem4P;
    public GameObject wrongItem5P;
    public GameObject wrongItem6P;

    GameObject[] wrongItem;//�迭

    float span = 1.0f; //������ ���� �ӵ�
    float delta = 0; //�帥 �ð� ������ ����

    int num = 1;//�´����,Ʋ����� ���� �ֱ� ����
    
    

    



    // Start is called before the first frame update
    void Start()
    {       
        this.correctItem = new GameObject[] { wheatPrefab, butterPrefab, eggPrefab, milkPrefab, strawberryPrefab };
        this.wrongItem = new GameObject[] { wrongItem1P, wrongItem2P, wrongItem3P, wrongItem4P, wrongItem5P, wrongItem6P };
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime; //�ð� ����
        

        if (this.delta > this.span) //������ �ð���ŭ ������
        {
            this.delta = 0; //�ð� �ʱ�ȭ
            int px = Random.Range(-6, 7); //���� x��ǥ ����

            //Ʋ�������� ����
            if (num != 3) { 
                num++;                               

                GameObject wItem = Instantiate(this.wrongItem[Random.Range(0, wrongItem.Length)]); //�������� Ʋ�� ������ ����
                wItem.transform.position = new Vector3(px, 7, 0); //�ʱ���ġ
                print("Ʋ�������� ����" + num);

                
            }

            //3��°�� �´� ��� ������
            else
            {
                num = 0; //num �ʱ�ȭ               

                GameObject cItem = Instantiate(this.correctItem[Random.Range(0, correctItem.Length)]); //�������� �´� ������ ����
                cItem.transform.position = new Vector3(px, 7, 0);//�ʱ���ġ
                print("�´¾����� ����" + num);

            }
 
            
        }
    }
}
