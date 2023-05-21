using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest3 : Chest
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
        ans = op1 % op2;
        question = $"Solve: {op1} % {op2}";
        return question;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
