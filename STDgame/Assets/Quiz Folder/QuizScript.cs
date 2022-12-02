using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class QuizScript : MonoBehaviour
{
    private class Question
    {
        
        public string maintext;
        public string[] questions;
        public int correctanswer;
        public string precision;
        
        public Question(string maintext, string[] questions, int correctanswer, string precision)
        {
            this.maintext = maintext;
            this.questions = questions;
            this.correctanswer = correctanswer;
            this.precision = precision;
        }
    }

    private Button[] buttons;
    private TMP_Text maintext;
    private Question currentQuestion;
    private int currenQuestionnb = 0;
    private bool wasCorrect = false;
    private List<Question> questions;





    

    


void changeTexts(int question)
    {
        for (int i = 0; i < 4; i++)
        {
            Button btn = buttons[i];
            
            btn.GetComponentInChildren<TMP_Text>().text = questions[question].questions[i];
        }
        maintext.text = questions[question].maintext;
        currentQuestion = questions[question];
        currenQuestionnb++;


    }
    void addMockQuestions()
    {
  Question question1 = new Question("Quel symptôme peut être provoqué par le papillomavirus ?", new string[] { "Une prise de poids", "La myopie", "Des verrues génitales", "Des plaques rouges sur la peau" }, 3, "Les condylomes externes, aussi appelés verrues génitales ou « crêtes de coq » sont des excroissances indolores pouvant apparaître sur la verge, la vulve, autour du vagin ou de l’anus. Parfois, ils entraînent des démangeaisons, mais la plupart du temps ils restent silencieux. On les fait enlever car ce n’est pas très joli, mais en réalité ils ne sont pas dangereux. Ils peuvent parfois revenir après le traitement.");
     Question question2 = new Question("Comment améliorer l’efficacité d’un préservatif?", new string[] { "En choisir un adapté à sa taille", "Mettre 2 préservatifs", "Le pré-mâcher ", "Éviter les préservatifs normés NF" }, 3, "Un préservatif adapté à sa taille évitera qu’il glisse ou marque le pénis. Contrairement à ce qu’on pourrait penser, passer 2 préservatifs l’un sur l’autre augmente le risque qu’il de casse. La norme NF sur un préservatif renseigne un gage de qualité !");
        Question question3 = new Question("De quoi est constitué l'intérieur du pénis ?", new string[] { "De muscles", "De corps caverneux", "De sperme", "De bois" }, 2, "Le pénis est constitué de corps caverneux. Lors d’une érection, ces corps se remplissent de sang et font gonfler le pénis. Une érection peut-être provoquée lorsque l’individu est excité.");
        Question question4 = new Question("The penis is in the …", new string[] { "kitchen", "stadium", "pie", "condom" }, 4 ,"Sortez couverts !!!");
        questions = new List<Question>();
        questions.Add(question1);
        questions.Add(question2); questions.Add(question3); questions.Add(question4);
    }
    void HideallButtons()
    {
        for (int i = 1; i < 4; i++)
        {
            Button btn = buttons[i];
            btn.gameObject.SetActive(false);
        }
        buttons[0].GetComponentInChildren<TMP_Text>().text = "Continue";
    }
    void ShowallButtons()
    {
        for (int i = 1; i < 4; i++)
        {
            Button btn = buttons[i];
            btn.gameObject.SetActive(true);
        }
    }
    void TaskOnClick(string name)
    {
        Debug.Log("currenQuestionnb" + currenQuestionnb);
        
        int buttonnb = int.Parse(name.Remove(0, 6));
        if (buttonnb == 1 && buttons[0].GetComponentInChildren<TMP_Text>().text == "Continue")
        {
            if (wasCorrect)
            {   

                SceneManager.LoadScene(0);
            }
            ShowallButtons();
            maintext.fontSize = 20;
            changeTexts(currenQuestionnb);
            return;

        }
        Debug.Log("You have clicked the button " + name.Remove(0, 6));
        if (buttonnb == questions[currenQuestionnb-1].correctanswer)
        {
            Debug.Log("You Answered Correctly");
            Debug.Log(questions[currenQuestionnb-1].correctanswer);
            wasCorrect = true;
            maintext.text = "That was correct, let's continue the journey. \nPrecision:";
        }
        else
        {
            Debug.Log("You answered Wrongly");
            Debug.Log(questions[currenQuestionnb-1].correctanswer);
            maintext.text = "Oops that was wrong, Let's try again. \nPrecision:";
            


        }
        maintext.text += questions[currenQuestionnb - 1].precision;
        maintext.fontSize = 7;
        HideallButtons();






    }


    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        maintext = GetComponentInChildren<TMP_Text>();
    addMockQuestions();
        changeTexts(currenQuestionnb);

        for (int i = 0; i < 4; i++)
        {
            Button btn = buttons[i];
            btn.onClick.AddListener(() => TaskOnClick(btn.gameObject.name));
            
        }
        //btnValue();
    }

    
}
