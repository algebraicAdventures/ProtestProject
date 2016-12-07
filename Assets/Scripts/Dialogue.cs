using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    private class DialogueMessage
    {
        public string message;
        public string name;
        public bool isDecision;
        public string optionA;
        public string optionB;

        public DialogueMessage(string msg, string name_)
        {
            this.message = msg;
            this.name = name_;
            this.isDecision = false;
            optionA = "";
            optionB = "";
        }
        public DialogueMessage(string msg, string name_, string optionA_, string optionB_)
        {
            this.message = msg;
            this.name = name_;
            this.isDecision = true;
            this.optionA = optionA_;
            this.optionB = optionB_;
        }
    }

    List<DialogueMessage> messages_ = new List<DialogueMessage>();
    

    public Text mText;
    public Text mName;
    public Text buttonAText;
    public Text buttonBText;
    public GameManager gameManager;

    public Button buttonA, buttonB;

    public void addDecision(string speaker, string msg, string OptA, string OptB)
    {
        if (messages_.Count == 0)
        {
            mText.text = msg;
            mName.text = speaker;

            //set the buttons to be the correct things
            //buttonA.gameObject.GetComponent<Text>().text = OptA;
            //buttonB.gameObject.GetComponent<Text>().text = OptB;
            buttonAText.text = OptA;
            buttonBText.text = OptB;

            //activate buttons
            buttonA.gameObject.SetActive(true);
            buttonB.gameObject.SetActive(true);
        }

        messages_.Add(new DialogueMessage(msg, speaker, OptA, OptB));
        
    }

    public void addMessage(string speaker, string msg)
    {
        
        if(messages_.Count == 0)
        {
            mText.text = msg;
            mName.text = speaker;

            //deactivate buttons
            buttonA.gameObject.SetActive(false);
            buttonB.gameObject.SetActive(false);
        }

        messages_.Add(new DialogueMessage(msg, speaker));
        
    } 

    public void nextMessage()
    {
        if (messages_.Count > 1)
        {
            mText.text = messages_[1].message;
            mName.text = messages_[1].name;

            //see if it is a decision
            if (messages_[0].isDecision)
            {
                //is decision, activate and set up buttons
                buttonAText.text = messages_[1].optionA;
                buttonBText.text = messages_[1].optionB;

                //activate buttons
                buttonA.gameObject.SetActive(true);
                buttonB.gameObject.SetActive(true);

                //deactivate next button
            }
            else
            {
                //deactivate buttons
                buttonA.gameObject.SetActive(false);
                buttonB.gameObject.SetActive(false);

                //reactivate next button
            }

            messages_.RemoveAt(0);
        }

        else
        {
            //close dialogue
            gameObject.SetActive(false);
            messages_.RemoveAt(0);
            
            //make the next event occur
            gameManager.nextEvent();
            //transform.gameObject.SetActive(false);
        }
    }
	
}
