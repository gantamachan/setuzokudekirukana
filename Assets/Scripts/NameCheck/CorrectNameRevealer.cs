using UnityEngine;
using System.Collections.Generic;

//正解したときにカードをめくる
public class CorrectNameRevealer
{
    private CorrectNameGridSpawner spawner;

    //今ハイライトされているセルを定義
    private CorrectNameCell currentHighlightedCell = null;

    public CorrectNameRevealer(CorrectNameGridSpawner spawner)
    {
        this.spawner = spawner;
        gridSpawner = spawner;
    }

    //正解したらめくる処理？
    public void RevealCell(string name)
    {
        //spawner.GetAllCells() で取得したすべての CorrectNameCell に対して、1つずつ順番に処理を行う
        foreach (CorrectNameCell cell in spawner.GetAllCells())
        {
            //CellName(カードの名前）とname（入力された名前）が一致したら
            if (cell.CellName == name)
            {

                // 前回の赤枠をOFF　（の中はnullなら呼ばないようにするよという処理）
                if (currentHighlightedCell != null)
                {
                    currentHighlightedCell.SetHighlight(false);
                }



                cell.Reveal();

                cell.SetHighlight(true);


                // ③ 現在のセルをハイライトに記録
                currentHighlightedCell = cell;
                //ループおわり
                return;
            }

           
        }
    }

    //他のスクリプトとつなげる　　スクリプト名　好きな名前の変数

    private CorrectNameGridSpawner gridSpawner;

   

    public List<CorrectNameCell> GetAllCells()
    {
        return gridSpawner.GetAllCells();
    }
}