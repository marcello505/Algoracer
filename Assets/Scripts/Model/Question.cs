using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Question
{

    public string question;
    public List<Answer> answers;
    public AnswerEnum correctAnswer;
    public string hint;

    public Question(string question, List<Answer> answers, AnswerEnum correctAnswer, string hint)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
        this.hint = hint;
    }




}

