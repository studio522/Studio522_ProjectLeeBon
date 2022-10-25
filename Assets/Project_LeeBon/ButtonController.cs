using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class ButtonController : MonoBehaviour
{
    public InputField InputField;
    string InputText;
    public SporeContainerController SporeContainerScript;

    SerialPort Arduino;
    //string portName = "COM5";
    string portName = "/dev/cu.usbmodem14201";
    string SerialIn = null;

    void Start()
    {
        InputText = InputField.text;
        InputField.ActivateInputField();
        InputField.Select();

        string[] ports = SerialPort.GetPortNames();

        foreach (string port in ports)
        {
            print(port);
        }
        Arduino = new SerialPort(portName.ToString(), 9600);
        Arduino.Open();
        Arduino.ReadTimeout = 1000; //milliseconds
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Clone();
        }

        if (Arduino.IsOpen)
        {
            try
            {
                SerialIn = Arduino.ReadLine();
                print("raw:" + SerialIn);
                if (SerialIn != null)
                {
                    SerialIn = SerialIn.Trim();
                    print("trimmed:" + SerialIn);
                    if (SerialIn == "Y")
                    {
                        print("got Y");
                        Clone();
                    }
                }
            }
            catch (Exception e)
            {
                print(e);
            }
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

    void OnApplicationQuit()
    {
        Arduino.Close();
    }
}
