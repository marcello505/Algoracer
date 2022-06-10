using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Question
{

    public string question;
    public List<Answer> answers;
    public AnswerEnum correctAnswer;

    public Question(string question, List<Answer> answers, AnswerEnum correctAnswer)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
    }



}

