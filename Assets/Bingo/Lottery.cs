using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lottery : MonoBehaviour
{
    System.Random random;//ランダムな数取得するため

    [SerializeField]
    private Bingo bingo = null;

    private int PanelInstanceIndexX = 4;
    private int PanelInstanceIndexY = 4;

    List<int> intList = new List<int>();//抽選に使うリスト

    void Start()
    {
        for (int i = 1; i <= 75; i++)
        {
            intList.Add(i);
        }

        random = bingo.random;
    }
    /// <summary>
    /// buttonを押すと呼ばれて
    /// ランダムな数を抽選して
    /// もしパネルにあれば色を変える
    /// </summary>
    public void Lot()
    {

        int index = random.Next(0, intList.Count);
        int number = intList[index];



        for (int i = 0; i <= PanelInstanceIndexX; i++)
        {
            for (int k = 0; k <= PanelInstanceIndexY; k++)
            {
                Panel panel;
                panel = bingo.panels[i, k].GetComponent<Panel>();

                if (panel.a == number)
                {
                    panel.image.color = Color.red;
                    panel.isTrue = true;
                    bingo.BingoCheck(i, k);
                }

            }
        }
        intList.RemoveAt(index);
    }
}
