using System.Collections.Generic;

public class NameValidator
{
   //正解かどうかを判定する

    private HashSet<string> correctNames;

    //正解の名前全てを示すリストがここに保存されている！！！
    public NameValidator(List<string> names)
    {
        correctNames = new HashSet<string>(names);
    }

    //正解の名前リストにあるかどうかを見る関数
    public bool IsCorrect(string input)
    {
        return correctNames.Contains(input);
    }
}