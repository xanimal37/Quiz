using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject gameUI;
    //main menu compoents
    public TextMeshProUGUI titleText;

    //settings components
    public TextMeshProUGUI chapterSliderText;
    public Slider slider;

    private int sliderValue;
    private bool useAllChapters;

    //game compoenntes
    public TextMeshProUGUI questionText;
    public GameObject answerContainer;
    public Button answerButtonPrefab;
    public TextMeshProUGUI result;
    public Button nextButton;
    public TextMeshProUGUI correctAnswerText;

    //monobehavior methods
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        useAllChapters = false;
        sliderValue = 2;
        result.enabled = false;
        nextButton.gameObject.SetActive(false);
        correctAnswerText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        if (useAllChapters) {
            GameManager.Instance.StartGame(-1);
           
            Debug.Log("starting game with all questions.");

        }
        else {
            GameManager.Instance.StartGame(sliderValue);
            Debug.Log("starting game with chapter " + sliderValue);
        }
        
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        gameUI.SetActive(true);
    }

    public void UpdateSliderText(float val)
    {
        chapterSliderText.text = "chapter " + val.ToString();
        sliderValue = (int)val;
    }

    public void ToggleChapterSlider(bool val)
    {

        chapterSliderText.enabled = !val;
        slider.enabled = !val;
        useAllChapters = val;
    }

    public void ShowQuestion(Question question)
    {
        questionText.text = question.GetQuestion();
        foreach(Answer a in question.GetAnswers()){
            Button answerBtn = Instantiate(answerButtonPrefab);
            answerBtn.GetComponent<AnswerButton>().SetAnswer(a);
            answerBtn.transform.SetParent(answerContainer.transform, false);
        }
    }

    public void ClearAnswers()
    {
        foreach (Transform child in answerContainer.transform)
        {
            Destroy(child.gameObject);
        }

        result.enabled = false;
        nextButton.gameObject.SetActive(false);
        correctAnswerText.gameObject.SetActive(false);
    }

    public void ShowResult(string text)
    {
        foreach(Transform t in answerContainer.transform)
        {
            t.gameObject.SetActive (false);
        }
        result.text = text;
        result.enabled = true;
        nextButton.gameObject.SetActive(true);
    }

    public void ShowCorrectAnswer(string s)
    {
        correctAnswerText.text = s;
        correctAnswerText.gameObject.SetActive (true);
    }
    

}
