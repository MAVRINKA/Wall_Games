using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Video;

public class QuizGame : MonoBehaviour
{
    public QuizUI quiz_UI;                  //ref to the QuizGameUI script
    private List<QuestionList> questions;

    [SerializeField] private List<QuizDataScriptable> quizDataList;
    private QuizDataScriptable dataScriptable;

    private int score = 0;
    private int numberQuestion;

    private AudioSource _audio;
    [Header("Audio")]
    public AudioClip win;
    public AudioClip gameover;

    //реализовать возможность не передавать данные во время задавания вопроса, его оценивния и перехода
    public bool isGame;

    private List<object> qList;
    private QuestionList selectedQuestion; //select question

    private readonly int dataIndex = 0; //select data index (theme quiz)

    private int randQuestion; //random question

    public GameStyle gameStyle = GameStyle.TRANSITION;

    private void Start()
    {
        StartGame();
    }

    void Update()
    {
        IdentityTxtScore();

        if (gameStyle == GameStyle.PLAYING)
        {
            
        }

        //можем сгенерить новый вопрос при условии, что ответили на предыдущий
        if (gameStyle == GameStyle.NEXTQUESTION) 
        {
            if (Input.GetMouseButtonDown(1))
            {
                QuestionGenerateMain();
            }
        }
    }

    //start game method 
    public void StartGame()
    {
        //set the questions data
        questions = new List<QuestionList>();

        dataScriptable = quizDataList[dataIndex];
        questions.AddRange(dataScriptable.questions);

        //count questions in dataScriptbale
        numberQuestion = questions.Count;

        qList = new List<object>(questions);
        QuestionGenerateMain();
        //isGame = true;
        //gameStatus = GameStatus.PLAYING;
        //if (!headPanel.GetComponent<Animator>().enabled) headPanel.GetComponent<Animator>().enabled = true;
        //else headPanel.GetComponent<Animator>().SetTrigger("In");
    }

    public void QuestionGenerateMain()
    {
        StartCoroutine(QuestionGenerate());
    }

    /// <summary>
    /// Method used to randomly select the question form questions data
    /// </summary>
    public IEnumerator QuestionGenerate()
    {
        if (qList.Count > 0)
        {
            randQuestion = Random.Range(0, qList.Count);
            selectedQuestion = qList[randQuestion] as QuestionList;

            quiz_UI.SetQuestion(selectedQuestion);

            List<string> answers = new List<string>(selectedQuestion.answers);

            for (int i = 0; i < selectedQuestion.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                quiz_UI.answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }

            //isGame = false;
            //возможность ответить появляется после просмотра вопроса/видео/прослушивания аудио
            yield return new WaitForSeconds(5);
            isGame = true;
            gameStyle = GameStyle.PLAYING;
            for (int i = 0; i < quiz_UI.answerBttns.Length; i++) quiz_UI.answerBttns[i].interactable = true;

            //TFText.enabled = false;
            //checkQuestionImg.SetActive(false);
            //qText.gameObject.GetComponent<Animator>().SetTrigger("In");
            //StartCoroutine(animBttns());
        }
        else
        {
            print("Вы прошли игру");
            StartCoroutine(CompleteGame());
        }
    }

    IEnumerator CompleteGame()
    {
        if(score <= numberQuestion / 2)
            quiz_UI.infoTxt.text = "Стоит немного потренироваться!";
        else
            quiz_UI.infoTxt.text = quiz_UI.infoTxt.text;

        yield return new WaitForEndOfFrame();
        quiz_UI.endGamePanel.SetActive(true);
    }

    //check the answer is correct or not
    IEnumerator TrueOrFalse(bool check)
    {
        isGame = false;
        gameStyle = GameStyle.TRANSITION;
        quiz_UI.defaultColor = false;
        for (int i = 0; i < quiz_UI.answerBttns.Length; i++) quiz_UI.answerBttns[i].interactable = false;
        yield return new WaitForSeconds(1);
        //for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].gameObject.GetComponent<Animator>().SetTrigger("Out");
        //qText.gameObject.GetComponent<Animator>().SetTrigger("Out");
        //if (!TFIcon.gameObject.activeSelf) TFIcon.gameObject.SetActive(true);
        //else TFIcon.gameObject.GetComponent<Animator>().SetTrigger("In");
        if (check)
        {
            quiz_UI.trueColor = true;
            quiz_UI.QuestionComplete();
            score += 1;
            //_audio.PlayOneShot(win);
            yield return new WaitForSeconds(1);
            //TFIcon.gameObject.GetComponent<Animator>().SetTrigger("Out");
            qList.RemoveAt(randQuestion);
            QuestionGenerateMain();
            //for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = true;
            quiz_UI.trueColor = false;
            quiz_UI.defaultColor = true;
            gameStyle = GameStyle.NEXTQUESTION;
            yield break;
        }
        else
        {
            quiz_UI.falseColor = true;
            quiz_UI.QuestionLoser();
            //_audio.PlayOneShot(gameover);
            yield return new WaitForSeconds(1);
            qList.RemoveAt(randQuestion);
            QuestionGenerateMain();
            //for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = true;
            //TFIcon.gameObject.GetComponent<Animator>().SetTrigger("Out");
            //headPanel.GetComponent<Animator>().SetTrigger("Out");
            quiz_UI.falseColor = false;
            quiz_UI.defaultColor = true;
            gameStyle = GameStyle.NEXTQUESTION;
            yield break;
        }
    }

    /// <summary>
    /// Method called to check the answer is correct or not
    /// </summary>
    /// <param name="index">answer string</param>
    public void AnswerBtns(int index)
    {
        if (quiz_UI.answersText[index].text.ToString() == selectedQuestion.answers[0]) StartCoroutine(TrueOrFalse(true));
        else StartCoroutine(TrueOrFalse(false));
    }

    public void IdentityTxtScore()
    {
        quiz_UI.scoreTxt.text = score.ToString() + "/" + numberQuestion;
    }
}
[System.Serializable]
public class QuestionList
{
    public QuestionType questionType;
    public Sprite questionSprite;
    public AudioClip questionClip;
    public VideoClip questionVideo;

    [TextArea(5, 5)]
    public string question;
    public string[] answers = new string[4];
}
[System.Serializable]
public enum QuestionType { TEXT, IMAGE, AUDIO, VIDEO }

[System.Serializable]
public enum GameStyle { PLAYING, TRANSITION, NEXTQUESTION  } // let's play or move on to the question
