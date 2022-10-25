using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public InputField InputField;
    string InputText;
    public SporeContainerController SporeContainerScript;

    void Start()
    {
        InputText = InputField.text;
        InputField.ActivateInputField();
        InputField.Select();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Clone();
        }
    }

    public void Clone()
    {
        print("button controller clone");
        InputText = InputField.text;
        InputField.text = "";
        InputField.ActivateInputField();
        InputField.Select();
        SporeContainerScript.GenerateGameObject(InputText);
    }
}
