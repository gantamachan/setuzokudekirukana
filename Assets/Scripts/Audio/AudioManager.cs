using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour




{


    private const string VolumeKey = "AudioVolume";
    private const string MuteKey = "AudioMuted";




    //�C���X�^���X���H�@�@AudioManager.Instance.PlaySE("start") �݂����ɁA�ǂ�����ł��g����I
    public static AudioManager Instance { get; private set; }

    //���ʉ��̑傫��
    private AudioSource seSource;
    private Dictionary<string, AudioClip> seClips = new Dictionary<string, AudioClip>();

    //���ʉ��̑傫����ݒ肷�邽�߂̗v�f
    private float seVolume = 1f;
    private bool isMuted = false;

    //Awake��Unity���I�u�W�F�N�g���V�[���ɕ\�����钼�O�Ɏ����ŌĂяo���֐�
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // �� ��������Ȃ���Δj���I
            return;
        }

        seSource = gameObject.AddComponent<AudioSource>();

        // ���ʂƃ~���[�g��Ԃ�ۑ����畜��
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        int savedMute = PlayerPrefs.GetInt(MuteKey, 0);

        seVolume = Mathf.Clamp01(savedVolume);
        isMuted = savedMute == 1;

        //�����Ƀt�@�C����
        LoadSE("start");
        LoadSE("damage");
        LoadSE("cardopen"); 
        LoadSE("end");
    }

    public void SaveState()
    {
        PlayerPrefs.SetFloat(VolumeKey, seVolume);
        PlayerPrefs.SetInt(MuteKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();
    }

    //���ʉ���ǂݍ��ށH
    private void LoadSE(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>($"Audio/{name}");
        if (clip != null)
        {
            seClips[name] = clip;
        }
        else
        {
            Debug.LogWarning($"Audio/{name} ��������܂���");
        }
    }

    //����炷
    public void PlaySE(string name)
    {
        if (isMuted || !seClips.ContainsKey(name))
        {
            Debug.Log($"[PlaySE] skipped: {name}, isMuted = {isMuted}");
            return;
        }

        Debug.Log($"[PlaySE] playing: {name}, volume = {seVolume}");
        seSource.PlayOneShot(seClips[name], seVolume);
    }


    public void ToggleMute()
    {
        isMuted = !isMuted;
        Debug.Log($"[ToggleMute] isMuted = {isMuted}, object = {gameObject.name}");
        SaveState();
    }

    public void SetVolume(float volume)
    {
        //Mathf.Clamp01(volume);�@�O�`�P�ɐ���
        seVolume = Mathf.Clamp01(volume);

        SaveState();

    }

    public float GetVolume()
    {
        return seVolume;
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}
