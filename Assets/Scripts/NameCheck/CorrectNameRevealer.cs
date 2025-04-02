using UnityEngine;
using System.Collections.Generic;

//正解したときにカードをめくる
public class CorrectNameRevealer
{
    private CorrectNameGridSpawner spawner;

    public CorrectNameRevealer(CorrectNameGridSpawner spawner)
    {
        this.spawner = spawner;
        gridSpawner = spawner;
    }

    public void RevealCell(string name)
    {
        foreach (CorrectNameCell cell in spawner.GetAllCells())
        {
            if (cell.CellName == name)
            {
                cell.Reveal();
                break;
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