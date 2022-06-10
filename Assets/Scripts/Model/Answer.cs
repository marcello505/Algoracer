using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer
{
    public string answerText;
    public AnswerEnum answerEnum;

    public Answer(string answerText, AnswerEnum answerEnum)
    {
        this.answerText = answerText;
        this.answerEnum = answerEnum;
    }

}
