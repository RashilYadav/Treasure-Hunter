using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField]
    protected int answer;

    // Protected keyword makes the variable accessible in the child classes
    [SerializeField]
    protected int range = 100;

    void Start()
    {
        
    }

    // before placing the "ref" keyword, range wasn't dependent on maxvalue, if maxValue's value was changed , it wasn't affecting "range" but after writing "ref" , range keyword's value is changing as maxValue's value has changed from 100 to 50!!!
    protected virtual string questionGenerator(in int maxValue, out int ans)
    {
        //string concat = "Hi there, " + num.ToString() + " " + var.ToString();
        //string interpolate = $"Hi there, {num} & {var}";
        //string formating = string.Format("Hello VR World, {0} {1} ",num,var); // 0th position there is num and on the 1th position there is var.
        //textBox.text = interpolate;

        // We want op1 and op2 to generate random values on their own , so that can be done with the following way:
        string question = "";
        //Debug.Log("Inside function before change " + maxValue);
        //maxValue = 50;
        //Debug.Log("/Inside function after change " + maxValue);

        // "out" aur "ref" bahot hadd tak same hain par unme main difference yeh hai ki "ref" mai ek hi baar value return hoti par "out" mai ek se zyada baar kar sakte hain, aur "out" mai jis variable ko out banaya hai usko function mai declare karna hi padta hai jabki ref mai esa nhi karna padta.  
        // "in" keyword agar likha ref ki jagah toh ese mai hum value change nhi kar payenge "maxvalue" ki iss function mai!!
        // before placing the "ref" keyword, range wasn't dependent on maxvalue, if maxValue's value was changed , it wasn't affecting "range" but after writing "ref" , range keyword's value is changing as maxValue's value has changed from 100 to 50!!!

        int op1 = Random.Range(1, maxValue);
        int op2 = Random.Range(1, maxValue);
        int toggle = Random.Range(1, 3);

        switch (toggle)
        {
            case 1:
                {
                    question = $"Solve: {op1} + {op2}";
                    ans = op1 + op2;
                    break;
                }

            case 2:
                {
                    question = $"Solve: {op1} - {op2}";
                    ans = op1 - op2;
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


    // OnCollisionEnter is a pre-defined function, whenever the player will come closer to the chest, the chest will open on its own.
    protected void OnCollisionEnter(Collision collision)
    {
        Manager.askQuestion(questionGenerator(in range, out answer));
        Manager.answer = answer;
        Manager.selectedChest = this.gameObject; // selectedChest is equal to the chest the player has currently collided to
        openChest();
    }

    void openChest()
    {
 
        // this.gameObject.transform.GetChild(2) ka matlab hai ki hamara player jiss chest ya fir gameobejct se collide kar rha hai uska child component!
 // aur GetChild ke andar 2 isliye hai kyuki hamara chest mai chest top hierarchy ke hisaab se 2 number pe aata hai agar indexing 0 se start hoti hai toh 
        Transform chestTopTransform = this.gameObject.transform.GetChild(2);

 // we are basically rotating the x-axis of the chest top so that it opens up and we are not changing any other axis.
        chestTopTransform.rotation = Quaternion.Euler(-90f, 0f, 0f);
    }
}
