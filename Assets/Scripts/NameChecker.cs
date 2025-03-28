using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMesh���g���Ƃ��͂Ƃ肠�����������


public class NameChecker : MonoBehaviour
{
    //Inspector��Ō�����悤�ɂ�������@�O����A�N�Z�X�ł��Ȃ���@TMPro���p�ӂ��Ă�ϐ��̌^�@�ϐ��i������₷�����R�ɒ�`�j
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text answeredText;

    //HashSet(�d�����Ȃ����X�g���쐬�j�@������^����@�ϐ��i���R�j�@���@�V���������Hashset�����Ƃ�������
    private HashSet<string> answeredNames = new HashSet<string>();

    //List(���Ԃɕ\���ł��郊�X�g���쐬�j�@������^����@�ϐ��i���R�j�@���@�V�������X�g�����@�s�J�`���E�ȂǑS�Ă̖��O���ԗ�����Ă���
    private List<string> correctNames = new List<string>
    {
        "�s�J�`���E", "�t�V�M�_�l", "�C�[�u�C"
    };





    // �߂�l�̂Ȃ��֐��@���R�Ɋ֐������`�@Unity���̑���Ń{�^������������Ăяo�����悤�ɂ���B
    public void CheckInputName()
    {
        //�ϐ��̌^�i�����񂾂�I���ĈӖ��j�@�ϐ��i���R�j�ϐ��B���Ő錾�����ϐ��ƈ�v������@������Ƃ��ēǂދ@�\�@�󔒂������֗��@�\
        string input = inputField.text.Trim();
        
        //�����@string�^�̊֐��ł���input������ۂ������Ȃ���΁@�����
        if (string.IsNullOrEmpty(input))
        {
            return;
        }

        //�����@input�̒��g�����X�g�Ɂ@���݂�����@�����`
        if (answeredNames.Contains(input))
        {
            return;
        }

        //�����@input�̒��g�����O�ɗp�ӂ������X�g�ɑ��݂�����@
        if(correctNames.Contains(input))
        {
            // Hashset�ɂ��̖��O��ǉ�
            answeredNames.Add(input);
            // unity���Text�ɖ��O��ǉ��ŕ\�����A���s����
            answeredText.text += input + "\n";
        }




    }



}