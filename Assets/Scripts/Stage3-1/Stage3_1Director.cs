using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage3_1Director : MonoBehaviour
{
    GameObject grandmaGage;
    GameObject wolfGage;
    GameObject generator;

    public GameObject gameOverBG;
    public GameObject gameOverBT;
    public GameObject gameClearBG;
    public GameObject gameClearBT;

    bool IsgameOver;

    //소리
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public AudioSource backGroundSound;

    // Start is called before the first frame update
    void Start()
    {
        this.grandmaGage = GameObject.Find("grandmaGage");
        this.wolfGage = GameObject.Find("wolfGage");
        this.generator = GameObject.Find("Generator");

        this.IsgameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsgameOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 클릭한 좌표
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f); //해당 좌표에 있는 오브젝트 확인

            if(hit.collider != null)
            {
                GameObject clickedObj = hit.transform.gameObject;
                Destroy(clickedObj);
                if (clickedObj.tag == "stage3wolf")
                {
                    correctSound.Play();
                    this.DecreaseWolf();
                }
                else if(clickedObj.tag == "stage3grandma")
                {
                    wrongSound.Play();
                    this.DecreaseGrandma();
                }

            }
        }

        //게임오버
        if (this.grandmaGage.GetComponent<Image>().fillAmount < 0.1f)
        {
            this.gameOverBG.SetActive(true);
            this.gameOverBT.SetActive(true);

            this.generator.SetActive(false); //생성 중지
            this.IsgameOver = true;
            backGroundSound.Stop();

        }
        //게임 클리어
        else if(this.grandmaGage.GetComponent<Image>().fillAmount == 1f)
        {
            this.gameClearBG.SetActive(true);
            this.gameClearBT.SetActive(true);

            this.generator.SetActive(false); //생성 중지
            this.IsgameOver = true;
            backGroundSound.Stop();
        }
    }

    public void DecreaseGrandma()
    {
        this.grandmaGage.GetComponent<Image>().fillAmount -= 0.1f;
        this.wolfGage.GetComponent<Image>().fillAmount += 0.1f;
        
    }

    public void DecreaseWolf()
    {
        this.wolfGage.GetComponent<Image>().fillAmount -= 0.1f;
        this.grandmaGage.GetComponent<Image>().fillAmount += 0.1f;
        
    }

    //클리어 버튼 누르면 스테이지 3-2로
    public void ClearBTDown()
    {
        SceneManager.LoadScene("Stage3-2Scene");
    }

    //다시도전 버튼 누르면 스테이지1 다시시작
    public void GameOverBTDown()
    {
        SceneManager.LoadScene("Stage3-1Scene");
    }

}
