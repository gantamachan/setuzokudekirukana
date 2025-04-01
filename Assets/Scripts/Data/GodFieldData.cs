using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class�͐݌v�}�݂����Ȃ���
public class GodFieldData 
{


    public int Id { get; private set; } // �}�Ӕԍ�
    public string Name { get; private set; } // ���O
    public string ImageName { get; private set; } // �摜�t�@�C����
    public string Type { get; private set; } // �_��̃^�C�v�i����Ȃǁj
    public Sprite Sprite { get; private set; } // �ǂݍ��񂾉摜�i���Ƃŕ\���p�j


    //�R���X�g���N�^�Ƃ����֐��I�I�I
    //�܂�GodFieldData���g���Ď��ۂɃf�[�^�����ꂽ�Ƃ��ɓ���
    //�@GFData�Ƃ����ϐ��̌^��Int�A�����^�A�����^�A�����^�@����I���Č����̂��`���Ă���
    //id,name,imagename,type�͂��ׂĈ����I�I�I�I�厖
    public GodFieldData(int id,string name,string imagename,string type)
    {

        //������ŕ��K

        Id = id;
        Name = name;
        ImageName = imagename;
        Type = type;

        SpriteLoader();

    }

    private void SpriteLoader()
    {

        //Resources/Sprites/ �t�H���_�̒��ɂ��� ImageName.png ��T���ēǂݍ���ŁASprite�ɃZ�b�g���ĂˁI
        Sprite = Resources.Load<Sprite>($"Sprites/{ImageName}");

        //�摜�Ȃ����̃G���[�m�F�p
        if (Sprite == null)
        {
            Debug.LogWarning($"�摜��������܂���:{Name}: {ImageName}");
        }
    }
   
}
