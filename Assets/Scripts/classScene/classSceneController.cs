﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class classSceneController : MonoBehaviour
{
    public GameObject textBox;
    public GameObject lucasPrompt;
    public Animator LucasAnimator;
    public Animator TeacherAnimator;
    public Text time;
    bool schoolsbeenOut;
    bool lucasSitting = true;
    float startTime;
    textBoxController textBoxScript;
    StreamReader SOreader;
    // Start is called before the first frame update
    void Start()
    {
        schoolsbeenOut = false;
        startTime = Time.time;
        LucasAnimator.SetBool("isSitting", true);

        textBoxScript = (textBoxController)textBox.GetComponent(typeof(textBoxController));
        SOreader = new StreamReader("Assets/Dialogue/SchoolsOut.txt");

    }

    // Update is called once per frame
    void Update()
    {
        if (schoolsbeenOut)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TeacherAnimator.SetTrigger("Disapear");
            }
        }

        if (!textBox.activeSelf)
        {
            if (lucasSitting)
            {
                lucasPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //stand up
                    LucasAnimator.SetBool("isSitting", false);
                    LucasAnimator.SetFloat("Speed", 0.5f);
                    lucasSitting = false;
                    lucasPrompt.SetActive(false);
                }
            }
            
        }

        

        if ((Time.time - startTime > 239.5) && (Time.time - startTime < 240.5 ))
        {
            time.text = "3:45";
            
        }
        else if ((Time.time - startTime > 209.5) && (Time.time - startTime < 210.5))
        {
            time.text = "3:44";
        }
        else if ((Time.time - startTime > 179.5) && (Time.time - startTime < 180.5))
        {
            time.text = "3:43";
        }
        else if ((Time.time - startTime > 119.9) && (Time.time - startTime < 121.5))
        {
            time.text = "3:42";

        }
        else if ((Time.time - startTime > 59.5) && (Time.time - startTime < 60.1))
        {
            time.text = "3:41";
            if (!schoolsbeenOut)
            {
                schoolsbeenOut = true;
                SchoolsOut();
            }
            
        }


        if (textBoxScript.characterName.text == "Teacher" && textBox.activeSelf)
        {
            TeacherAnimator.SetBool("isTalking", true);
        }
        else
        {
            TeacherAnimator.SetBool("isTalking", false); 
        }
        
    }

    void SchoolsOut()
    {
        textBox.SetActive(true);
        textBoxScript.reader = SOreader;
        textBoxScript.readNewLine();


        //run the textbox
    }
}
