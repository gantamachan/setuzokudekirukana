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


    [SerializeField] private Image outlineImage;




    private bool isRevealed = false;

    private GodFieldData currentData;

    //「このカードの名前は何か？」を外部（NameCheckerなど）から見られるようにするための“窓口”
    public string CellName => currentData.Name;

    // 関数　引数はdata 最初のカードの状態を設定できるよ
    public void SetData(GodFieldData data)
    {
        //引数のデータを渡す
        currentData = data;

        // 初期状態：裏面だけ表示、それ以外は非表示
        backObject.SetActive(true);
        frontBackground.SetActive(false);
        nameText.gameObject.SetActive(false);
        frontImage.gameObject.SetActive(false);

        if(outlineImage != null)
    {
            outlineImage.gameObject.SetActive(false); // 初期は赤枠OFF
        }
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

    public void RevealAsMissed()
    {
        //裏隠す
        backObject.gameObject.SetActive(false);

        isRevealed = true;
        frontBackground.SetActive(true);
        frontImage.sprite = currentData.Sprite;
        nameText.text = currentData.Name;
        nameText.gameObject.SetActive(true);
        nameText.color = Color.red; // ← 名前を赤く！
        frontImage.gameObject.SetActive(true);
       
    }

    public void SetHighlight(bool enabled)
    {

        if (outlineImage != null)
        {
            outlineImage.gameObject.SetActive(enabled);
        }
    }

}
