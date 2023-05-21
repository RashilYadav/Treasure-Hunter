using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest2 : Chest
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override string questionGenerator(in int maxValue, out int ans)
    {
        string question = "";
        int op1 = Random.Range(1, maxValue);
        int op2 = Random.Range(1, maxValue);
        int toggle = Random.Range(1, 3);

        switch (toggle)
        {
            case 1:
                {
                    question = $"Solve: {op1} x {op2}";
                    ans = op1 * op2;
                    break;
                }

            case 2:
                {
                    question = $"Solve: {op1} / {op2}";
                    ans = op1 / op2;
                    break;
                }

            default:
                {
                    ans = 0;
                    break;
                }
        }

        return question;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
