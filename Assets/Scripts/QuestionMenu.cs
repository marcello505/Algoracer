using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionMenu : MonoBehaviour
{

    public TextMeshProUGUI questionText;
    private List<Question> questions = new List<Question>();
    private Question currentQuestion;
    private bool hasAnswered = false;
    public static bool isAnsweringQuestion = false;
    public CarBehaviourV2 carObject;
    private int _questionsAnsweredCorrectly = 0;


    public int GetQuestionsAnsweredCorrectly()
    {
        return _questionsAnsweredCorrectly;
    }

    public void initliazeQuestionScreen()
    {

        isAnsweringQuestion = true;

        currentQuestion = QuestionManager.getInstance().getRandomQuestion();


        //Initilize question GUI
        questionText.text = currentQuestion.question;


        GameObject.FindGameObjectWithTag("AnswerTextA").GetComponent<TextMeshProUGUI>().text = "A: " + currentQuestion.answers.Find((e) => e.answerEnum == AnswerEnum.A).answerText;
        GameObject.FindGameObjectWithTag("AnswerTextB").GetComponent<TextMeshProUGUI>().text = "B: " + currentQuestion.answers.Find((e) => e.answerEnum == AnswerEnum.B).answerText;
        GameObject.FindGameObjectWithTag("AnswerTextC").GetComponent<TextMeshProUGUI>().text = "C: " + currentQuestion.answers.Find((e) => e.answerEnum == AnswerEnum.C).answerText;
        GameObject.FindGameObjectWithTag("AnswerTextD").GetComponent<TextMeshProUGUI>().text = "D: " + currentQuestion.answers.Find((e) => e.answerEnum == AnswerEnum.D).answerText;
    }



    void emptyAnswerTexts()
    {
        GameObject.FindGameObjectWithTag("AnswerTextA").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.FindGameObjectWithTag("AnswerTextB").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.FindGameObjectWithTag("AnswerTextC").GetComponent<TextMeshProUGUI>().text = "";
        GameObject.FindGameObjectWithTag("AnswerTextD").GetComponent<TextMeshProUGUI>().text = "";
    }


    private void correctAnswered()
    {

        emptyAnswerTexts();
        _questionsAnsweredCorrectly++;

        questionText.text = "Goed geantwoord!";

        StartCoroutine(hideMenu());

        //Apply playerboost
        // menu weg doen duurt nu 3 sec dus er is 3 seconden boost in totaal
        carObject.SetBoostingLength(6);
    }

    private void wrongAnswered()
    {

        emptyAnswerTexts();

        questionText.text = "Fout geantwoord!";


        StartCoroutine(hideMenu());
    }


    IEnumerator hideMenu()
    {


        yield return new WaitForSeconds(0.75f);

        questionText.text = "Verder racen in... ";

        yield return new WaitForSeconds(0.75f);

        questionText.text = "3";

        yield return new WaitForSeconds(0.5f);

        questionText.text = "2";

        yield return new WaitForSeconds(0.5f);

        questionText.text = "1";

        yield return new WaitForSeconds(0.5f);


        GameObject.FindGameObjectWithTag("QuestionMenu").gameObject.SetActive(false);

        isAnsweringQuestion = false;
        hasAnswered = false;
    }



    public void AnswerA() { genericAnswer(AnswerEnum.A); }

    public void AnswerB() { genericAnswer(AnswerEnum.B); }

    public void AnswerC() { genericAnswer(AnswerEnum.C); }

    public void AnswerD() {  genericAnswer(AnswerEnum.D); }

    public void genericAnswer(AnswerEnum answer)
    {
        if (hasAnswered == true) return;
        hasAnswered = true;
        if (currentQuestion.correctAnswer == answer)
        {
            Debug.Log("Goed!");
            correctAnswered();
        }
        else
        {
            Debug.Log("Fout!");
            wrongAnswered();
        }
    }


}

