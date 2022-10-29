using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserUnitContainerController : MonoBehaviour
{
    public GameObject UserUnitObject;
    GameObject UserUnit;

    public List<GameObject> Dandelions;

    Transform StopPoint;

    void Start()
    {
        print(Dandelions.Count);
        CloneUserUnit("æ»≥Á«œººø‰!!!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        CloneUserUnit("æ»≥Á«œººø‰!!!");
    }

    public void CloneUserUnit(string UserInputs)
    {
        UserUnit = Instantiate(UserUnitObject);
        //UserUnit = UserUnitObject;
        print("UserUnit:" + UserUnit.name);
        UserUnit.transform.SetParent(transform);

        //GameObject Dandelion = UserUnit.transform.Find("Dandelion").gameObject;
        int index = Random.Range(0, Dandelions.Count - 1);
        GameObject Dandelion = Instantiate(Dandelions[index]);
        //GameObject Dandelion = Dandelions[index];
        Dandelion.name = "Dandelion";
        Dandelion.transform.SetParent(UserUnit.transform);
        print("Dandelion:" + Dandelion.name);

        //GameObject DandelionOrigin = UserUnit.transform.Find("DandelionOrigin").gameObject;
        //Dandelion.transform.position = DandelionOrigin.transform.position;

        StopPoint = GameObject.Find("StopPoint").transform;
        print(StopPoint.name);

        float randomH = 5;
        float randomV = 2;
        Vector3 NewPos = StopPoint.position + Vector3.up * Random.Range(-randomV, randomV) + Vector3.right * Random.Range(-randomH, randomH);
        Dandelion.transform.position = NewPos;

        GameObject LettersContainer = UserUnit.transform.Find("LettersContainer").gameObject;
        print("LettersContainer:" + LettersContainer.name);
        
        GameObject LetterSetToClone = LettersContainer.transform.Find("LetterSet").gameObject;
        print("LetterSetToClone:" + LetterSetToClone.name);

        foreach (char c in UserInputs)
        {
            //GameObject LetterSet = Instantiate(UserUnit.transform.Find("LettersContainer/LetterSet(Clone)").gameObject);
            GameObject ClonedLetterSet = Instantiate(LetterSetToClone);
            ClonedLetterSet.transform.SetParent(LettersContainer.transform);
            GameObject Letter = ClonedLetterSet.transform.Find("Letter").gameObject;
            //print(Letter.name);

            //Letter.GetComponent<TextMeshPro>().text = c.ToString();
            //Letter.GetComponent<TextMeshPro>().fontSize = Random.Range(2.5f, 4.5f);
            //byte gray = (byte)Random.Range(0, 150);
            //byte alpha = (byte)Random.Range(150, 255);
            //Color32 C = new Color32(gray, gray, gray, alpha);
            //Letter.GetComponent<TextMeshPro>().color = C;

        }

        //LettersContainer.transform.Find("LetterSet").gameObject.SetActive(false);
        LetterSetToClone.SetActive(false);
    }
}
