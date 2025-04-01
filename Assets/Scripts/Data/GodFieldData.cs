using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classは設計図みたいなもの
public class GodFieldData 
{


    public int Id { get; private set; } // 図鑑番号
    public string Name { get; private set; } // 名前
    public string ImageName { get; private set; } // 画像ファイル名
    public string Type { get; private set; } // 神器のタイプ（取引など）
    public Sprite Sprite { get; private set; } // 読み込んだ画像（あとで表示用）


    //コンストラクタという関数！！！
    //つまりGodFieldDataを使って実際にデータが作られたときに動く
    //　GFDataという変数の型はInt、文字型、文字型、文字型　だよ！って言うのを定義している
    //id,name,imagename,typeはすべて引数！！！！大事
    public GodFieldData(int id,string name,string imagename,string type)
    {

        //ここ後で復習

        Id = id;
        Name = name;
        ImageName = imagename;
        Type = type;

        SpriteLoader();

    }

    private void SpriteLoader()
    {

        //Resources/Sprites/ フォルダの中にある ImageName.png を探して読み込んで、Spriteにセットしてね！
        Sprite = Resources.Load<Sprite>($"Sprites/{ImageName}");

        //画像ない時のエラー確認用
        if (Sprite == null)
        {
            Debug.LogWarning($"画像が見つかりません:{Name}: {ImageName}");
        }
    }
   
}
