using System.Collections.Generic;

//既に答えたものを管理する
public class AnswerTracker
{
    private HashSet<string> answered = new HashSet<string>();

    //既に答えたかを確認する関数
    public bool IsAnswered(string name)
    {
        return answered.Contains(name);
    }

    //正解したときに既に答えたリストに追加
    public void AddAnswer(string name)
    {
        answered.Add(name);
    }

    public int Count => answered.Count;
}