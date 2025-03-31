using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshを使うときはとりあえず書くやつ


public class NameChecker : MonoBehaviour
{
    //Inspector上で見えるようにする呪文　外からアクセスできないよ　TMProが用意してる変数の型　変数（分かりやすく自由に定義）
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text answeredText;
    [SerializeField] private TMP_Text resultText;

    //HashSet(重複しないリストを作成）　文字列型だよ　変数（自由）　＝　新しくからのHashsetを作れという命令
    private HashSet<string> answeredNames = new HashSet<string>();
    //Listを作成
    private List<CorrectNameCell> allCells = new List<CorrectNameCell>();



    //このリストはチェック用。あとで自動化します
    private List<string> correctNames = new List<string>
{
    "両替", "売る", "買う", "銅の棍棒", "銀の棍棒", "金の棍棒"
};


    private void Update()
    {
        // エンターキー（Return）を押したかチェック
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckInputName(); // ボタンと同じ関数を実行！
        }
    }




    // 戻り値のない関数　自由に関数名を定義　Unity側の操作でボタンを押したら呼び出されるようにする。
    public void CheckInputName()
    {
        //変数の型（文字列だよ！って意味）　変数（自由）変数。↑で宣言した変数と一致させる　文字列として読む機能　空白を消す便利機能
        string input = inputField.text.Trim();
        
        //もし　string型の関数であるinputが空っぽか何もなければ　おわり
        if (string.IsNullOrEmpty(input))
        {
            resultText.text = "空欄です";
            EndCheck();
            return;
        }

        //もし　inputの中身がリストに　存在したら　おわり～
        if (answeredNames.Contains(input))
        {
            resultText.text = "既に回答済み";
            EndCheck();
            return;
            
        }

        //Contains 存在するかどうか確かめる
        //もし　inputの中身が事前に用意したリストに存在したら　
        if(correctNames.Contains(input))
        {
            resultText.text = "正解";
            //FindObjectOfType	シーン内のスクリプトを探す便利関数
            var spawner = FindObjectOfType<CorrectNameGridSpawner>();

            // Hashsetにその名前を追加
            answeredNames.Add(input);

            foreach (CorrectNameCell cell in spawner.GetAllCells())
            {
                if (cell.CellName == input)
                {
                    cell.Reveal();
                    break;
                }
            }



            EndCheck();

            
        }
        else
        {
            resultText.text = "不正解";
        }

        


    }


    private void EndCheck()
    {
        inputField.text = "";
    }



}