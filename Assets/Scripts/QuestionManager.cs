using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance { get; private set; }

    public List<QuestionList> questionLists;

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
            foreach(QuestionList qList in questionLists)
            {
                if(qList.GetChapter() == chapter)
                {
                    foreach(Question q in qList.questions)
                    {
                        questions.Add(q);
                    }
                }
            }
        }
    }

    public Question GetQuestion()
    {
        if (questions.Count > 0)
        {
            int pickedQuestion = Random.Range(0, questions.Count);
            return questions[pickedQuestion];
        }
        else
        {
            Debug.Log("NO QUESTIONS!");
            return null;
        }
    }
    

    

   
}
