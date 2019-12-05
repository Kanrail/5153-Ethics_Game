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
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EthicsQuestionHandler : MonoBehaviour
{
    private Dictionary<string, List<string>> questionDict;

    public Text QuestionTextLabel;

    public Text Answer1Label;

    public Text Answer2Label;

    public Text Answer3Label;

    public Text Answer4Label;

    private string SelectedQuestion;
    // Start is called before the first frame update
    void Start()
    {
        BuildQDict();
        SelectedQuestion = GetRandomQuestion();
        SetAnswerButtons();

    }

    private void BuildQDict()
    {
        string path = "Assets/EthicsQ Assets/Questions_Easy.txt";

        questionDict = new Dictionary<string, List<string>>();
        //StreamReader read = new StreamReader(path, true);
        string[] lines = System.IO.File.ReadAllLines(path);

        string question = "";

        List<string> answerList = new List<string>();

        foreach (string line in lines)
        {
            var firstChar = line.Substring(0, 1);
            string lineMinusDelim = line.Substring(1);
            if (firstChar == "#")
            {
                question = lineMinusDelim;
            }
            else if (firstChar == "-")
            {
                answerList.Add(lineMinusDelim);
            }
            if (firstChar == "$")
            {
                answerList.Add(lineMinusDelim);
                questionDict.Add(question, new List<string> { answerList[0], answerList[1], answerList[2], answerList[3], answerList[4] });
                answerList.Clear();
            }

        }
    }

    private string GetRandomQuestion()
    {
        int randomNum = Random.Range(1,questionDict.Count);
        return questionDict.ElementAt(randomNum).Key;
    }

    public void SetAnswerButtons()
    {
        QuestionTextLabel.text = SelectedQuestion;
        Answer1Label.text = questionDict[SelectedQuestion][0];
        Answer2Label.text = questionDict[SelectedQuestion][1];
        Answer3Label.text = questionDict[SelectedQuestion][2];
        Answer4Label.text = questionDict[SelectedQuestion][3];
    }

    private void CheckSelectedAnswer(string selectedAnswer)
    {
        if (questionDict[SelectedQuestion][4] != selectedAnswer)
        {
            SceneManager.LoadScene("EQuestionLScreen");
        }
        else
        {
            SceneManager.LoadScene("EQuestionWScreen");
        }
    }

    public void AnswerButtonClick(Button button)
    {
        string selectedButton = button.name;
        string selectedAnswer = "";
        switch (selectedButton)
        {
            case "Answer1Button":
                selectedAnswer = Answer1Label.text;
                break;
            case "Answer2Button":
                selectedAnswer = Answer2Label.text;
                break;
            case "Answer3Button":
                selectedAnswer = Answer3Label.text;
                break;
            default:
                selectedAnswer = Answer4Label.text;
                break;
        }

        CheckSelectedAnswer(selectedAnswer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
