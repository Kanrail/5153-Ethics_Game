using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Random = UnityEngine.Random;

public class EthicsQuestionHandler : MonoBehaviour
{
    private Dictionary<string, List<string>> questionDict;

    public Text QuestionTextLabel;

    public Text Answer1Label;

    public Text Answer2Label;

    public Text Answer3Label;

    public Text Answer4Label;
    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/EthicsQ Assets/Questions_Easy.txt";

        questionDict = new Dictionary<string, List<string>>();
        //StreamReader read = new StreamReader(path, true);
        string[] lines = System.IO.File.ReadAllLines(path);

        string question="";

        List<string> answerList = new List<string>();

        foreach (string line in lines)
        {
            char[] tempLineList = line.ToCharArray();
            string lineMinusDelim = tempLineList.Skip(1).ToString();
            if (tempLineList[0]=='*')
            {
                question = lineMinusDelim;
                questionDict.Add(question,answerList);
            }
            else if (tempLineList[0] == '-')
            {
                questionDict[question].Add(lineMinusDelim);
            }
            if (tempLineList[0] == '$')
            {
                questionDict[question].Add(lineMinusDelim);
            }

        }

    }

    private string GetRandomQuestion()
    {
        int randomNum = Random.Range(1,questionDict.Count);
        return questionDict.ElementAt(randomNum).Key;
    }

    public void SetAnswerButtons(string question)
    {
        QuestionTextLabel.text = question;
        Answer1Label.text = questionDict[question][0];
        Answer2Label.text = questionDict[question][1];
        Answer3Label.text = questionDict[question][2];
        Answer4Label.text = questionDict[question][3];
    }

    private bool CheckSelectedAnswer(string selectedAnswer, string question)
    {
        if (questionDict[question][5] != selectedAnswer)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void WinningAnswer()
    {

    }

    private void LosingAnswer()
    {

    }

    public void AnswerButtonClick(Button button)
    {
        string selectedAnswer = button.name;
        string question = QuestionTextLabel.text;
        bool correctAnswer = CheckSelectedAnswer(selectedAnswer, question);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
