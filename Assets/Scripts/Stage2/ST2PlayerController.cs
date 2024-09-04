using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ST2PlayerController : MonoBehaviour
{
    public float x;
    public float y;

    //움직일수 있는 방향 제한
    public bool left, right, up, down;

    public AudioSource turnSound; //방향전환 효과음

    public GameObject director;
    // Start is called before the first frame update
    void Start()
    {
        this.x = 0.03f;
        this.y = 0;

        left = true;
        right = true;
        up = true;
        down = true;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(x, y, 0);
        GetComponent<Rigidbody2D>().velocity = move*150;
        
        //방향키로 ㅂㅏㅇ향전환
        if (Input.GetKeyDown(KeyCode.LeftArrow) && left)
        {
            turnSound.Play();
            this.x = -0.03f;
            this.y = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && right)
        {
            turnSound.Play();
            this.x = 0.03f;
            this.y = 0f;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) && up)
        {
            turnSound.Play();
            this.x = 0f;
            this.y = 0.03f;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && down)
        {
            turnSound.Play();
            this.x = 0f;
            this.y = -0.03f;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "stage2Path")
        {
            director.GetComponent<Stage2Director>().DecreaseHP();
            

        }
        if(collision.gameObject.name == "Fin")
        {
            director.GetComponent<Stage2Director>().GameClear();
        }
    }
}
