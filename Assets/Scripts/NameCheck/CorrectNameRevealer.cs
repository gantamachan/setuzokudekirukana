using UnityEngine;

//���������Ƃ��ɃJ�[�h���߂���
public class CorrectNameRevealer
{
    private CorrectNameGridSpawner spawner;

    public CorrectNameRevealer(CorrectNameGridSpawner spawner)
    {
        this.spawner = spawner;
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
}