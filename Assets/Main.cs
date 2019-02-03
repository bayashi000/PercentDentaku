﻿using System.Collections;
using System.Collections.Generic;
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
    }

    // 計算ボタン押下
    public void InputEqual(Text equal)
    {

        // ÷がないか、文字列の最後が÷ならスルー★
        if (!Formula.text.Contains("÷"))
        {
            return;
        }

        // 入力した式を割る数と割られる数に分ける
        string[] inputString = Formula.text.Split('÷');
        int leftNumber = int.Parse(inputString[0]);
        int rightNumber = int.Parse(inputString[1]);

        // 割られる数がゼロならスルー
        if (rightNumber == 0)
        {
            return;
        }

        // 商
        int quotient = leftNumber / rightNumber;
        // 余り
        int remainder = leftNumber % rightNumber;

        // 計算結果を表示
        Answer.text = quotient.ToString() + "…" + remainder.ToString();

    }

    // クリアボタン押下
    public void InputClear(Text equal)
    {
        //初期化
        Formula.text = "";
        Answer.text = "";
    }
}
