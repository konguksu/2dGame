using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage3_2Director : MonoBehaviour
{
    //프리팹
    public GameObject up; 
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public GameObject space;

    public GameObject timeGage;

    GameObject[] randPrefab; //프리팹 배열

    GameObject obj1;
    GameObject obj2;
    GameObject obj3;
    GameObject obj4;
    GameObject obj5;

    bool gameStart;

    int again;

    public GameObject gameOverBG;
    public GameObject gameOverBT;
    public GameObject lastBG;

    bool TimeGo;

    int num;
    float timeStop;

    //소리
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public AudioSource backGroundSound;


    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        randPrefab = new GameObject[] { up, down, left, right, space };
 
        Invoke("WhenStart", 3); //3초 뒤에 알림창 끄기
        Invoke("First", 3.1f);
        Invoke("Second", 3.2f);
        Invoke("Third", 3.3f);
        Invoke("Fourth", 3.4f);
        Invoke("Fifth", 3.5f);

        again = 1;
        TimeGo = true;

        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {

            //제한시간 감소
            if (TimeGo) { Invoke("Time", 1); }
            else if (!TimeGo) {

                this.timeGage.GetComponent<Image>().fillAmount = timeStop;
                //스페이스바 몇번 누르는지, 25번 누르면 클리어
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    correctSound.Play();
                    num++;
                    print(num);
                }
                if (num >= 25)
                {
                    SceneManager.LoadScene("ClearScene");
                }
            }
            //게임오버
            if (this.timeGage.GetComponent<Image>().fillAmount < 0.1f) { this.GameOver(); }
            //맞는 키 누르면 사라짐, 잘못누르면 시간 감소
            if (obj1 != null)
            {
                
                if ((obj1.tag == "up" && Input.GetKeyDown(KeyCode.UpArrow))||
                    (obj1.tag == "down" && Input.GetKeyDown(KeyCode.DownArrow))||
                    (obj1.tag == "left" && Input.GetKeyDown(KeyCode.LeftArrow))||
                    (obj1.tag == "right" && Input.GetKeyDown(KeyCode.RightArrow))||
                    (obj1.tag == "space" && Input.GetKeyDown(KeyCode.Space))
                    )
                {
                    correctSound.Play();
                    Destroy(obj1);
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow)||
                    Input.GetKeyDown(KeyCode.DownArrow)||
                    Input.GetKeyDown(KeyCode.LeftArrow)||
                    Input.GetKeyDown(KeyCode.RightArrow)||
                    Input.GetKeyDown(KeyCode.Space)
                    )
                {
                    wrongSound.Play();
                    this.DecreaseTime();
                }
            }

            if(obj2 != null && obj1 == null)
            {
                
                if ((obj2.tag == "up" && Input.GetKeyDown(KeyCode.UpArrow)) ||
                    (obj2.tag == "down" && Input.GetKeyDown(KeyCode.DownArrow)) ||
                    (obj2.tag == "left" && Input.GetKeyDown(KeyCode.LeftArrow)) ||
                    (obj2.tag == "right" && Input.GetKeyDown(KeyCode.RightArrow)) ||
                    (obj2.tag == "space" && Input.GetKeyDown(KeyCode.Space))
                    )
                {
                    correctSound.Play();
                    Destroy(obj2);
                }
                else if(Input.GetKeyDown(KeyCode.UpArrow) ||
                    Input.GetKeyDown(KeyCode.DownArrow) ||
                    Input.GetKeyDown(KeyCode.LeftArrow) ||
                    Input.GetKeyDown(KeyCode.RightArrow) ||
                    Input.GetKeyDown(KeyCode.Space)
                    )
                {
                    wrongSound.Play();
                    this.DecreaseTime();
                }
            }

            if (obj3 != null && obj2 == null)
            {

                if ((obj3.tag == "up" && Input.GetKeyDown(KeyCode.UpArrow)) ||
                    (obj3.tag == "down" && Input.GetKeyDown(KeyCode.DownArrow)) ||
                    (obj3.tag == "left" && Input.GetKeyDown(KeyCode.LeftArrow)) ||
                    (obj3.tag == "right" && Input.GetKeyDown(KeyCode.RightArrow)) ||
                    (obj3.tag == "space" && Input.GetKeyDown(KeyCode.Space))
                    )
                {
                    correctSound.Play();
                    Destroy(obj3);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) ||
                    Input.GetKeyDown(KeyCode.DownArrow) ||
                    Input.GetKeyDown(KeyCode.LeftArrow) ||
                    Input.GetKeyDown(KeyCode.RightArrow) ||
                    Input.GetKeyDown(KeyCode.Space)
                    )
                {
                    wrongSound.Play();
                    this.DecreaseTime();
                }
            }

            if (obj4 != null && obj3 == null)
            {

                if ((obj4.tag == "up" && Input.GetKeyDown(KeyCode.UpArrow)) ||
                    (obj4.tag == "down" && Input.GetKeyDown(KeyCode.DownArrow)) ||
                    (obj4.tag == "left" && Input.GetKeyDown(KeyCode.LeftArrow)) ||
                    (obj4.tag == "right" && Input.GetKeyDown(KeyCode.RightArrow)) ||
                    (obj4.tag == "space" && Input.GetKeyDown(KeyCode.Space))
                    )
                {
                    correctSound.Play();
                    Destroy(obj4);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) ||
                    Input.GetKeyDown(KeyCode.DownArrow) ||
                    Input.GetKeyDown(KeyCode.LeftArrow) ||
                    Input.GetKeyDown(KeyCode.RightArrow) ||
                    Input.GetKeyDown(KeyCode.Space)
                    )
                {
                    wrongSound.Play();
                    this.DecreaseTime();
                }
            }

            if (obj5 != null && obj4 == null)
            {

                if ((obj5.tag == "up" && Input.GetKeyDown(KeyCode.UpArrow)) ||
                    (obj5.tag == "down" && Input.GetKeyDown(KeyCode.DownArrow)) ||
                    (obj5.tag == "left" && Input.GetKeyDown(KeyCode.LeftArrow)) ||
                    (obj5.tag == "right" && Input.GetKeyDown(KeyCode.RightArrow)) ||
                    (obj5.tag == "space" && Input.GetKeyDown(KeyCode.Space))
                    )
                {
                    correctSound.Play();
                    Destroy(obj5);
                    again++;
                    print(again);
                    if(again == 6)
                    {
                        this.TimeGo = false;
                        this.LastStage();
                       
                    }
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) ||
                    Input.GetKeyDown(KeyCode.DownArrow) ||
                    Input.GetKeyDown(KeyCode.LeftArrow) ||
                    Input.GetKeyDown(KeyCode.RightArrow) ||
                    Input.GetKeyDown(KeyCode.Space)
                    )
                {
                    wrongSound.Play();
                    this.DecreaseTime();
                }
            }

            //반복
            if(again == 2)
            {
                Invoke("First", 0f);
                Invoke("Second", 0.1f);
                Invoke("Third", 0.2f);
                Invoke("Fourth", 0.3f);
                Invoke("Fifth", 0.4f);
                again++;
            }
            if(again == 4)
            {
                Invoke("First", 0f);
                Invoke("Second", 0.1f);
                Invoke("Third", 0.2f);
                Invoke("Fourth", 0.3f);
                Invoke("Fifth", 0.4f);
                again++;
            }

        }

    }

    void Time()
    {
        this.timeGage.GetComponent<Image>().fillAmount -= 0.0005f;
    }

    void First()
    {
        // 랜덤으로 방향키 고르고 생성
        obj1 = Instantiate(randPrefab[Random.Range(0, 5)]) as GameObject;
        obj1.transform.position = new Vector3(-4.5f, -1f, 0);       

    }

    void Second()
    {
        // 랜덤으로 방향키 고르고 생성
        obj2 = Instantiate(randPrefab[Random.Range(0, 5)]) as GameObject;
        obj2.transform.position = new Vector3(-2.5f, -1f, 0);
        
    }

    void Third()
    {
        // 랜덤으로 방향키 고르고 생성
        obj3 = Instantiate(randPrefab[Random.Range(0, 5)]) as GameObject;
        obj3.transform.position = new Vector3(-0.5f, -1f, 0);
        
    }

    void Fourth()
    {
        // 랜덤으로 방향키 고르고 생성
        obj4 = Instantiate(randPrefab[Random.Range(0, 5)]) as GameObject;
        obj4.transform.position = new Vector3(1.75f, -1f, 0);
        
    }
    void Fifth()
    {
        // 랜덤으로 방향키 고르고 생성
        obj5 = Instantiate(randPrefab[Random.Range(0, 5)]) as GameObject;
        obj5.transform.position = new Vector3(4f, -1f, 0);
        gameStart = true;

    }

    void WhenStart()
    {
        Destroy(GameObject.Find("alert"));
        
    }

    public void DecreaseTime()
    {
        this.timeGage.GetComponent<Image>().fillAmount -= 0.1f;

    }

    //마지막 스페이스바 연타 화면 활성화, 5초뒤 게임오버
    void LastStage()
    {
        
        this.lastBG.SetActive(true);
        Invoke("GameOver", 5);
        timeStop = this.timeGage.GetComponent<Image>().fillAmount;
        backGroundSound.Stop();


    }

    void GameOver()
    {
        this.gameOverBG.SetActive(true);
        this.gameOverBT.SetActive(true);
        this.lastBG.SetActive(false);
        backGroundSound.Stop();
    }
    

    //다시도전 버튼 누르면 스테이지3-2 다시시작
    public void GameOverBTDown()
    {
        SceneManager.LoadScene("Stage3-2Scene");
    }
}
