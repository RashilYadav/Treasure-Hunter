using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    // We made textbox static because we are having three chests, so there can be three textbox for three different chests, hence used static to avoid that!
    // When we are writing static, textBox is not visible in inspector but if we dont write static, its visible.
    // we use "static" keyword when we dont want to create copy of something.

    public static TMP_Text textBox;
    public static TMP_Text scoreBox;
    public static TMP_Text difficultyBox;
    public static TMP_Text ChestLeftBox;
    public static TMP_InputField answerBox;
    public static int answer;
    static int score;
    public static GameObject selectedChest;

    void Start()
    {
        // Here we want gameobject "Question" and inside that "Question" game ojectwe want TMP_text
        // hum chahte hain ki jab player chest jo touch kare toh jo puzzle hai woh hamare TMP_text par show ho
        textBox = GameObject.Find("Question").GetComponent<TMP_Text>();
        answerBox = GameObject.Find("AnswerInput").GetComponent<TMP_InputField>(); // TMP_InputField AnswerInput naam ke gameObject ke andar hai
        scoreBox = GameObject.Find("Score").GetComponent<TMP_Text>();
        difficultyBox = GameObject.Find("Difficulty").GetComponent<TMP_Text>();
        ChestLeftBox = GameObject.Find("ChestLeft").GetComponent<TMP_Text>();
        answerBox.gameObject.SetActive(false);
    }

   public static void askQuestion(string question)
    {
        textBox.text = question;
        answerBox.gameObject.SetActive(true); // by default "Enter Answer" wala box nhi dekhega hum ko
    }

    public void validateAnswer()
    {
        if(answerBox.text == answer.ToString())
        {
            updateScore();
            updateChestLeft();
            if (ChestSpawnner.chestCount == 0)
            {
                textBox.text = "You won!";
            }
            else
            {
                textBox.text = "Go to Next Chest";
            }
            answerBox.gameObject.SetActive(false); // mtlb ki jab hum answer de denge sahi, toh apme aap hi answerBox SetActive false ho jayega aur disappear ho jayega
            answerBox.text = "";
            Destroy(selectedChest);
        }
    }

    void updateScore()
    {
        // hum chah rhe hain ki jis chest ka sahi answer diya hai player ne, uss chest se jo reward mila hai woh score mai add ho jaye
        score = score + selectedChest.GetComponent<Stats>().reward;
        scoreBox.text = "Score: " + score;
    }

    void updateChestLeft()
    {
        ChestSpawnner.chestCount--;
        ChestLeftBox.text = "Chest Left: " + ChestSpawnner.chestCount.ToString();
    }
}
