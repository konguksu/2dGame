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

    //�Ҹ�
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
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //���콺 Ŭ���� ��ǥ
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f); //�ش� ��ǥ�� �ִ� ������Ʈ Ȯ��

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

        //���ӿ���
        if (this.grandmaGage.GetComponent<Image>().fillAmount < 0.1f)
        {
            this.gameOverBG.SetActive(true);
            this.gameOverBT.SetActive(true);

            this.generator.SetActive(false); //���� ����
            this.IsgameOver = true;
            backGroundSound.Stop();

        }
        //���� Ŭ����
        else if(this.grandmaGage.GetComponent<Image>().fillAmount == 1f)
        {
            this.gameClearBG.SetActive(true);
            this.gameClearBT.SetActive(true);

            this.generator.SetActive(false); //���� ����
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

    //Ŭ���� ��ư ������ �������� 3-2��
    public void ClearBTDown()
    {
        SceneManager.LoadScene("Stage3-2Scene");
    }

    //�ٽõ��� ��ư ������ ��������1 �ٽý���
    public void GameOverBTDown()
    {
        SceneManager.LoadScene("Stage3-1Scene");
    }

}
