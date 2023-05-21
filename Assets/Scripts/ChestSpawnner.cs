using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawnner : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject[] chestType;
    List<GameObject> chestList = new List<GameObject>(); // gameObject is the datatype that list can store
    public static int chestCount;

    // agar list ko serialize karoge toh ese likhna padega:
    // [SerializeField] List<GameObject> chests;

    GameObject chest;

    void Start()
    {
        // we want to keep t he position of the chest as the spawnpoint and Quaternion.identity means that the rotation of the chest is 0f, 0f, 0f
        // spawnPoint.transform.GetChild(0).position ka mtlb hai ki spawnpoints ke 3 teen child hain toh 3 mai se jo first wala hai usko access karna hai

        int index = 0;

        for (int i = 0; i < spawnPoint.transform.childCount; i++)
        {
            // hum chah rhe hai ki randomly teeno spawnpoints mai koi bhi chest aa jaye
            index = Random.Range(0, 3);
            chest = Instantiate(chestType[index], spawnPoint.transform.GetChild(i).position, Quaternion.identity);
            // Instantiate function jitne bhi chest spawn karega woh chest variable woh store honge...ab uss chest variable ko humne add kiya hai chestList mai
            // mtlb ki chestList ke andar woh saari chest aa gyi hai jo spawn hui hain
            chestList.Add(chest);
        }

        chestCount = chestList.Count;
        Manager.ChestLeftBox.text = "Chest Left: " + chestCount.ToString();
        calculateDifficulty();

    }

    void calculateDifficulty()
    {
        float difficulty = 0;
        foreach (GameObject chesti in chestList)
        {
            difficulty = difficulty + chesti.GetComponent<Stats>().difficulty; // stats script ke andar jo dfficulty component hai usko access karna hai
        }
        difficulty = difficulty / (chestCount * 3); // actual mai 3 chests hain aur spawn 5 ko krwaya hai
        difficulty *= 100;
        Manager.difficultyBox.text = "Difficulty: " + difficulty.ToString("##.#") + "%"; // ##.# ka mtlb hai ki decimal ke baad ek se zyda value nhi aayegi such as 78.3%
    }
  
}
