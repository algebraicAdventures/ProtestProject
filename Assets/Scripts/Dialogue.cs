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
        public float aChange;
        public float bChange;

        public DialogueMessage(string msg, string name_)
        {
            this.message = msg;
            this.name = name_;
            this.isDecision = false;
            optionA = "";
            optionB = "";
        }
        public DialogueMessage(string msg, string name_, string optionA_, string optionB_, float aChange, float bChange)
        {
            this.message = msg;
            this.name = name_;
            this.isDecision = true;
            this.optionA = optionA_;
            this.optionB = optionB_;
            this.aChange = aChange;
            this.bChange = bChange;
        }
        public DialogueMessage(string name, string aMsg, string bMsg)
        {
            this.name = name;
            this.message = "";
            this.optionA = aMsg;
            this.optionB = bMsg;
        }
    }

    List<DialogueMessage> messages_ = new List<DialogueMessage>();
    

    public Text mText;
    public Text mName;
    public Text buttonAText;
    public Text buttonBText;
    public GameManager gameManager;
    public string playerName;

    bool isA = true;

    public Button buttonA, buttonB, nextButton;

    public void addDecision(string speaker, string msg, string OptA, string OptB, float aChange, float bChange)
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

        messages_.Add(new DialogueMessage(msg, speaker, OptA, OptB, aChange, bChange));
        
    }

    public void addBranchingDialogue(string name, string aText, string bText)
    {
        //don't allow it to be the first thing
        messages_.Add(new DialogueMessage(name, aText, bText));

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

    public void optionPicked(bool optionA)
    {
        if (optionA)
        {
            //set up dialogue to use the A stuff
            mText.text = messages_[0].optionA;
            mName.text = playerName;
            //change by the A change amount
            gameManager.changeSituationValue(messages_[0].aChange);
            isA = true;
        }
        else
        {
            //player picked option B
            mText.text = messages_[0].optionB;
            mName.text = playerName;
            //player picked option A
            gameManager.changeSituationValue(messages_[0].bChange);

            isA = false;
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
            

            //see if it is a decision
            if (messages_[1].isDecision)
            {
                mText.text = messages_[1].message;
                mName.text = messages_[1].name;

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
                if(messages_[1].message == "")
                {
                    print("isA is " + isA);
                    //it's branching
                    if (isA)
                    {
                        mText.text = messages_[1].optionA;
                        mName.text = messages_[1].name;
                    }
                    else
                    {
                        mText.text = messages_[1].optionB;
                        mName.text = messages_[1].name;
                    }
                }
                else
                {
                    mText.text = messages_[1].message;
                    mName.text = messages_[1].name;
                }
                
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
