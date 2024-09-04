using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage2Director : MonoBehaviour
{
    GameObject player;

    //게임클리어
    public GameObject clearBG;
    public GameObject clearBT;
    //게임오버
    public GameObject GameOver;
    public GameObject retryBT;

    //체력
    GameObject hp5;
    GameObject hp4;
    GameObject hp3;
    GameObject hp2;
    GameObject hp;

    int hpLeft;

    public Sprite hpEmpty;

    //소리
    public AudioSource wrongSound;
    public AudioSource backGroundSound;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");

        this.hp5 = GameObject.Find("hp5");
        this.hp4 = GameObject.Find("hp4");
        this.hp3 = GameObject.Find("hp3");
        this.hp2 = GameObject.Find("hp2");
        this.hp = GameObject.Find("hp");

        this.hpLeft = 4;

       }

    // Update is called once per frame
    void Update()
    {

    }

    //다시도전 버튼 누르면 스테이지2 다시시작
    public void GOverBTDown()
    {
        SceneManager.LoadScene("Stage2Scene");
        print("스테이지재시작");
    }

    //hp 감시,이미지변경,위치 초기화,게임오버
    public void DecreaseHP()
    {

        switch (hpLeft)
        {
            case 4:
                {
                    player.GetComponent<Transform>().position = new Vector3(-6, 0, 0);
                    hpLeft--;
                    this.hp5.GetComponent<Image>().sprite = hpEmpty;
                    player.GetComponent<ST2PlayerController>().x = 0.03f;
                    player.GetComponent<ST2PlayerController>().y = 0;
                    wrongSound.Play();
                }
                return;
            case 3:
                {
                    this.hp4.GetComponent<Image>().sprite = hpEmpty;
                    hpLeft--;
                    player.GetComponent<Transform>().position = new Vector3(-6, 0, 0);
                    player.GetComponent<ST2PlayerController>().x = 0.03f;
                    player.GetComponent<ST2PlayerController>().y = 0;
                    wrongSound.Play();
                }
                return;
            case 2:
                {
                    this.hp3.GetComponent<Image>().sprite = hpEmpty;
                    hpLeft--;
                    player.GetComponent<Transform>().position = new Vector3(-6, 0, 0);
                    player.GetComponent<ST2PlayerController>().x = 0.03f;
                    player.GetComponent<ST2PlayerController>().y = 0;
                    wrongSound.Play();
                }
                return;
            case 1:
                {
                    this.hp2.GetComponent<Image>().sprite = hpEmpty;
                    hpLeft--;
                    player.GetComponent<Transform>().position = new Vector3(-6, 0, 0);
                    player.GetComponent<ST2PlayerController>().x = 0.03f;
                    player.GetComponent<ST2PlayerController>().y = 0;
                    wrongSound.Play();
                }
                return;
            case 0:
                {
                    backGroundSound.Stop();

                    this.GameOver.SetActive(true);
                    this.retryBT.SetActive(true);

                    player.GetComponent<ST2PlayerController>().left = false;
                    player.GetComponent<ST2PlayerController>().right = false;
                    player.GetComponent<ST2PlayerController>().up = false;
                    player.GetComponent<ST2PlayerController>().down = false;

                    player.GetComponent<ST2PlayerController>().x = 0f;
                    player.GetComponent<ST2PlayerController>().y = 0;
                }
                return;
        }

    }

    //클리어 메소드
    public void GameClear()
    {
        backGroundSound.Stop();
        this.clearBG.SetActive(true);
        this.clearBT.SetActive(true);

    }
    //클리어 버튼 누르면 다음 스테이지로
    public void GClearBTDown()
    {
        SceneManager.LoadScene("Stage3-1Scene");
    }

}
