using UnityEngine;
using System.Collections.Generic;

//���������Ƃ��ɃJ�[�h���߂���
public class CorrectNameRevealer
{
    private CorrectNameGridSpawner spawner;
    private CorrectNameCell currentHighlightedCell = null;

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



    public void ClearHighlight()
    {
        if (currentHighlightedCell != null)
        {
            currentHighlightedCell.SetHighlight(false);
            currentHighlightedCell = null;
        }
    }

    //���̃X�N���v�g�ƂȂ���@�@�X�N���v�g���@�D���Ȗ��O�̕ϐ�

    private CorrectNameGridSpawner gridSpawner;

   

    public List<CorrectNameCell> GetAllCells()
    {
        return gridSpawner.GetAllCells();
    }
}