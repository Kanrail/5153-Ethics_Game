using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Random = UnityEngine.Random;

public class EthicsQuestionHandler : MonoBehaviour
{
    private Dictionary<string, List<string>> questionDict;
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

    string GetRandomQuestion()
    {
        int randomNum = Random.Range(1,questionDict.Count);
        return questionDict.ElementAt(randomNum).Key;
    }

    void SetAnswerButtons()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
