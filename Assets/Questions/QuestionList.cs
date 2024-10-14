using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question List", menuName = "Create New Question List", order = 1)]
public class QuestionList : ScriptableObject
{
    [SerializeField]
    public int chapter;
    [SerializeField]
    public List<Question> questions; 
}

[Serializable]
public class Question
{
    public string question;
    public List<Answer> answers = new List<Answer>();
    public string reference;

    public string GetQuestion()
    {
        return question;
    }
    public List<Answer> GetAnswers()
    {
        return answers;
    }

    public string GetReference() {
        return reference;
    }
}

[Serializable]
public class Answer
{
    public string answer;
    public bool isCorrect;
}



