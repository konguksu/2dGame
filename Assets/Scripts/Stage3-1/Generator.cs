using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //������ - �ҸӴ� & ����
    public GameObject grandmaPrefab; //�ҸӴ� 
    public GameObject wolfPrefab; //����
 
    GameObject[] randPrefab; //������

    GameObject obj1;
    GameObject obj2;
    GameObject obj3;
    GameObject obj4;

    bool one;
    bool two;
    bool three;
    bool four;

    public float x1;
    public float x2;
    public float x3;
    public float x4;
    public float y1;
    public float y2;

    // Start is called before the first frame update
    void Start()
    {
        randPrefab = new GameObject[] { grandmaPrefab, wolfPrefab };

        one = true;
        two = true;
        three = true;
        four = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //�� ��ġ�� ������Ʈ�� ��������� Ȯ���ϰ� ��������� 1-2�� ���� ������ �ð� ��� �� �ٽ� ����

        if (obj1 == null && one)
        {
            one = false;
            Invoke("FirstPlace", Random.Range(1.0f, 8f));
        }

        if (obj2 == null && two)
        {
            two = false;
            Invoke("SecondPlace", Random.Range(3f, 8f));           
        }

        if (obj3 == null && three)
        {
            three = false;
            Invoke("ThirdPlace", Random.Range(4f, 8f));           
        }

        if (obj4 == null && four)
        {
            four = false;
            Invoke("FourthPlace", Random.Range(1.0f, 8f));
        }


    }

    void FirstPlace()
    {
        one = true;
        int i = Random.Range(0, 2);
        obj1 = Instantiate(randPrefab[i]) as GameObject; // �������� ����/�ҸӴ� ���� ����
        //�ҸӴϸ�
        if (i == 0)
        {
            obj1.transform.position = new Vector3(x1, y1, 0);
        }
        //�����
        else if (i == 1)
        {
            obj1.transform.position = new Vector3(x1, y2, 0);
        }

    }

    void SecondPlace()
    {
        two = true;
        int i = Random.Range(0, 2);
        obj2 = Instantiate(randPrefab[i]) as GameObject; // �������� ����/�ҸӴ� ���� ����
        //�ҸӴ�
        if (i == 0) {
            obj2.transform.position = new Vector3(x2,y1, 0);
        }
        //����
        else if (i == 1) {
            obj2.transform.position = new Vector3(x2,y2, 0);
        } 
    }

    void ThirdPlace()
    {
        three = true;
        int i = Random.Range(0, 2);
        obj3 = Instantiate(randPrefab[i]) as GameObject; // �������� ����/�ҸӴ� ���� ����
        if (i == 0) {
            obj3.transform.position = new Vector3(x3,y1, 0);
        } //�ҸӴϸ�
        else if (i == 1) {
            obj3.transform.position = new Vector3(x3, y2, 0);
        } //�����
    }

    void FourthPlace()
    {
        four = true;
        int i = Random.Range(0, 2);
        obj4 = Instantiate(randPrefab[i]) as GameObject; // �������� ����/�ҸӴ� ���� ����
        if (i == 0)
        {
            obj4.transform.position = new Vector3(x4, y1, 0);
        } //�ҸӴϸ�
        else if (i==1)
        {
            obj4.transform.position = new Vector3(x4, y2, 0);
        } //�����
    }



}
