using UnityEngine;
using System.Collections.Generic;

//���������Ƃ��ɃJ�[�h���߂���
public class CorrectNameRevealer
{
    private CorrectNameGridSpawner spawner;

    //���n�C���C�g����Ă���Z�����`
    private CorrectNameCell currentHighlightedCell = null;

    public CorrectNameRevealer(CorrectNameGridSpawner spawner)
    {
        this.spawner = spawner;
        gridSpawner = spawner;
    }

    //����������߂��鏈���H
    public void RevealCell(string name)
    {
        //spawner.GetAllCells() �Ŏ擾�������ׂĂ� CorrectNameCell �ɑ΂��āA1�����Ԃɏ������s��
        foreach (CorrectNameCell cell in spawner.GetAllCells())
        {
            //CellName(�J�[�h�̖��O�j��name�i���͂��ꂽ���O�j����v������
            if (cell.CellName == name)
            {

                // �O��̐Ԙg��OFF�@�i�̒���null�Ȃ�Ă΂Ȃ��悤�ɂ����Ƃ��������j
                if (currentHighlightedCell != null)
                {
                    currentHighlightedCell.SetHighlight(false);
                }



                cell.Reveal();

                cell.SetHighlight(true);


                // �B ���݂̃Z�����n�C���C�g�ɋL�^
                currentHighlightedCell = cell;
                //���[�v�����
                return;
            }

           
        }
    }

    //���̃X�N���v�g�ƂȂ���@�@�X�N���v�g���@�D���Ȗ��O�̕ϐ�

    private CorrectNameGridSpawner gridSpawner;

   

    public List<CorrectNameCell> GetAllCells()
    {
        return gridSpawner.GetAllCells();
    }
}