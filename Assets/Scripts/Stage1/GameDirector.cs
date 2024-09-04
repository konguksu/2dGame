using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    //케이크 완성도 게이지바
    GameObject RateBar;

    //남은 재료
    GameObject wheatGray;
    GameObject butterGray;
    GameObject eggGray;
    GameObject strawberryGray;
    GameObject milkGray;

    //재료를 먹으면 바꿀 이미지
    public Sprite wheatFilled;
    public Sprite butterFilled;
    public Sprite eggFilled;
    public Sprite strawberryFilled;
    public Sprite milkFilled;

    //완성도 퍼센트(텍스트)변경
    GameObject RateBar_num;
    public Sprite fourLeft;
    public Sprite threeLeft;
    public Sprite twoLeft;
    public Sprite oneLeft;

    int rateLeft;

    //게임클리어 조건 감시&저장
    public bool[] gameClear;
    public bool IsgameClear;

    public GameObject clearBG;
    public GameObject clearBT;

    //게임 오버시 게임 멈추기 위한것들
    public GameObject itemGen;
    public GameObject player;

    //게임오버 화면&버튼
    public GameObject GameOver;
    public GameObject retryBT;

    //효과음
    public AudioSource ButtonSound;
    public AudioSource eatSound;
    public AudioSource wrongItemSound;
    public AudioSource alertSound;
    public AudioSource backGroundSound;
   

    // Start is called before the first frame update
    void Start()
    {
        this.RateBar = GameObject.Find("RateBar");

        this.wheatGray = GameObject.Find("wheatGray");
        this.butterGray = GameObject.Find("butterGray");
        this.eggGray = GameObject.Find("eggGray");
        this.strawberryGray = GameObject.Find("strawberryGray");
        this.milkGray = GameObject.Find("milkGray");

        this.RateBar_num = GameObject.Find("RateBar_num");
        this.rateLeft = 4;

        this.gameClear = new bool[5];
        this.IsgameClear = false;
    }

    //케이크 완성도 감시 메소드
    public void DecreaseRate()
    {
        this.RateBar.GetComponent<Image>().fillAmount -= 0.2f;
         

        //완성도 줄어들때마다 퍼센트(텍스트)변경
        switch (rateLeft)
        {
            case 4:
                {
                    this.RateBar_num.GetComponent<Image>().sprite = fourLeft;
                    rateLeft--;
                    wrongItemSound.Play();
                }
                return;
            case 3:
                {
                    this.RateBar_num.GetComponent<Image>().sprite = threeLeft;
                    rateLeft--;
                    wrongItemSound.Play();
                }
                return;
            case 2:
                {
                    this.RateBar_num.GetComponent<Image>().sprite = twoLeft;
                    rateLeft--;
                    wrongItemSound.Play();
                }
                return;
            case 1:
                {
                    this.RateBar_num.GetComponent<Image>().sprite = oneLeft;
                    rateLeft--;
                    wrongItemSound.Play();
                    alertSound.Play();
                }
                return;
            // 게이지 모두 줄어들면 게임오버 화면 띄우기
            case 0:
                {
                    this.GameOver.SetActive(true);
                    this.retryBT.SetActive(true);

                    this.itemGen.SetActive(false); //아이템 생성 중지
                    this.player.GetComponent<PlayerController>().enabled = false; //플레이어 이동 중지

                    this.IsgameClear = true; //게임 멈춤
                    backGroundSound.Stop(); //배경음악 멈춤
                    alertSound.Stop();
                }
                return;
        }

    }

    //남은 재료 이미지 변경&감시 메소드
    public void ChangeImage(int i)
    {
        eatSound.Play();
        if (i == 1)
        {
            this.wheatGray.GetComponent<Image>().sprite = wheatFilled;
            gameClear[0] = true;
        }

        else if (i == 2)
        {
            this.butterGray.GetComponent<Image>().sprite = butterFilled;
            gameClear[1] = true;
        }

        else if (i == 3)
        {
            this.eggGray.GetComponent<Image>().sprite = eggFilled;
            gameClear[2] = true;
        }

        else if (i == 4)
        {
            this.strawberryGray.GetComponent<Image>().sprite = strawberryFilled;
            gameClear[3] = true;
        }

        else if (i == 5)
        {
            this.milkGray.GetComponent<Image>().sprite = milkFilled;
            gameClear[4] = true;
        }

    
    }

    // Update is called once per frame
    void Update()
    {
        //재료 아이템 다 먹었으면
        if(gameClear[0] == true && 
            gameClear[1]==true && 
            gameClear[2] == true && 
            gameClear[3] == true && 
            gameClear[4] == true)
        {
            //클리어 화면&버튼 활성화
            this.clearBG.SetActive(true);
            this.clearBT.SetActive(true);

            this.itemGen.SetActive(false); //아이템 생성 중지
            this.player.GetComponent<PlayerController>().enabled = false; //플레이어 이동 중지

            this.IsgameClear = true;//아이템 움직임 멈춤
            backGroundSound.Stop(); //배경음악 멈춤
            alertSound.Stop();

        }
    }

    //클리어 버튼 누르면 스테이지 2로
    public void ClearBTDown()
    {
        ButtonSound.Play();//효과음
        SceneManager.LoadScene("Stage2Scene");
        
    }

    //다시도전 버튼 누르면 스테이지1 다시시작
    public void GOverBTDown()
    {
        ButtonSound.Play();//효과음
        SceneManager.LoadScene("Stage1Scene");
        
    }

}
