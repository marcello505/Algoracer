using System;
using System.Collections;
using System.Collections.Generic;

public class QuestionManager
{

    private static QuestionManager instance = null;
    private Random random = new Random();
    private List<Question> questions;
    private List<Question> questionsLeft;
    private Question currentQuestion;

    private QuestionManager()
    {

        questions = new List<Question>();

        Answer q1AnswerA = new Answer("Sociale media", AnswerEnum.A);
        Answer q1AnswerB = new Answer("Checken van je gezondheid", AnswerEnum.B);
        Answer q1AnswerC = new Answer("Online Artikelen", AnswerEnum.C);
        Answer q1AnswerD = new Answer("Stemmen", AnswerEnum.D);


        List<Answer> answersQuestion1 = new List<Answer>();
        answersQuestion1.Add(q1AnswerA);
        answersQuestion1.Add(q1AnswerB);
        answersQuestion1.Add(q1AnswerC);
        answersQuestion1.Add(q1AnswerD);


        Question question1 = new Question("Waar worden algoritmes NIET gebruikt?", answersQuestion1, AnswerEnum.D, "Politieke doeleinden");


        questions.Add(question1);

        Answer q2AnswerA = new Answer("Een set met instructies voor het bereiken van een doel", AnswerEnum.A);
        Answer q2AnswerB = new Answer("Een digitale munteenheid", AnswerEnum.B);
        Answer q2AnswerC = new Answer("Het manier van online data verzamelen", AnswerEnum.C);
        Answer q2AnswerD = new Answer("De taal waarmee een computer iets doet", AnswerEnum.D);


        List<Answer> answersQuestion2 = new List<Answer>();
        answersQuestion2.Add(q2AnswerA);
        answersQuestion2.Add(q2AnswerB);
        answersQuestion2.Add(q2AnswerC);
        answersQuestion2.Add(q2AnswerD);


        Question question2 = new Question("Wat is een algoritme?", answersQuestion2, AnswerEnum.A, "Stapsgewijs iets uitvoeren");

        questions.Add(question2);

        Answer q3AnswerA = new Answer("Het herkennen van objecten", AnswerEnum.A);
        Answer q3AnswerB = new Answer("Het begrijpen van actuele zaken", AnswerEnum.B);
        Answer q3AnswerC = new Answer("Jou koppelen aan je nieuwe date", AnswerEnum.C);
        Answer q3AnswerD = new Answer("Het berekenen van je belasting op basis van je maandsalaris", AnswerEnum.D);


        List<Answer> answersQuestion3 = new List<Answer>();
        answersQuestion3.Add(q3AnswerA);
        answersQuestion3.Add(q3AnswerB);
        answersQuestion3.Add(q3AnswerC);
        answersQuestion3.Add(q3AnswerD);


        Question question3 = new Question("Waar is een algoritme NIET goed in?", answersQuestion3, AnswerEnum.A, "Hoeveel truien passen er in je koffer?");

        questions.Add(question3);




        Answer q4AnswerA = new Answer("Biede stellingen zijn juist", AnswerEnum.A);
        Answer q4AnswerB = new Answer("Beide stellingen zijn onjuist", AnswerEnum.B);
        Answer q4AnswerC = new Answer("Alleen stelling A is juist", AnswerEnum.C);
        Answer q4AnswerD = new Answer("Alleen stelling B is juist", AnswerEnum.D);


        List<Answer> answersQuestion4 = new List<Answer>();
        answersQuestion4.Add(q4AnswerA);
        answersQuestion4.Add(q4AnswerB);
        answersQuestion4.Add(q4AnswerC);
        answersQuestion4.Add(q4AnswerD);


        Question question4 = new Question("Stelling A: Een algoritme kan voorspellen dat je zwanger bent op basis van je zoekhistory\nStelling B: Een ander woordt voor algoritme is recept", answersQuestion4, AnswerEnum.A, "De volgende stap is....");

        questions.Add(question4);



        Answer q5AnswerA = new Answer("Biede stellingen zijn juist", AnswerEnum.A);
        Answer q5AnswerB = new Answer("Beide stellingen zijn onjuist", AnswerEnum.B);
        Answer q5AnswerC = new Answer("Alleen stelling A is juist", AnswerEnum.C);
        Answer q5AnswerD = new Answer("Alleen stelling B is juist", AnswerEnum.D);


        List<Answer> answersQuestion5 = new List<Answer>();
        answersQuestion5.Add(q5AnswerA);
        answersQuestion5.Add(q5AnswerB);
        answersQuestion5.Add(q5AnswerC);
        answersQuestion5.Add(q5AnswerD);


        Question question5 = new Question("Stelling A: Een algoritme is altijd zelflerend\nStelling B: Algoritmes bestaan al meer dan 100 jaar", answersQuestion4, AnswerEnum.D, "Alles is vaak oud...");

        questions.Add(question5);



        questions.ForEach(questionsLeft.Add);



        int randomNumber = random.Next(0, questions.Count);
        //MessageBox.Show(Convert.ToString(randomNumber));
        currentQuestion = questionsLeft[randomNumber];

        questionsLeft.Remove(currentQuestion);



    }


    public void generateNewQuestion()
    {
        int randomNumber = random.Next(0, questions.Count);
        //MessageBox.Show(Convert.ToString(randomNumber));
        currentQuestion = questionsLeft[randomNumber];

        questionsLeft.Remove(currentQuestion); 
    }


    public Question getCurrentQuestion()
    {
        return currentQuestion;
    }



    public string getHintFromCurrentQuestion()
    {
        return currentQuestion.hint;
    }


    public static QuestionManager getInstance()
    {
        if(instance == null)
        {
            instance = new QuestionManager();
        }

        return instance;
    }


}
