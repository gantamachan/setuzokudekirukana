using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour




{


    private const string VolumeKey = "AudioVolume";
    private const string MuteKey = "AudioMuted";




    //インスタンス化？　　AudioManager.Instance.PlaySE("start") みたいに、どこからでも使える！
    public static AudioManager Instance { get; private set; }

    //効果音の大きさ
    private AudioSource seSource;
    private Dictionary<string, AudioClip> seClips = new Dictionary<string, AudioClip>();

    //効果音の大きさを設定するための要素
    private float seVolume = 1f;
    private bool isMuted = false;

    //AwakeはUnityがオブジェクトをシーンに表示する直前に自動で呼び出す関数
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // ← 自分じゃなければ破棄！
            return;
        }

        seSource = gameObject.AddComponent<AudioSource>();

        // 音量とミュート状態を保存から復元
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1f);
        int savedMute = PlayerPrefs.GetInt(MuteKey, 0);

        seVolume = Mathf.Clamp01(savedVolume);
        isMuted = savedMute == 1;

        //ここにファイル名
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

    //効果音を読み込む？
    private void LoadSE(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>($"Audio/{name}");
        if (clip != null)
        {
            seClips[name] = clip;
        }
        else
        {
            Debug.LogWarning($"Audio/{name} が見つかりません");
        }
    }

    //音を鳴らす
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
        //Mathf.Clamp01(volume);　０～１に制限
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
