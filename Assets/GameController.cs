using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public string randomOperator; 
    public int answer; 

    public GameObject question;
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;

    void Start()
    {
        GenerateQuestion();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GenerateQuestion()
    {
        int a = Random.Range(0, 100); //隨機產生題目數字1
        int b = Random.Range(0, 100); //隨機產生題目數字2

        int operatorNumber = Random.Range(0, 3);

        if (operatorNumber == 0) //分流一：operatorNumber 為 0，進行加法
        {
            randomOperator = "+";
            answer = a + b;
        }
        else if (operatorNumber == 1)//分流二：operatorNumber 為1，進行減法
        {
            randomOperator = "-";
            answer = a - b;
        }

        else //分流三：operatorNumber 不為 1 or 2，進行乘法
        {
            randomOperator = "x";
            answer = a * b;
        }

        int option = Random.Range(0, 3); //創造選項

        string questionText = a + " " + randomOperator + " " + b + " =?";
        //取得 Question 的 TextMesh，將其文字修改為問題


        if (option == 0)
        {
            option1.GetComponent<TextMesh>().text = answer.ToString(); //分流1: 產生正確答案
            option2.GetComponent<TextMesh>().text = (answer + Random.Range(-10, -1)).ToString(); //分流2: 產生錯誤答案
            option3.GetComponent<TextMesh>().text = (answer + Random.Range(1, 10)).ToString(); //分流3: 產生錯誤答案
            option1.GetComponent<Option>().isCorrect = 1;
            option2.GetComponent<Option>().isCorrect = 0;
            option3.GetComponent<Option>().isCorrect = 0;
            //在 option 分流中使用 GetComponent 取得 Option，並將正確答案設定在 isCorrect 公開變數
            //若為正確答案，則是 1，若否，則是 0

            option2.GetComponent<Option>().correctAnswer = option1;
            option3.GetComponent<Option>().correctAnswer = option1;

        }
        else if (option == 1)
        {

            option1.GetComponent<TextMesh>().text = (answer + Random.Range(-10, -1)).ToString();
            option2.GetComponent<TextMesh>().text = answer.ToString();
            option3.GetComponent<TextMesh>().text = (answer + Random.Range(1, 10)).ToString();
            option1.GetComponent<Option>().isCorrect = 0;
            option2.GetComponent<Option>().isCorrect = 1;
            option3.GetComponent<Option>().isCorrect = 0;

            option1.GetComponent<Option>().correctAnswer = option2;
            option3.GetComponent<Option>().correctAnswer = option2;
        }
        else 
        {
        
            option1.GetComponent<TextMesh>().text = (answer + Random.Range(-10, -1)).ToString();
            option2.GetComponent<TextMesh>().text = (answer + Random.Range(1, 10)).ToString();
            option3.GetComponent<TextMesh>().text = answer.ToString();
            option1.GetComponent<Option>().isCorrect = 0;
            option2.GetComponent<Option>().isCorrect = 0;
            option3.GetComponent<Option>().isCorrect = 1;

            option1.GetComponent<Option>().correctAnswer = option3;
            option2.GetComponent<Option>().correctAnswer = option3;

        }

        question.GetComponent<TextMesh>().text = questionText;
        //使用 option 進行分流後，把問題放入 Question 的 TexMesh 

    }

    private void OnMouseDown()
    {
        GetComponent<TextMesh>().color = Color.white;
        option1.GetComponent<TextMesh>().color = Color.white;
        option2.GetComponent<TextMesh>().color = Color.white;
        option3.GetComponent<TextMesh>().color = Color.white;
        GenerateQuestion();
    }
    private void OnMouseUp()
    {
        GetComponent<TextMesh>().color = Color.yellow;
    }
} 