using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Answer answer { get; private set; }

    public void SetAnswer(Answer a)
    {
        answer = a;
        text.text = a.answer;
    }

    public void CheckAnswer()
    {
        if (answer.isCorrect)
        {
            UIManager.Instance.ShowResult("Correct!");
        }
        else
        {
            UIManager.Instance.ShowResult("Wrong!");
            GameManager.Instance.ShowCorrectAnswer();
        }
    }
    
}
