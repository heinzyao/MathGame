using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{

    public int isCorrect; //建立變數 -> 標記該選項是否是正確的答案：
    public GameObject correctAnswer;


    private void OnMouseDown() //用滑鼠點擊選項時
    {
        if (isCorrect == 1) //在分流裡使用 GetComponent 取得 TextMesh 並且更換文字的顏色
        {
            GetComponent<TextMesh>().color = Color.green; //isCorrect 為 1 時，顯示為綠色
        }
        else
        {
            GetComponent<TextMesh>().color = Color.red;
            correctAnswer.GetComponent<TextMesh>().color = Color.Lerp(Color.red, Color.yellow, 0.5f);
        }
    }

    private void OnMouseUp()
    {
        if (isCorrect == 1) //在分流裡使用 GetComponent 取得 TextMesh 並且更換文字的顏色
        {
            GetComponent<TextMesh>().color = Color.green;
            //isCorrect 為 1 時，顯示為綠色
        }
        else
        {
            GetComponent<TextMesh>().color = Color.white;
        }
    
    }
}