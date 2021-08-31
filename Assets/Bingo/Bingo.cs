using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Bingo : MonoBehaviour
{
    private const int constX = 5, constY = 5;//五×五で作るため

    [SerializeField]
    public GameObject panel;//panelのゲームオブジェクト


    private int[,] panelIndex = new int[constX, constY];//panelの数

    [SerializeField]
    private GridLayoutGroup layoutGroup = null;

    public System.Random random = new System.Random();//ランダムな数を取得する

    private int number;//panelの数字

    public GameObject[,] panels = new GameObject[constX, constY];//作ったpanelを入れておくための配列

    private int PanelInstanceIndexX = 0;
    private int PanelInstanceIndexY = 0;

    private Panel checkPanel;

    bool bingo = false;

    [SerializeField]
    private GameObject bingoText = null;

    int i = 0;
    int y = 4;

    public List<int> intList = new List<int>();

    void Start()
    {
        for (int i = 1; i <= 75; i++)
        {
            intList.Add(i);
        }

        for (int i = 0; i < panelIndex.GetLength(0); i++)
        {
            for (int k = 0; k < panelIndex.GetLength(1); k++)
            {
                PanelInstance(i, k);
            }
        }

        bingoText.SetActive(false);

    }
    void Update()
    {
        if (bingo)
        {
            Debug.Log("bingo");
            bingoText.SetActive(true) ;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Panel panel;
            panel = panels[i, y].GetComponent<Panel>();
            panel.isTrue = true;
            BingoCheck(i, y);
            i++;
            y--;
        }
        for (int i = 0; i < panelIndex.GetLength(0); i++)
        {
            for (int k = 0; k < panelIndex.GetLength(1); k++)
            {
               
                Panel panel = panels[i, k].GetComponent<Panel>();
                if (panel.isTrue)
                {
                    BingoCheck(i, k);
                }
            }
        }
       
    }
    /// <summary>
    /// パネルを生成し数を設定する
    /// </summary>
    /// <param name="x">パネルのX軸</param>
    /// <param name="y">パネルのY軸</param>
    void PanelInstance(int x, int y)
    {
        panels[PanelInstanceIndexX, PanelInstanceIndexY] = Instantiate(panel);
        panels[PanelInstanceIndexX, PanelInstanceIndexY].transform.parent = layoutGroup.transform;
        if (x == 2 && y == 2)
        {
            number = 0;
            panels[PanelInstanceIndexX, PanelInstanceIndexY].GetComponent<Panel>().text.text = "Free";
            panels[PanelInstanceIndexX, PanelInstanceIndexY].GetComponent<Panel>().isTrue = true;
        }
        else
        {
            int index = random.Next(0, intList.Count);
            int number = intList[index];
            panels[PanelInstanceIndexX, PanelInstanceIndexY].GetComponent<Panel>().a = number;
            intList.RemoveAt(index);
        }




        if (PanelInstanceIndexY == 4)
        {
            PanelInstanceIndexY = 0;
            PanelInstanceIndexX++;
        }
        else
        {
            PanelInstanceIndexY++;
        }

    }
    /// <summary>
    /// 呼ばれたXとYの
    /// 縦横斜め8方向
    /// 調べてビンゴが成立
    /// してるか調べる
    /// </summary>
    /// <param name="x">パネルのX軸</param>
    /// <param name="y">パネルのY軸</param>
    public void BingoCheck(int x, int y)
    {
        int check = 0;
        int xx = x;
        int yy = y;
        while (xx <= 4)
        {
            checkPanel = panels[xx, yy].GetComponent<Panel>();
            if (checkPanel.isTrue)
            {
                check++;
            }
            xx++;
        }
        if (check == 6)
        {
            bingo = true;
            return;
        }
        else
        {

            xx = x;
            yy = y;
        }
        while (xx > -1)
        {
            checkPanel = panels[xx, yy].GetComponent<Panel>();
            if (checkPanel.isTrue)
            {
                check++;
            }
            xx--;
        }
        if (check == 6)
        {
            bingo = true;
            return;
        }
        else
        {
            check = 0;
            xx = x;
            yy = y;
        }

        while (yy <= 4)
        {
            checkPanel = panels[xx, yy].GetComponent<Panel>();
            if (checkPanel.isTrue)
            {
                check++;
            }
            yy++;
        }
        if (check == 6)
        {
            bingo = true;
            return;
        }
        else
        {

            xx = x;
            yy = y;
        }

        while (yy > -1)
        {
            checkPanel = panels[xx, yy].GetComponent<Panel>();
            if (checkPanel.isTrue)
            {
                check++;
            }
            yy--;
        }
        if (check == 6)
        {
            bingo = true;
            return;
        }
        else
        {
            check = 0;
            xx = x;
            yy = y;
        }

        while (xx <= 4 && yy <= 4)
        {
            checkPanel = panels[xx, yy].GetComponent<Panel>();
            if (checkPanel.isTrue)
            {
                check++;
            }
            xx++;
            yy++;
        }
        if (check == 6)
        {
            bingo = true;
            return;
        }
        else
        {

            xx = x;
            yy = y;
        }
        while (xx > -1 && yy > -1)
        {
            checkPanel = panels[xx, yy].GetComponent<Panel>();
            if (checkPanel.isTrue)
            {
                check++;
            }
            xx--;
            yy--;
        }
        if (check == 6)
        {
            bingo = true;
            return;
        }
        else
        {
            check = 0;
            xx = x;
            yy = y;
        }

        while (xx <= 4 && yy > -1) 
        {
            checkPanel = panels[xx, yy].GetComponent<Panel>();
            if (checkPanel.isTrue)
            {
                check++;
            }
            xx++;
            yy--;
        }
        if (check == 6)
        {
            bingo = true;
            return;
        }
        else
        {

            xx = x;
            yy = y;
        } 
        while (xx > -1 && yy <= 4)
        {
            checkPanel = panels[xx, yy].GetComponent<Panel>();
            if (checkPanel.isTrue)
            {
                check++;
            }
            xx--;
            yy++;
        }
        if (check == 6)
        {
            bingo = true;
            return;
        }


    }

}
