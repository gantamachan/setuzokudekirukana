using System.Collections.Generic;

//���ɓ��������̂��Ǘ�����
public class AnswerTracker
{
    private HashSet<string> answered = new HashSet<string>();

    //���ɓ����������m�F����֐�
    public bool IsAnswered(string name)
    {
        return answered.Contains(name);
    }

    //���������Ƃ��Ɋ��ɓ��������X�g�ɒǉ�
    public void AddAnswer(string name)
    {
        answered.Add(name);
    }

    public int Count => answered.Count;
}