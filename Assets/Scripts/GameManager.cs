using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {  get; private set; }

    //current question
    public Question currentQuestion {  get; private set; }

    //Monobehavior methods
    private void Awake()
    {
        Instance = this;
    }

    public void StartGame(int chapter) {

        QuestionManager.Instance.LoadQuestions(chapter);
        ShowQuestion();
    }

    public void Endgame() {
        Debug.Log("Game Over - returning to main menu.");
    }

    public void ShowQuestion()
    {
        UIManager.Instance.ClearAnswers();
        Question question = QuestionManager.Instance.GetQuestion();
        currentQuestion = question;
        UIManager.Instance.ShowQuestion(question);
    }

    public void ShowCorrectAnswer()
    {
        string correct = FindCorrectAnswer();
        UIManager.Instance.ShowCorrectAnswer(correct);
    }

    private string FindCorrectAnswer()
    {
        foreach (Answer a in currentQuestion.GetAnswers()) {
            if (a.isCorrect) {
                return a.answer;
            }
        }
        return null;
    }
    
}
