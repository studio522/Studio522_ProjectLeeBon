using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SporeContainerController : MonoBehaviour
{
    public GameObject SporeGuideSetPrefab;
    //public string UserInput;

    public void GenerateGameObject(string UserInput)
    {
        print(UserInput);
        foreach (char c in UserInput)
        {
            GameObject Spore = Instantiate(SporeGuideSetPrefab);
            //Spore.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = c.ToString();
            Spore.transform.parent = gameObject.transform;
            GameObject TextMeshPro = Spore.transform.GetChild(1).GetChild(0).gameObject;
            //print(TextMeshPro.name);

            //string s = TextMeshPro.GetComponent<TextMeshPro>().text;
            //print("sss="+s);

            TextMeshPro.GetComponent<TextMeshPro>().text = c.ToString();

        }

    }

}
