using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage2Director : MonoBehaviour
{
    GameObject player;

    //����Ŭ����
    public GameObject clearBG;
    public GameObject clearBT;
    //���ӿ���
    public GameObject GameOver;
    public GameObject retryBT;

    //ü��
    GameObject hp5;
    GameObject hp4;
    GameObject hp3;
    GameObject hp2;
    GameObject hp;

    int hpLeft;

    public Sprite hpEmpty;

    //�Ҹ�
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

    //�ٽõ��� ��ư ������ ��������2 �ٽý���
    public void GOverBTDown()
    {
        SceneManager.LoadScene("Stage2Scene");
        print("�������������");
    }

    //hp ����,�̹�������,��ġ �ʱ�ȭ,���ӿ���
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

    //Ŭ���� �޼ҵ�
    public void GameClear()
    {
        backGroundSound.Stop();
        this.clearBG.SetActive(true);
        this.clearBT.SetActive(true);

    }
    //Ŭ���� ��ư ������ ���� ����������
    public void GClearBTDown()
    {
        SceneManager.LoadScene("Stage3-1Scene");
    }

}
