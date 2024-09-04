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
        ButtonSound.Play();//효과음
    }
    public void RuleBTDown()
    {
        ButtonSound.Play();//효과음

        //규칙화면1활성화
        this.rule1.SetActive(true);
        this.RuleBT1.SetActive(true);

        //이전화면 비활성화
        this.RuleBT.SetActive(false);
        this.GameStartBT.SetActive(false);
    }

    //규칙1 화면의 next 버튼
    public void Rule1BTDown()
    {
        ButtonSound.Play();//효과음

        //규칙화면2활성화
        this.rule2.SetActive(true);
        this.RuleBT2.SetActive(true);

        //이전화면 비활성화
        this.rule1.SetActive(false);
        this.RuleBT1.SetActive(false);
    }
    //규칙2 화면의 next버튼
    public void Rule2BTDown()
    {
        ButtonSound.Play();//효과음

        //규칙화면3활성화
        this.rule3.SetActive(true);
        this.RuleBT3.SetActive(true);

        //이전화면 비활성화
        this.rule2.SetActive(false);
        this.RuleBT2.SetActive(false);
    }
    //규칙3화면의 end
    public void Rule3BTDown()
    {
        ButtonSound.Play();//효과음

        //메인화면 활성화
        this.RuleBT.SetActive(true);
        this.GameStartBT.SetActive(true);

        //이전화면 비활성화
        this.rule3.SetActive(false);
        this.RuleBT3.SetActive(false);
    }
    
}
