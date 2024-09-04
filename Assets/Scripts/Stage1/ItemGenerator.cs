using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //맞는 재료 아이템 5개
    public GameObject wheatPrefab; //밀 
    public GameObject butterPrefab; //버터
    public GameObject eggPrefab; //달걀
    public GameObject milkPrefab; //우유
    public GameObject strawberryPrefab; //딸기

    GameObject[] correctItem; //배열

    //틀린 재료 아이템 6개
    public GameObject wrongItem1P;
    public GameObject wrongItem2P;
    public GameObject wrongItem3P;
    public GameObject wrongItem4P;
    public GameObject wrongItem5P;
    public GameObject wrongItem6P;

    GameObject[] wrongItem;//배열

    float span = 1.0f; //아이템 생성 속도
    float delta = 0; //흐른 시간 측정할 변수

    int num = 1;//맞는재료,틀린재료 생성 주기 관련
    
    

    



    // Start is called before the first frame update
    void Start()
    {       
        this.correctItem = new GameObject[] { wheatPrefab, butterPrefab, eggPrefab, milkPrefab, strawberryPrefab };
        this.wrongItem = new GameObject[] { wrongItem1P, wrongItem2P, wrongItem3P, wrongItem4P, wrongItem5P, wrongItem6P };
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime; //시간 측정
        

        if (this.delta > this.span) //지정한 시간만큼 지나면
        {
            this.delta = 0; //시간 초기화
            int px = Random.Range(-6, 7); //랜덤 x좌표 설정

            //틀린아이템 생성
            if (num != 3) { 
                num++;                               

                GameObject wItem = Instantiate(this.wrongItem[Random.Range(0, wrongItem.Length)]); //랜덤으로 틀린 아이템 생성
                wItem.transform.position = new Vector3(px, 7, 0); //초기위치
                print("틀린아이템 생성" + num);

                
            }

            //3번째는 맞는 재료 아이템
            else
            {
                num = 0; //num 초기화               

                GameObject cItem = Instantiate(this.correctItem[Random.Range(0, correctItem.Length)]); //랜덤으로 맞는 아이템 생성
                cItem.transform.position = new Vector3(px, 7, 0);//초기위치
                print("맞는아이템 생성" + num);

            }
 
            
        }
    }
}
