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
//*******************************************************************
//                      EthicsQuestionHandler Class
//
//   Handles all of the button onclick events as well as building the
//   question dataset to populate the Ethics Question scene
//
//********************************************************************
public class EthicsQuestionHandler : MonoBehaviour
{
    private Dictionary<string, List<string>> _questionDict;

    public Text QuestionTextLabel;

    public Text Answer1Label;

    public Text Answer2Label;

    public Text Answer3Label;

    public Text Answer4Label;

    private string _selectedQuestion;

    //*******************************************************************
    //                    ObjectName:Start()
    //                    Parameters: N/A
    //
    //      Start is called before the first frame update, like a constructor
    //********************************************************************
    void Start()
    {
        BuildQDict();
        _selectedQuestion = GetRandomQuestion();
        SetAnswerButtons();

    }

    //*******************************************************************
    //                    ObjectName:BuildQDict()
    //                    Parameters: N/A
    //
    //      Builds the question dictionary with associated answers from the file in path.
    //      Dictionary is only stored locally
    //********************************************************************
    private void BuildQDict()
    {
        string path = "Assets/EthicsQ Assets/Questions_Easy.txt";

        _questionDict = new Dictionary<string, List<string>>();
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
                _questionDict.Add(question, new List<string> { answerList[0], answerList[1], answerList[2], answerList[3], answerList[4] });
                answerList.Clear();
            }

        }
    }

    //*******************************************************************
    //                    ObjectName:GetRandomQuestion()
    //                    Parameters: N/A
    //
    //      Randomly pulls a question from the dictionary and returns a string
    //      containing the question as the question acts as the key in the dictionary.
    //********************************************************************
    private string GetRandomQuestion()
    {
        int randomNum = Random.Range(1,_questionDict.Count);
        return _questionDict.ElementAt(randomNum).Key;
    }

    //*******************************************************************
    //                    ObjectName:SetAnswerButtons()
    //                    Parameters: N/A
    //
    //      Sets the Question and Answer labels to the associated question.
    //********************************************************************
    public void SetAnswerButtons()
    {
        QuestionTextLabel.text = _selectedQuestion;
        Answer1Label.text = _questionDict[_selectedQuestion][0];
        Answer2Label.text = _questionDict[_selectedQuestion][1];
        Answer3Label.text = _questionDict[_selectedQuestion][2];
        Answer4Label.text = _questionDict[_selectedQuestion][3];
    }

    //*******************************************************************
    //                    ObjectName:CheckSelectedAnswer()
    //                    Parameters: selectedAnswer (string)
    //
    //      Checks whether the supplied answer matches the correct answer for the question.
    //********************************************************************
    private void CheckSelectedAnswer(string selectedAnswer)
    {
        if (_questionDict[_selectedQuestion][4] != selectedAnswer)
        {
            SceneManager.LoadScene("EQuestionLScreen");
        }
        else
        {
            SceneManager.LoadScene("EQuestionWScreen");
        }
    }

    //*******************************************************************
    //                    ObjectName:BuildQDict()
    //                    Parameters: Button (object)
    //
    //      Handles the button onclick event, then calls CheckSelectedAnswer
    //      to see if it was the right answer
    //********************************************************************
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


    //*******************************************************************
    //                    ObjectName:Update()
    //                    Parameters: N/A
    //
    //      Update is called once per frame, was unnecessary, but required.
    //********************************************************************
    void Update()
    {
        
    }
}
