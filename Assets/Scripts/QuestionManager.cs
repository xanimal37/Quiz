using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance { get; private set; }

    public QuestionList chapter2;
    public QuestionList chapter3;
    public QuestionList chapter4;
    public QuestionList chapter5;
    public QuestionList chapter6;
    public QuestionList chapter7;
    public QuestionList chapter8;
    public QuestionList chapter9;
    public QuestionList chapter10;
    public QuestionList chapter11;

    private List<QuestionList> questionLists;

    private List<Question> questions;



    #region "MONOBEHAVIOR"
    void Awake()
    {
        Instance = this;
    }

    //if chapter is 0, load all
    private void Start()
    {
        //holds all available questions for this instance
        questions = new List<Question>();

        //holds all the questionList scrioptable objects
        questionLists = new List<QuestionList>();

        questionLists.Add(chapter2);
        questionLists.Add(chapter3);
        questionLists.Add(chapter4);
        questionLists.Add(chapter5);
        questionLists.Add(chapter6);
        questionLists.Add(chapter7);
        questionLists.Add(chapter8);
        questionLists.Add(chapter9);
        questionLists.Add(chapter10);
        questionLists.Add(chapter11);
    }
    #endregion

    //if -1, load all chapters. otherwise load index
    public void LoadQuestions(int chapter)
    {
      
        if (chapter == -1)
        {
            foreach (QuestionList qList in questionLists)
            {
                foreach (Question q in qList.questions)
                {
                    questions.Add(q);
                }
            }
        }

        else
        {
            foreach (Question q in questionLists[chapter].questions)
            {
                questions.Add(q);
            }
        }
    }

    public Question GetQuestion()
    {
        int pickedQuestion = Random.Range(0, questions.Count);
        return questions[pickedQuestion];
    }
    

    

   
}
