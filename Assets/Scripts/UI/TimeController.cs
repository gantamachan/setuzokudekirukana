using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    // �o�ߎ��Ԃ�float�ŕێ�����i��F1.5�b�ȂǏ�����������j
    //float�́u�����_����̐��i�����j�v��\���f�[�^�^�B�@0f�̂悤�ɐ����{f�̐��������
    private float elapsedTime = 0f;

    // �^�C�}�[�������Ă��邩�𔻒�itrue�Ői�s���Afalse�Œ�~�j
    //bool��true��false��������Ȃ��f�[�^�^�@����̃I���I�t����̗p�r�ɂ͂҂�����
    private bool isRunning = true;

    void Update()
    {
        // �^�C�}�[���~�܂��Ă���Ȃ牽�����Ȃ�
        //! �́unot�i?�ł͂Ȃ��j�v�Ƃ����Ӗ��B�@�@=!isRunning �́uisRunning��false��������v�Ƃ����Ӗ�
        if (!isRunning) return;

        // �O�̃t���[������̎��Ԃ����Z
        //Time.deltaTime �́u�O�̃t���[������̌o�ߎ��ԁi�b�j�v��\���֗��Ȃ�BUnity���̋@�\
        elapsedTime += Time.deltaTime;

        // �o�ߎ��Ԃ��u�����ԁ������b�v�ɕϊ�
        // Mathf�FUnity���p�ӂ����u���w�֐��v�̏W�܂�
        //FloorToInt() �����_�ȉ���؂�̂ĂāA�����ɕϊ�����֐�
        int hours = Mathf.FloorToInt(elapsedTime / 3600f);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // �\�����X�V
        timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
    }

    // �^�C�}�[���~�߂�p�̊֐��i�O������Ăׂ�j
    public void StopTimer()
    {
        isRunning = false;
    }

    // �^�C�}�[�����Z�b�g���čăX�^�[�g����֐�
    public void ResetTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
    }
}