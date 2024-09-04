using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneDirector : MonoBehaviour
{
    public GameObject RuleBT;
    public GameObject GameStartBT;
    public GameObject rule1;
    public GameObject RuleBT1;
    public GameObject rule2;
    public GameObject RuleBT2;
    public GameObject rule3;
    public GameObject RuleBT3;

    public AudioSource ButtonSound;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBTDown()
    {
        SceneManager.LoadScene("Stage1Scene");
        ButtonSound.Play();//ȿ����
    }
    public void RuleBTDown()
    {
        ButtonSound.Play();//ȿ����

        //��Ģȭ��1Ȱ��ȭ
        this.rule1.SetActive(true);
        this.RuleBT1.SetActive(true);

        //����ȭ�� ��Ȱ��ȭ
        this.RuleBT.SetActive(false);
        this.GameStartBT.SetActive(false);
    }

    //��Ģ1 ȭ���� next ��ư
    public void Rule1BTDown()
    {
        ButtonSound.Play();//ȿ����

        //��Ģȭ��2Ȱ��ȭ
        this.rule2.SetActive(true);
        this.RuleBT2.SetActive(true);

        //����ȭ�� ��Ȱ��ȭ
        this.rule1.SetActive(false);
        this.RuleBT1.SetActive(false);
    }
    //��Ģ2 ȭ���� next��ư
    public void Rule2BTDown()
    {
        ButtonSound.Play();//ȿ����

        //��Ģȭ��3Ȱ��ȭ
        this.rule3.SetActive(true);
        this.RuleBT3.SetActive(true);

        //����ȭ�� ��Ȱ��ȭ
        this.rule2.SetActive(false);
        this.RuleBT2.SetActive(false);
    }
    //��Ģ3ȭ���� end
    public void Rule3BTDown()
    {
        ButtonSound.Play();//ȿ����

        //����ȭ�� Ȱ��ȭ
        this.RuleBT.SetActive(true);
        this.GameStartBT.SetActive(true);

        //����ȭ�� ��Ȱ��ȭ
        this.rule3.SetActive(false);
        this.RuleBT3.SetActive(false);
    }
    
}
