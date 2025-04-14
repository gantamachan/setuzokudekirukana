using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button muteButton;
    [SerializeField] private Image muteIcon;

    private void Start()
    {
        // 初期化（AudioManager側ですでに保存値が読み込まれてる前提）
        float currentVolume = AudioManager.Instance.GetVolume();
        volumeSlider.value = Mathf.RoundToInt(currentVolume * 10); // 10段階に反映
        UpdateMuteIcon();

        // イベント登録
        volumeSlider.onValueChanged.AddListener(OnSliderChanged);
        muteButton.onClick.AddListener(OnMuteClicked);
    }

    private void OnSliderChanged(float value)
    {
        float newVolume = value / 10f;
        AudioManager.Instance.SetVolume(newVolume);
        UpdateMuteIcon(); // ミュート状態と関係ある場合もあるので更新
    }

    public void OnMuteClicked()
    {
        Debug.Log("Mute button clicked!");
        AudioManager.Instance.ToggleMute();
        UpdateMuteIcon();
    }

    private void UpdateMuteIcon()
    {
        if (AudioManager.Instance.IsMuted())
        {
            muteIcon.color = new Color(1f, 1f, 1f, 0.3f); // ミュート時 → グレー
        }
        else
        {
            muteIcon.color = Color.white; // 音あり → 白
        }
    }

}
