using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//Staticがついているとインスタンス化せずに使える
//ざっくりいうとNewしなくても使えるようになる
//1回だけしか使わないものに使うとよいとされていたりする
public static class GodFieldDataLoader 
{
   

    public static List<GodFieldData>Load()
    {
        //リソースの中のテキストであるCSVファイルを読み込む呪文（この段階では激長テキスト）
        TextAsset csvFile = Resources.Load<TextAsset>("CSV/GodField_data");

        //エラー確認用
        if (csvFile == null)
        {
            Debug.LogError("CSVファイルが見つかりません: GodField_data.csv");
            return new List<GodFieldData>();
        }

        //Listを新しく作成！　Listは動的配列＝dateList[0] みたいな表現で各列にアクセス可能
        var dataList = new List<GodFieldData>();



        //文字列型の配列であるlinesに、一行ごとに分割されたcsvのテキストを入れる　
        //例　lines[0]は"ID,Name,Image,Type"　lines[1]="1,両替,ryougae,Torihiki" 　　ちなみに　"この点々"、大事
        string[] lines = csvFile.text.Split('\n');

        
        //lines[0]は説明欄なので無視！　
        //iが行数より小さい間は繰り返す＝勝手にファイルの最後まで読んでくれる
        //一回ループしたら次の行へ行く（iに＋１する）

        for (int i = 1; i < lines.Length; i++)
        {
            //間違って入れちゃった空白を取り除く＆もしも空欄なら取り除く
            //countinue　　このループを終了し次のループを開始する！
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            //文字列型の配列valuesに、カンマで区切ったテキストを入れる
            //例　i=1のとき values[0]は"1"
            //　　　　　　  valus[1]は"両替" になる
            //データが４つ以下の行　つまり入力ミスってるのは　飛ばす
            string[] values = line.Split(',');
            if (values.Length < 4) continue;

            //配列を分解していく
            int id = int.Parse(values[0]); // 文字列 → 整数型にしてくれるありがたい関数
            string name = values[1];
            string imageName = values[2];
            string type = values[3];
            //→このままだと各データがバラバラで紐づかなくなる

            //なので、GodFieldData型の変数に入れる
            //例　GodFieldData(1, "両替", "ryougae", "Torihiki")

            // ※　ここでnewされた！　つまりGodFieldData.cs のコンストラクタ関数が起動する！
            //dataはGodFieldData型の変数＝Int、文字、文字、文字が入るよね！
            //dataはインスタンス（実体である）＝GodFieldDataというクラスの
            GodFieldData data = new GodFieldData(id, name, imageName, type);



            //i=1のときのリストは↓
            //dataList[0] = GodFieldData { Id = 1, Name = "両替", ImageName = "ryougae", Type = "Torihiki" }
            dataList.Add(data);


        }

        //forの中の処理が終わる＝全てのデータがリストに格納されました
        //OrderBy いい感じに並び替えしてくれるありがたい関数
        //ちなみに今回はデータ整理済みだから無しでもいい！があると間違えてた時に事故らない
        // ToList　リストに変換してくれるありがたい関数
        
        return dataList.OrderBy(d => d.Id).ToList();
    }
}
