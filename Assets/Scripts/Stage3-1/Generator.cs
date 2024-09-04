using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //프리팹 - 할머니 & 늑대
    public GameObject grandmaPrefab; //할머니 
    public GameObject wolfPrefab; //늑대
 
    GameObject[] randPrefab; //프리팹

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
        //각 위치에 오브젝트가 사라졌는지 확인하고 사라졌으면 1-2초 사이 랜덤한 시간 대기 후 다시 생성

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
        obj1 = Instantiate(randPrefab[i]) as GameObject; // 랜덤으로 늑대/할머니 고르고 생성
        //할머니면
        if (i == 0)
        {
            obj1.transform.position = new Vector3(x1, y1, 0);
        }
        //늑대면
        else if (i == 1)
        {
            obj1.transform.position = new Vector3(x1, y2, 0);
        }

    }

    void SecondPlace()
    {
        two = true;
        int i = Random.Range(0, 2);
        obj2 = Instantiate(randPrefab[i]) as GameObject; // 랜덤으로 늑대/할머니 고르고 생성
        //할머니
        if (i == 0) {
            obj2.transform.position = new Vector3(x2,y1, 0);
        }
        //늑대
        else if (i == 1) {
            obj2.transform.position = new Vector3(x2,y2, 0);
        } 
    }

    void ThirdPlace()
    {
        three = true;
        int i = Random.Range(0, 2);
        obj3 = Instantiate(randPrefab[i]) as GameObject; // 랜덤으로 늑대/할머니 고르고 생성
        if (i == 0) {
            obj3.transform.position = new Vector3(x3,y1, 0);
        } //할머니면
        else if (i == 1) {
            obj3.transform.position = new Vector3(x3, y2, 0);
        } //늑대면
    }

    void FourthPlace()
    {
        four = true;
        int i = Random.Range(0, 2);
        obj4 = Instantiate(randPrefab[i]) as GameObject; // 랜덤으로 늑대/할머니 고르고 생성
        if (i == 0)
        {
            obj4.transform.position = new Vector3(x4, y1, 0);
        } //할머니면
        else if (i==1)
        {
            obj4.transform.position = new Vector3(x4, y2, 0);
        } //늑대면
    }



}
