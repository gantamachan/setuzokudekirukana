using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectNameGridSpawner : MonoBehaviour
{
    [SerializeField] private Transform gridParent;
    [SerializeField] private GameObject  cellPrefab;
    
    void Start()
    {
        //Listは
        List<GodFieldData> dataList = GodFieldDataLoader.Load();

        //foreachはリストを一個ずつ全部見る処理のこと
        //for (int i = 0; i < dataList.Count; i++) と意味は一緒だけど、こっちの方が分かりやすいよね
        //リストの全部の要素を見るぞ！とかの時に使うとよい

        foreach (GodFieldData data in dataList)
        {
            // ① プレハブを複製し、それを変数に入れる
            var cell = Instantiate(cellPrefab);

            // ② cellをgridParentの子に入れてね＝UIをGridの下に入れてね　プレハブを保存したときの位置関係は維持しないでね
            cell.transform.SetParent(gridParent, false);

            
        }
    }

}
