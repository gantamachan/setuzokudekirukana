using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectNameGridSpawner : MonoBehaviour
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject  cellPrefab;

    //CollectNameCell�^���uCorrectNameCell�Ƃ������[���ō��ꂽ���m�v���w���B�@���J�[�h�v���n�u�����̂���
    //��̃��X�g�ł���allCells��V�����쐬
    //��@allCells[0]�͗��ւ̃J�[�h�i�����j���ۑ�����Ă���
    private List<CorrectNameCell> allCells = new List<CorrectNameCell>();


 


    void Start()
    {
        //List��
        List<GodFieldData> dataList = GodFieldDataLoader.Load();

        //foreach�̓��X�g������S�����鏈���̂���
        //for (int i = 0; i < dataList.Count; i++) �ƈӖ��͈ꏏ�����ǁA�������̕���������₷�����
        //���X�g�̑S���̗v�f�����邼�I�Ƃ��̎��Ɏg���Ƃ悢

        foreach (GodFieldData data in dataList)
        {
            // Instantiate�́u�v���n�u�iPrefab�j�v���� �R�s�[������ăQ�[���ɏo�����߂̊֐��I
            var cellObject = Instantiate(cellPrefab);

            // �A cell��gridParent�̎q�ɓ���Ăˁ�UI��Grid�̉��ɓ���Ăˁ@�v���n�u��ۑ������Ƃ��̈ʒu�֌W�͈ێ����Ȃ��ł�
            cellObject.transform.SetParent(gridParent, false);

            //CollectNameCell�^���uCorrectNameCell�Ƃ������[���ō��ꂽ���m�v���w���B�@���J�[�h�v���n�u�����̂���
            //GetComponent�@�v���n�u�̒�����A<>���̃X�N���v�g��T���Ď��o���֐�
            CorrectNameCell cell = cellObject.GetComponent<CorrectNameCell>();

            cell.SetData(data);

            allCells.Add(cell);
        }


        

    }


    //���J�́@�߂�l��CorrectNameCell�^�̃��X�g�@�ł���֐��@�i�����͖����j
    public List<CorrectNameCell> GetAllCells()
    {
        return allCells;
    }
}
