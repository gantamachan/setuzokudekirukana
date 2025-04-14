using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button muteButton;
    [SerializeField] private Image muteIcon;

    private void Start()
    {
        // �������iAudioManager���ł��łɕۑ��l���ǂݍ��܂�Ă�O��j
        float currentVolume = AudioManager.Instance.GetVolume();
        volumeSlider.value = Mathf.RoundToInt(currentVolume * 10); // 10�i�K�ɔ��f
        UpdateMuteIcon();

        // �C�x���g�o�^
        volumeSlider.onValueChanged.AddListener(OnSliderChanged);
        muteButton.onClick.AddListener(OnMuteClicked);
    }

    private void OnSliderChanged(float value)
    {
        float newVolume = value / 10f;
        AudioManager.Instance.SetVolume(newVolume);
        UpdateMuteIcon(); // �~���[�g��ԂƊ֌W����ꍇ������̂ōX�V
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
            muteIcon.color = new Color(1f, 1f, 1f, 0.3f); // �~���[�g�� �� �O���[
        }
        else
        {
            muteIcon.color = Color.white; // ������ �� ��
        }
    }

}
