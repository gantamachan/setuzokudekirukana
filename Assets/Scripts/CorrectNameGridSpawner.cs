using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectNameGridSpawner : MonoBehaviour
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject  cellPrefab;

    //CollectNameCell型＝「CorrectNameCellというルールで作られたモノ」を指す。　＝カードプレハブたちのこと
    //空のリストであるallCellsを新しく作成
    //例　allCells[0]は両替のカード（伏せ）が保存されている
    private List<CorrectNameCell> allCells = new List<CorrectNameCell>();


 


    void Start()
    {
        //Listは
        List<GodFieldData> dataList = GodFieldDataLoader.Load();

        //foreachはリストを一個ずつ全部見る処理のこと
        //for (int i = 0; i < dataList.Count; i++) と意味は一緒だけど、こっちの方が分かりやすいよね
        //リストの全部の要素を見るぞ！とかの時に使うとよい

        foreach (GodFieldData data in dataList)
        {
            // Instantiateは「プレハブ（Prefab）」から コピーを作ってゲームに出すための関数！
            var cellObject = Instantiate(cellPrefab);

            // ② cellをgridParentの子に入れてね＝UIをGridの下に入れてね　プレハブを保存したときの位置関係は維持しないでね
            cellObject.transform.SetParent(gridParent, false);

            //CollectNameCell型＝「CorrectNameCellというルールで作られたモノ」を指す。　＝カードプレハブたちのこと
            //GetComponent　プレハブの中から、<>内のスクリプトを探して取り出す関数
            CorrectNameCell cell = cellObject.GetComponent<CorrectNameCell>();

            cell.SetData(data);

            allCells.Add(cell);
        }


        

    }


    //公開の　戻り値がCorrectNameCell型のリスト　である関数　（引数は無し）
    public List<CorrectNameCell> GetAllCells()
    {
        return allCells;
    }
}
