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

    //「このカードの名前は何か？」を外部（NameCheckerなど）から見られるようにするための“窓口”
    public string CellName => currentData.Name;

    // 関数　引数はdata
    public void SetData(GodFieldData data)
    {
        //引数のデータを渡す
        currentData = data;

        // 初期状態：裏面だけ表示、それ以外は非表示
        backObject.SetActive(true);
        frontBackground.SetActive(false);
        nameText.gameObject.SetActive(false);
        frontImage.gameObject.SetActive(false);
    }

    public void Reveal()
    {
        // 裏面を隠す
        backObject.SetActive(false);

        // 表の要素を表示
        frontBackground.SetActive(true);
        nameText.text = currentData.Name;
        nameText.gameObject.SetActive(true);
        frontImage.sprite = currentData.Sprite;
        frontImage.gameObject.SetActive(true);
    }

}
