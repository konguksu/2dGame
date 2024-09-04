using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    //����ũ �ϼ��� ��������
    GameObject RateBar;

    //���� ���
    GameObject wheatGray;
    GameObject butterGray;
    GameObject eggGray;
    GameObject strawberryGray;
    GameObject milkGray;

    //��Ḧ ������ �ٲ� �̹���
    public Sprite wheatFilled;
    public Sprite butterFilled;
    public Sprite eggFilled;
    public Sprite strawberryFilled;
    public Sprite milkFilled;

    //�ϼ��� �ۼ�Ʈ(�ؽ�Ʈ)����
    GameObject RateBar_num;
    public Sprite fourLeft;
    public Sprite threeLeft;
    public Sprite twoLeft;
    public Sprite oneLeft;

    int rateLeft;

    //����Ŭ���� ���� ����&����
    public bool[] gameClear;
    public bool IsgameClear;

    public GameObject clearBG;
    public GameObject clearBT;

    //���� ������ ���� ���߱� ���Ѱ͵�
    public GameObject itemGen;
    public GameObject player;

    //���ӿ��� ȭ��&��ư
    public GameObject GameOver;
    public GameObject retryBT;

    //ȿ����
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

    //����ũ �ϼ��� ���� �޼ҵ�
    public void DecreaseRate()
    {
        this.RateBar.GetComponent<Image>().fillAmount -= 0.2f;
         

        //�ϼ��� �پ�鶧���� �ۼ�Ʈ(�ؽ�Ʈ)����
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
            // ������ ��� �پ��� ���ӿ��� ȭ�� ����
            case 0:
                {
                    this.GameOver.SetActive(true);
                    this.retryBT.SetActive(true);

                    this.itemGen.SetActive(false); //������ ���� ����
                    this.player.GetComponent<PlayerController>().enabled = false; //�÷��̾� �̵� ����

                    this.IsgameClear = true; //���� ����
                    backGroundSound.Stop(); //������� ����
                    alertSound.Stop();
                }
                return;
        }

    }

    //���� ��� �̹��� ����&���� �޼ҵ�
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
        //��� ������ �� �Ծ�����
        if(gameClear[0] == true && 
            gameClear[1]==true && 
            gameClear[2] == true && 
            gameClear[3] == true && 
            gameClear[4] == true)
        {
            //Ŭ���� ȭ��&��ư Ȱ��ȭ
            this.clearBG.SetActive(true);
            this.clearBT.SetActive(true);

            this.itemGen.SetActive(false); //������ ���� ����
            this.player.GetComponent<PlayerController>().enabled = false; //�÷��̾� �̵� ����

            this.IsgameClear = true;//������ ������ ����
            backGroundSound.Stop(); //������� ����
            alertSound.Stop();

        }
    }

    //Ŭ���� ��ư ������ �������� 2��
    public void ClearBTDown()
    {
        ButtonSound.Play();//ȿ����
        SceneManager.LoadScene("Stage2Scene");
        
    }

    //�ٽõ��� ��ư ������ ��������1 �ٽý���
    public void GOverBTDown()
    {
        ButtonSound.Play();//ȿ����
        SceneManager.LoadScene("Stage1Scene");
        
    }

}
