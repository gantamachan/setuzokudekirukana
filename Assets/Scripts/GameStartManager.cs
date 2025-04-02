using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartManager : MonoBehaviour
{
    [SerializeField] private Button mainButton;
    [SerializeField] private TMP_InputField nameInputField;
    //�^�C�}�[�R���g���[���[����script�Ɛڑ�
    [SerializeField] private TimerController timerController;
    [SerializeField] private TextMeshProUGUI buttonText;

    private bool isGameStarted = false;

    void Start()
    {
        // ������ԁF���O���͕s��
        nameInputField.interactable = false;
        buttonText.text = "�J�n";
        mainButton.onClick.AddListener(OnMainButtonClicked);
    }

    private void OnMainButtonClicked()
    {
        if (!isGameStarted)
        {
            // �Q�[���J�n�I
            isGameStarted = true;
           timerController.StartTimer();

            // ���͎�t��ON��
            nameInputField.interactable = true;
            nameInputField.text = "";
            nameInputField.ActivateInputField();

            // �{�^���e�L�X�g��ύX
            buttonText.text = "������I";

            // �{�^���̐F��ς��ĕ�����₷���i�C�Ӂj
            mainButton.image.color = new Color(0.5f, 1f, 0.5f); // ������

            // NameChecker�ȂǂɁu�J�n�ς݁v�t���O��ʒm����ꍇ�͂�����
        }
        else
        {
            // �񓚑��M�����փo�C�p�X�i��FNameChecker�o�R��CheckAnswer�j
            FindObjectOfType<NameCheckerV2>().CheckInputName();
        }
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}