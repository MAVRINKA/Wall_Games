using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuizUI : MonoBehaviour
{
    public QuizGame quizGame;               //ref to the QuizGame script
    public TweenUI tweenUI;                 //ref to the TweenUI script
    public TextMeshProUGUI[] answersText;
    public Button[] answerBttns = new Button[4];
    public Image[] imageFillBtns;
    public TextMeshProUGUI questionText;    //text to show question
    public Image questionImage;             //image component to show image
    public AudioSource questionAudio;       //audio source for audio clip
    public VideoPlayer questionVideo;       //to show video
    public GameObject headPanel;
    public GameObject endGamePanel;
    public TextMeshProUGUI TFText;
    public GameObject checkQuestionImg;
    public TextMeshProUGUI infoTxt;
    public TextMeshProUGUI scoreTxt;

    public bool defaultColor = false, trueColor = false, falseColor = false;

    private float audioLength;              //store audio length
    private QuestionList selectedQuestion;  //store current question data

    private void Update()
    {
        if (defaultColor) headPanel.GetComponent<Image>().color = Color.Lerp(headPanel.GetComponent<Image>().color, new Color(231 / 255.0F, 78 / 255.0F, 62 / 255.0F), 8 * Time.deltaTime);
        if (trueColor) headPanel.GetComponent<Image>().color = Color.Lerp(headPanel.GetComponent<Image>().color, new Color(104 / 255.0F, 184 / 255.0F, 89 / 255.0F), 8 * Time.deltaTime);
        if (falseColor) headPanel.GetComponent<Image>().color = Color.Lerp(headPanel.GetComponent<Image>().color, new Color(192 / 255.0F, 57 / 255.0F, 43 / 255.0F), 8 * Time.deltaTime);
    }

    /// <summary>
    /// Method which populate the question on the screen
    /// </summary>
    /// <param name="questionList"></param>
    public void SetQuestion(QuestionList questionList)
    {
        this.selectedQuestion = questionList;
        switch (questionList.questionType)
        {
            case (QuestionType.TEXT):
                ImageHolder();
                StopCoroutine(PlayAudio());                           //stop Coroutine
                break;
            case (QuestionType.IMAGE):
                ImageHolder();
                questionImage.transform.gameObject.SetActive(true);
                questionImage.sprite = selectedQuestion.questionSprite;
                StopCoroutine(PlayAudio());                           //stop Coroutine
                break;
            case (QuestionType.AUDIO):
                ImageHolder();
                questionAudio.transform.gameObject.SetActive(true);
                questionAudio.clip = selectedQuestion.questionClip;
                audioLength = selectedQuestion.questionClip.length;   //set audio clip
                StartCoroutine(PlayAudio());                          //start Coroutine
                break;
            case (QuestionType.VIDEO):
                ImageHolder();
                questionVideo.transform.gameObject.SetActive(true);
                questionVideo.clip = selectedQuestion.questionVideo;
                questionVideo.Play();                                 //play video
                StopCoroutine(PlayAudio());                           //stop Coroutine
                break;
        }

        questionText.text = selectedQuestion.question;
        
        tweenUI.AnimateTitle();
        //tweenUI.AnimateBtns();
    }

    public void ImageHolder()
    {
        questionImage.transform.parent.gameObject.SetActive(true);
        questionImage.transform.gameObject.SetActive(false);
        questionAudio.transform.gameObject.SetActive(false);
        questionVideo.transform.gameObject.SetActive(false);
    }

    public void QuestionLoser()
    {
        //checkQuestionImg.GetComponent<Animator>().SetTrigger("CheckQuestinos_trigger");
        TFText.text = "Неверно!";
        TFText.color = Color.red;
        TFText.enabled = true;
    }
    public void QuestionComplete()
    {
        //checkQuestionImg.GetComponent<Animator>().SetTrigger("CheckQuestinos_trigger");
        TFText.enabled = true;
        TFText.color = Color.green;
        TFText.text = "Верно!";
    }

    /// <summary>
    /// IEnumerator to repeate the audio after some time
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayAudio()
    {
        //if questionType is audio
        if (selectedQuestion.questionType == QuestionType.AUDIO)
        {
            //PlayOneShot
            questionAudio.PlayOneShot(selectedQuestion.questionClip);
            //wait for few seconds
            yield return new WaitForSeconds(audioLength + 0.5f);
            //play again
            StartCoroutine(PlayAudio());
        }
        else //if questionType is not audio
        {
            //stop the Coroutine
            StopCoroutine(PlayAudio());
            //return null
            yield return null;
        }
    }

}
