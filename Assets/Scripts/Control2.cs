using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control2 : MonoBehaviour
{
    //游戏内物体
    private float timeOne=0;
    private float timeInterval;
    public Transform[] leads;
    public Transform boll;
   
    private Transform demo;
    private bool judgeKey=false;
    private bool yes = true;
    //UI
    public Text gameText; //得分
    public Text gamefalse; //失误提示
    public Text overTime;   //结束时间
    public GameObject imageone;
    public Text textone;
    //nub
    private int getTrue=-1;  //得分
    private int nubInt;

    private float nub_two;

    // Start is called before the first frame update
    void Start()
    {
        
        demo = Instantiate(leads[nubInt], leads[nubInt].position, leads[nubInt].localRotation);
    }

    // Update is called once per frame
    void Update()
    {
        nub_two = 30 - Time.time;
        if (30 - Time.time > 0)
        {

            overTime.text = "时间：" + nub_two.ToString("F2");
        }
        else
        {
            if (yes)
            {
                imageone.SetActive(true);
                
                textone.text = "游戏结束，得分：" + getTrue.ToString();
                yes = false;
            }

        }


        if (Time.time > timeOne)
        {
            timeInterval = 3f;
            timeOne += timeInterval;
            CreatCube();
            Invoke("ChangeText",0.5f);
            
        }

        if (nubInt == 0 && judgeKey)
        {
            
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                judgeKey = false;
                boll.position =  new Vector3(0, 1, 0);
                timeOne = Time.time - 1f;
            }
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.W))
            {
                timeOne = Time.time - 1f;
            }
        }
        if (nubInt == 1 && judgeKey)
        {


            if (Input.GetKeyDown(KeyCode.D))
            {
                judgeKey = false;
                boll.position =  new Vector3(1, 0, 0);
                timeOne = Time.time - 1f;
            }
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.D))
            {
                timeOne = Time.time - 1f;
            }
        }
        if (nubInt == 2 && judgeKey)
        {


            if (Input.GetKeyDown(KeyCode.S))
            {
                judgeKey = false;
                boll.position = new Vector3(0,-1, 0);
                timeOne = Time.time - 1f;
            }
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.S))
            {
                timeOne = Time.time - 1f;
            }
        }
        if (nubInt == 3 && judgeKey)
        {


            if (Input.GetKeyDown(KeyCode.A))
            {
                judgeKey = false;
                boll.position =new Vector3(-1, 0, 0);
                timeOne = Time.time - 1f;
            }
            if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.A))
            {
                timeOne = Time.time - 1f;
            }
        }
        demo.position = Vector3.MoveTowards(demo.position, new Vector3(demo.position.x, 3, 0), 0.02f);
    }
    void ChangeText()
    {
        boll.position = new Vector3(0, 0, 0);
        gamefalse.text = "";
    }
    private void CreatCube()
    {
        Destroy(demo.gameObject);
        nubInt = Random.Range(0, 4);
        demo= Instantiate(leads[nubInt], leads[nubInt].position, leads[nubInt].localRotation);
        if(judgeKey)
        {
            gamefalse.text = "你败了";
        }
        if(judgeKey==false)
        {
            getTrue++;
            gameText.text = "得分：" + getTrue.ToString();

        }
        judgeKey = true;
        
    }
}
