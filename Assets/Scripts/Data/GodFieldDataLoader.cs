using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Static�����Ă���ƃC���X�^���X�������Ɏg����
//�������肢����New���Ȃ��Ă��g����悤�ɂȂ�
//1�񂾂������g��Ȃ����̂Ɏg���Ƃ悢�Ƃ���Ă����肷��
public static class GodFieldDataLoader 
{
   

    public static List<GodFieldData>Load()
    {
        //���\�[�X�̒��̃e�L�X�g�ł���CSV�t�@�C����ǂݍ��ގ����i���̒i�K�ł͌����e�L�X�g�j
        TextAsset csvFile = Resources.Load<TextAsset>("CSV/GodField_data");

        //�G���[�m�F�p
        if (csvFile == null)
        {
            Debug.LogError("CSV�t�@�C����������܂���: GodField_data.csv");
            return new List<GodFieldData>();
        }

        //List��V�����쐬�I�@List�͓��I�z��dateList[0] �݂����ȕ\���Ŋe��ɃA�N�Z�X�\
        var dataList = new List<GodFieldData>();



        //������^�̔z��ł���lines�ɁA��s���Ƃɕ������ꂽcsv�̃e�L�X�g������@
        //��@lines[0]��"ID,Name,Image,Type"�@lines[1]="1,����,ryougae,Torihiki" �@�@���Ȃ݂Ɂ@"���̓_�X"�A�厖
        string[] lines = csvFile.text.Split('\n');

        
        //lines[0]�͐������Ȃ̂Ŗ����I�@
        //i���s����菬�����Ԃ͌J��Ԃ�������Ƀt�@�C���̍Ō�܂œǂ�ł����
        //��񃋁[�v�����玟�̍s�֍s���ii�Ɂ{�P����j

        for (int i = 1; i < lines.Length; i++)
        {
            //�Ԉ���ē��ꂿ������󔒂���菜�����������󗓂Ȃ��菜��
            //countinue�@�@���̃��[�v���I�������̃��[�v���J�n����I
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            //������^�̔z��values�ɁA�J���}�ŋ�؂����e�L�X�g������
            //��@i=1�̂Ƃ� values[0]��"1"
            //�@�@�@�@�@�@  valus[1]��"����" �ɂȂ�
            //�f�[�^���S�ȉ��̍s�@�܂���̓~�X���Ă�̂́@��΂�
            string[] values = line.Split(',');
            if (values.Length < 4) continue;

            //�z��𕪉����Ă���
            int id = int.Parse(values[0]); // ������ �� �����^�ɂ��Ă���邠�肪�����֐�
            string name = values[1];
            string imageName = values[2];
            string type = values[3];
            //�����̂܂܂��Ɗe�f�[�^���o���o���ŕR�Â��Ȃ��Ȃ�

            //�Ȃ̂ŁAGodFieldData�^�̕ϐ��ɓ����
            //��@GodFieldData(1, "����", "ryougae", "Torihiki")

            // ���@������new���ꂽ�I�@�܂�GodFieldData.cs �̃R���X�g���N�^�֐����N������I
            //data��GodFieldData�^�̕ϐ���Int�A�����A�����A�����������ˁI
            //data�̓C���X�^���X�i���̂ł���j��GodFieldData�Ƃ����N���X��
            GodFieldData data = new GodFieldData(id, name, imageName, type);



            //i=1�̂Ƃ��̃��X�g�́�
            //dataList[0] = GodFieldData { Id = 1, Name = "����", ImageName = "ryougae", Type = "Torihiki" }
            dataList.Add(data);


        }

        //for�̒��̏������I��遁�S�Ẵf�[�^�����X�g�Ɋi�[����܂���
        //OrderBy ���������ɕ��ёւ����Ă���邠�肪�����֐�
        //���Ȃ݂ɍ���̓f�[�^�����ς݂����疳���ł������I������ƊԈႦ�Ă����Ɏ��̂�Ȃ�
        // ToList�@���X�g�ɕϊ����Ă���邠�肪�����֐�
        
        return dataList.OrderBy(d => d.Id).ToList();
    }
}
