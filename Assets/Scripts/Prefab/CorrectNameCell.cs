using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CorrectNameCell : MonoBehaviour
{
    [SerializeField] private GameObject backObject;
    [SerializeField] private GameObject frontBackground;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image frontImage;

    private GodFieldData currentData;

    //�u���̃J�[�h�̖��O�͉����H�v���O���iNameChecker�Ȃǁj���猩����悤�ɂ��邽�߂́g�����h
    public string CellName => currentData.Name;

    // �֐��@������data
    public void SetData(GodFieldData data)
    {
        //�����̃f�[�^��n��
        currentData = data;

        // ������ԁF���ʂ����\���A����ȊO�͔�\��
        backObject.SetActive(true);
        frontBackground.SetActive(false);
        nameText.gameObject.SetActive(false);
        frontImage.gameObject.SetActive(false);
    }

    public void Reveal()
    {
        // ���ʂ��B��
        backObject.SetActive(false);

        // �\�̗v�f��\��
        frontBackground.SetActive(true);
        nameText.text = currentData.Name;
        nameText.gameObject.SetActive(true);
        frontImage.sprite = currentData.Sprite;
        frontImage.gameObject.SetActive(true);
    }

}
