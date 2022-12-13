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
    string portName = "COM5";
    //string portName = "/dev/cu.usbmodem14201";
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
                    //print("trimmed:" + SerialIn);
                    if (SerialIn == "1")
                    {
                        print("got 1");
                        Clone();

                    }
                }
            }
            catch (Exception e)
            {
                print(e);
            }
            Arduino.Write("*");
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

/*************************************************
 * Arduino

int sensorPin = A0;
int threshold = 20;
int sensorValue, pSensorValue;
bool activateTimer = false;
int timeStarted, timeNow, timePassed, timeLimit = 2; //<--adjust!!!

void setup() {
  Serial.begin(9600);
}

void loop() {
  int value = analogRead(sensorPin);
  if (value > threshold) {
    sensorValue = 1;
  } else {
    sensorValue = 0;
  }

  int serialOut = 0;
  if (sensorValue == 1 && activateTimer == false) {
    if (pSensorValue == 0) {
      serialOut = 1;
      //Serial.println("Timer Start **********************************");
      activateTimer = true;
      timeStarted = millis() / 1000;
      //Serial.println("timeStarted");
      Serial.println(serialOut);
      //delay(20);
      serialOut = 0;
    }
  }
  pSensorValue = sensorValue;

  if (activateTimer) {
    timeNow = millis() / 1000;
    timePassed = timeNow - timeStarted;
    if (timePassed > timeLimit) {
      //Serial.println("Timer Stop ---------------------------");
      activateTimer = false;
    }
  }

  if (Serial.available()) {
    char c = Serial.read();
    Serial.println(serialOut);
    //delay(20);
  }
}
*************************************************/
