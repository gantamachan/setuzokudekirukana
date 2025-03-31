using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectNameGridSpawner : MonoBehaviour
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject  cellPrefab;
    
    void Start()
    {
        //List��
        List<GodFieldData> dataList = GodFieldDataLoader.Load();

        //foreach�̓��X�g������S�����鏈���̂���
        //for (int i = 0; i < dataList.Count; i++) �ƈӖ��͈ꏏ�����ǁA�������̕���������₷�����
        //���X�g�̑S���̗v�f�����邼�I�Ƃ��̎��Ɏg���Ƃ悢

        foreach (GodFieldData data in dataList)
        {
            // �@ �v���n�u�𕡐����A�����ϐ��ɓ����
            var cell = Instantiate(cellPrefab);

            // �A cell��gridParent�̎q�ɓ���Ăˁ�UI��Grid�̉��ɓ���Ăˁ@�v���n�u��ۑ������Ƃ��̈ʒu�֌W�͈ێ����Ȃ��ł�
            cell.transform.SetParent(gridParent, false);

            
        }
    }

}
