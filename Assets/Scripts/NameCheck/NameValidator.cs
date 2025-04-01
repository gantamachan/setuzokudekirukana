using System.Collections.Generic;

public class NameValidator
{
   //�������ǂ����𔻒肷��

    private HashSet<string> correctNames;

    //�����̖��O�S�Ă��������X�g�������ɕۑ�����Ă���I�I�I
    public NameValidator(List<string> names)
    {
        correctNames = new HashSet<string>(names);
    }

    //�����̖��O���X�g�ɂ��邩�ǂ���������֐�
    public bool IsCorrect(string input)
    {
        return correctNames.Contains(input);
    }
}