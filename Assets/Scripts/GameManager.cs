using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float maxFieldValue = 5.0f;

    //public UIManager uiManager;

    private UIManager uiManager;
    private float publicPerceptionValue;
    private float situationValue;
    private float cityStatusValue;

    private int currEvent = 0;
    private int currDay = 1;
    int numOffInSection1 = 0;
    int numOffInSection2 = 0;
    int numOffInSection3 = 0;
    bool phoneOn = false;
    bool newsOn = true;

    string PlayerName = "Player";

    // Use this for initialization
    void Start () {
        publicPerceptionValue = 0.0f;
        situationValue = 0.0f;
        cityStatusValue = 1.0f;

        uiManager = this.GetComponent<UIManager>();

        //open up initial newspaper with officer assign screen behind
        
       // uiManager.setOfficerAssignActive(true);
        //uiManager.setNewspaperActive(true);
        uiManager.setNewspaperActive(true);
    }
	
	//public function for when player is finished with officer assignments
    public void nextEvent()
    {
        //print("starting the day");

        uiManager.closeUI();

        if (currDay == 1)
        {
            if (currEvent == 0)
            {
                //make the phone ring
                print("phone is ring");
                phoneOn = true;
            }
            else if (currEvent == 1)
            {
                //send the initial politican phone call
                uiManager.addDialogue("Politician", "Good morning Chief, a small group of young adults gathered this morning at Berkeley City Hall. They were holding up posters with 'Am I next?', 'Will You Shoot Me?' and others. They continuously chanted 'Hands up, don't shoot' which garnered attention and attracted crowds of people.");
                uiManager.addDialogue("Politician", "Currently, the protest appears peaceful but I can never predict these situations. ");
                uiManager.addDialogue("Politician", "Please send some men over.");

                uiManager.addDialogue(PlayerName, "They're on their way.");

                uiManager.addDialogue("Politician", "Thank you.");

            }
            else if (currEvent == 2)
            {
                //wait for the player to have time to read twitter and stuff
                Invoke("nextEvent", 5);

            } else if(currEvent == 3)
            {
                print("NEW phone ring");
                phoneOn = true;
            } else if( currEvent == 4)
            {
                uiManager.addDialogue("Officer", "Emergency chief! We have a 444 involving one of our own men. He was down at Berkeley City Hall and he took things into his own hands. He reported that the teenager fled the McDonald's at the sight of him. He held up his gun and chased him.");
                uiManager.addDialogue("Officer", "Unfortunately, he killed the teenager. The teenager fought back but I don't think...");
                uiManager.addDialogue("Officer", "I don't think shooting him was necessary...");

                uiManager.addDialogue(PlayerName, "Please remain alert officer.");

                uiManager.addDialogue("Officer", "Yes sir!");
            } else if(currEvent == 5)
            {
                //have the player assign officers between PR and patrol
                uiManager.setOfficerAssignActive(true);
            } else if(currEvent == 6)
            {
                //get stuff from the officer assignments
                numOffInSection1 = uiManager.getOfficersInArea(0); //patrol number
                numOffInSection2 = uiManager.getOfficersInArea(1); //PR number


                uiManager.addDialogue("Officer", "Mission report, Chief.");

                if (numOffInSection1 > numOffInSection2)
                {
                    //more officers on patrol
                    // BKPD Chief Declares Protest Peaceful
                    uiManager.addDialogue("Officer", "The protest shows no signs of aggression after the shooting. The two matters seem unrelated but further investigations are on their way. ");
                    uiManager.addDialogue("Officer", "With your permission, I will write off the protest as peaceful.");

                    uiManager.addDialogue(PlayerName, "Proceed.");

                }
                else
                {
                    //more officers on PR
                    //Police Union Threatens Protesters

                    uiManager.addDialogue("Officer", "With our current evidence, we found a connection between the shooting and the protest at City Hall. Protesters are threatening our officers on site, none of whom are related to the shooting. We're afraid this might lead to an increase in aggression.");
                    uiManager.addDialogue("Officer", "What should we do, Chief?");

                    uiManager.addDialogue(PlayerName, "If we see any suspicious behaviors, our priority is to secure the safety of the people. ");

                    uiManager.addDialogue("Officer", "Noted.");

                }
            }
            else
            {
                print("end day 1");
                currDay++;
                currEvent = -1;
            }
        } else if(currDay == 2)
        {
            //Day 2 events
        }

        //get officer assignments
        /*
        numOffInSection1 = uiManager.getOfficersInArea(0);
        numOffInSection2 = uiManager.getOfficersInArea(1);
        numOffInSection3 = uiManager.getOfficersInArea(2);
        */
        //get the current officer assignments
        currEvent++;
    }

    public void pickUpPhone()
    {
        //currently nothing to do when you are not being called directly
        if (phoneOn)
        {
            phoneOn = false;
            nextEvent();
        }
    }

    public void setNewspaperInactive()
    {
        uiManager.setNewspaperActive(false);
        if (newsOn)
        {
            nextEvent();
        }
    }


    /**
     * accessor functions for values
     **/
    public float getPublicPerceptionValue()
    {
        return publicPerceptionValue;
    }

    public float getSituationValue()
    {
        return situationValue;
    }

    public float getCityStatusValue()
    {
        return cityStatusValue;
    }

    /**
     * public method for changign public perception value
     * makes sure that value never leaves range
     * returns the new value
     */
    public float changePublicPerceptionValue(float delta)
    {
        publicPerceptionValue += delta;
        Mathf.Clamp(publicPerceptionValue, 0.0f, maxFieldValue);
        return publicPerceptionValue;
    }

    public float changeSituationValue(float delta)
    {
        situationValue += delta;
        Mathf.Clamp(situationValue, 0.0f, maxFieldValue);
        return situationValue;
    }

    public float changeCityStatusValue(float delta)
    {
        cityStatusValue += delta;
        Mathf.Clamp(cityStatusValue, 0.0f, maxFieldValue);
        return cityStatusValue;
    }
}
