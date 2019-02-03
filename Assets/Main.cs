using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    // 式入力テキスト
    public Text Formula;
    // 結果表示テキスト
    public Text Answer;
    // 各数字ボタン
    public Button[] bNumber;
    // 割るボタン
    public Button bDivide;
    // 計算ボタン
    public Button bEqual;
    // クリアボタン
    public Button bClear;
    //たすボタン
    public Button bAdd;
    //引くボタン
    public Button bSub;
    //×ボタン
    public Button bMul;
    //小数点ボタン
    public Button bDec;

    //×
    int kakeru;
    //わる
    int waru;
    //たす
    int tasu;
    //引く
    int hiku;
    //パーセント
    int percent;

    string[] inputString ;

    //答え
    int quotient;

    int leftNumber;
    int rightNumber;


    // Use this for initialization
    void Start()
    {
        //初期化
        Formula.text = "";
        Answer.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    // 数字ボタン押下
    public void InputNumber(Text number)
    {
        // 押下したボタンの数字を式欄に追記する
        Formula.text += number.text;
    }

    // 割るボタン押下
    public void InputDivide(Text divideButton)
    {
        // 数字が未入力か、すでに÷があればスルー
        if (Formula.text == "" || Formula.text.Contains("÷"))
        {
            return;
        }

        // ÷を式欄に追記する
        Formula.text += divideButton.text;

        waru = 1;
    }

    //たすボタン押した
    public void InputAdd(Text addButton)
    {
        //数字が未入力か、すでに＋があればスルー
        if (Formula.text == "" || Formula.text.Contains("+"))
        {
            return;
        }

        // +を式欄に追記する
        Formula.text += addButton.text;

        tasu = 1;
    }
    //引くボタン押した
    public void InputSub(Text subButton)
    {
        //数字が未入力か、すでに＋があればスルー
        if (Formula.text == "" || Formula.text.Contains("-"))
        {
            return;
        }

        // -を式欄に追記する
        Formula.text += subButton.text;

        hiku = 1;
    }
    //×ボタン押した
    public void InputMul(Text mulButton)
    {
        //数字が未入力か、すでに＋があればスルー
        if (Formula.text == "" || Formula.text.Contains("×"))
        {
            return;
        }

        // +を式欄に追記する
        Formula.text += mulButton.text;

        kakeru = 1;
    }
    //%ボタン押した
    public void InputPercent(Text percentButton)
    {
        //数字が未入力か、すでに＋があればスルー
        if (Formula.text == "" || Formula.text.Contains("%"))
        {
            return;
        }

        // +を式欄に追記する
        Formula.text += percentButton.text;

        percent = 1;
    }
    // 計算ボタン押下
    public void InputEqual(Text equal)
    {

        // ÷がないか、文字列の最後が÷,+,×,-ならスルー★
        if (!Formula.text.Contains("÷") && !Formula.text.Contains("×") && !Formula.text.Contains("+") && !Formula.text.Contains("-") && !Formula.text.Contains("%"))
        {
            return;
        }

        // 入力した式を割る数と割られる数に分ける

        if(tasu == 1)
        {
             inputString = Formula.text.Split('+');
            // たす
            quotient = leftNumber + rightNumber;
        }
        if (hiku == 1)
        {
            inputString = Formula.text.Split('-'); ;
            // 引く
            quotient = leftNumber - rightNumber;
        }
        if (kakeru == 1)
        {
            inputString = Formula.text.Split('×');
            // ×
            quotient = leftNumber * rightNumber;
        }
        if (waru == 1)
        {
            inputString = Formula.text.Split('+');
            // 商
             quotient = leftNumber / rightNumber;
        }
        if (percent == 1)
        {
            inputString = Formula.text.Split('%');
            // パーセント
             quotient = leftNumber * (1-rightNumber/100);
        }

         leftNumber = int.Parse(inputString[0]);
         rightNumber = int.Parse(inputString[1]);

        // 割られる数がゼロならスルー
        if (rightNumber == 0)
        {
            return;
        }


       

        // 計算結果を表示
        Answer.text = quotient.ToString();

    }

    // クリアボタン押下
    public void InputClear(Text equal)
    {
        //初期化
        Formula.text = "";
        Answer.text = "";
    }
}
