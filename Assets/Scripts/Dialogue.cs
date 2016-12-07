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
        public bool optionAPlus;
        public float optionDelta;

        public DialogueMessage(string msg, string name_)
        {
            this.message = msg;
            this.name = name_;
            this.isDecision = false;
            optionA = "";
            optionB = "";
        }
        public DialogueMessage(string msg, string name_, string optionA_, string optionB_, bool isAGood, float decisionWeight)
        {
            this.message = msg;
            this.name = name_;
            this.isDecision = true;
            this.optionA = optionA_;
            this.optionB = optionB_;
            this.optionAPlus = isAGood;
            this.optionDelta = decisionWeight;
        }
    }

    List<DialogueMessage> messages_ = new List<DialogueMessage>();
    

    public Text mText;
    public Text mName;
    public Text buttonAText;
    public Text buttonBText;
    public GameManager gameManager;
    public string playerName;

    public Button buttonA, buttonB, nextButton;

    public void addDecision(string speaker, string msg, string OptA, string OptB, bool isAGood, float amountToChange)
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

            //deactive next
            nextButton.gameObject.SetActive(false);
        }

        messages_.Add(new DialogueMessage(msg, speaker, OptA, OptB, isAGood, amountToChange));
        
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

            //active next
            nextButton.gameObject.SetActive(true);
        }

        messages_.Add(new DialogueMessage(msg, speaker));
        
    }

    public void optionPicked(bool isA)
    {
        if (isA)
        {
            //set up dialogue to use the A stuff
            mText.text = messages_[0].optionA;
            mName.text = playerName;
            //player picked option A
            if (messages_[0].optionAPlus)
            {
                //option A was the good one
                gameManager.changeSituationValue(messages_[0].optionDelta);
            }else
            {
                //option A was the bad one
                gameManager.changeSituationValue(0 - messages_[0].optionDelta);
            }
        }
        else
        {
            //player picked option B
            mText.text = messages_[0].optionB;
            mName.text = playerName;
            //player picked option A
            if (messages_[0].optionAPlus)
            {
                //player picked the bad one
                gameManager.changeSituationValue(0 - messages_[0].optionDelta);
            }
            else
            {
                //player picked the good one
                gameManager.changeSituationValue(messages_[0].optionDelta);
            }
        }

        //update which buttons are active
        //deactivate buttons
        buttonA.gameObject.SetActive(false);
        buttonB.gameObject.SetActive(false);

        //active next
        nextButton.gameObject.SetActive(true);

    }

    public void nextMessage()
    {
        if (messages_.Count > 1)
        {
            mText.text = messages_[1].message;
            mName.text = messages_[1].name;

            //see if it is a decision
            if (messages_[1].isDecision)
            {
                //is decision, activate and set up buttons
                buttonAText.text = messages_[1].optionA;
                buttonBText.text = messages_[1].optionB;

                //activate buttons
                buttonA.gameObject.SetActive(true);
                buttonB.gameObject.SetActive(true);

                //deactive next
                nextButton.gameObject.SetActive(false);
            }
            else
            {
                //deactivate buttons
                buttonA.gameObject.SetActive(false);
                buttonB.gameObject.SetActive(false);

                //active next
                nextButton.gameObject.SetActive(true);
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
