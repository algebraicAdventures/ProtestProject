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
    bool cellOn = false;
    bool newsOn = true;
    public int twitterReadWaitTime = 3;

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

        /********
         * DAY 1
         ********/
        if (currDay == 1)
        {
            if (currEvent == 0)
            {
                //make the phone ring
                print("phone is ring");
                phoneOn = true;
                currEvent++;
            }
            else if (currEvent == 1)
            {
                //send the initial politican phone call
                uiManager.addDialogue("Politician", "Good morning Chief, a small group of young adults gathered this morning at Berkeley City Hall. They were holding up posters with 'Am I next?', 'Will You Shoot Me?' and others. They continuously chanted 'Hands up, don't shoot' which garnered attention and attracted crowds of people.");
                uiManager.addDialogue("Politician", "Currently, the protest appears peaceful but I can never predict these situations. ");
                uiManager.addDialogue("Politician", "Please send some men over.");

                uiManager.addDialogue(PlayerName, "They're on their way.");

                uiManager.addDialogue("Politician", "Thank you.");
                currEvent++;

            }
            else if (currEvent == 2)
            {
                //wait for the player to have time to read twitter and stuff
                Invoke("nextEvent", twitterReadWaitTime);
                currEvent++;

            } else if(currEvent == 3)
            {
                print("NEW phone ring");
                phoneOn = true;
                currEvent++;
            } else if( currEvent == 4)
            {
                uiManager.addDialogue("Officer", "Emergency chief! We have a 444 involving one of our own men. He was down at Berkeley City Hall and he took things into his own hands. He reported that the teenager fled the McDonald's at the sight of him. He held up his gun and chased him.");
                uiManager.addDialogue("Officer", "Unfortunately, he killed the teenager. The teenager fought back but I don't think...");
                uiManager.addDialogue("Officer", "I don't think shooting him was necessary...");

                uiManager.addDialogue(PlayerName, "Please remain alert officer.");

                uiManager.addDialogue("Officer", "Yes sir!");
                currEvent++;
            } else if(currEvent == 5)
            {
                //have the player assign officers between PR and patrol
                uiManager.setOfficerAssignActive(true);
                currEvent++;
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

                currEvent++;
            }
            else
            {
                print("end day 1");
                currDay++;
                currEvent = 0;

                //fade out then in then call nextEvent

                //fade screen to black
                print("pretend that I faded to black");
                //after fade, call the next event
                nextEvent();
            }
        }
        /********
         * DAY 2
         ********/
        else if (currDay == 2)
        {
            
            //day 2 events
            if(currEvent == 0)
            {
                //display newspaper
                uiManager.setNewspaperActive(true);
                newsOn = true;

                currEvent++;
            }
            else if(currEvent == 1)
            {
                //phone ring thing
                print("DAY 2 BIG RING RONG");
                phoneOn = true;
                currEvent++;
            } else if(currEvent == 2)
            {
                //Officer Reports Increasing Unrest at Formerly Declared 'Peaceful' Protest
                uiManager.addDialogue("Officer", "How's your morning going, Chief?");
                uiManager.addDialogue("Officer", "Well this morning, more people joined in on the protest and chants grow louder. The politician in Berkeley City Hall, who called yesterday, reports that the protest is a 'huge disruption to work'.");

                uiManager.addDialogue(PlayerName, "I'll see what I can do. ");

                currEvent++;
            } else if(currEvent == 3)
            {
                //officer assignment
                //may want to do something to activate third box in the thing
                uiManager.setOfficerAssignActive(true);
                currEvent++;

            } else if(currEvent == 4)
            {
                Invoke("nextEvent", twitterReadWaitTime);
                currEvent++;
            } else if(currEvent == 5)
            {
                //get officer assignment
                numOffInSection1 = uiManager.getOfficersInArea(0); //patrol number
                numOffInSection2 = uiManager.getOfficersInArea(1); //PR number
                numOffInSection3 = uiManager.getOfficersInArea(2); //respond to situation number

                if(numOffInSection3 >= numOffInSection2 && numOffInSection3 >= numOffInSection1)
                {
                    //Officer Who Shot Teenager Fired by Police Chief
                    //make phone ring
                    print("day 2 part 2 phone ring");
                    phoneOn = true;
                    currEvent++;
                } else if(numOffInSection2 >= numOffInSection3 && numOffInSection2 >= numOffInSection1)
                {
                    //Pregnant Woman Harassed by BKPD Officer
                    print("day 2 part 2 phone ring");
                    phoneOn = true;
                    currEvent++;
                }
                else
                {
                    //Police Union is Watching the Protest Carefully
                    //change newspaper display
                    print("changing newspaper to union watching protest carefully");

                    //make newspaper appear
                    uiManager.setNewspaperActive(true);
                    newsOn = true;

                    currEvent+=2;
                }
            }
            else if(currEvent == 6)
            {
                if (numOffInSection3 >= numOffInSection2 && numOffInSection3 >= numOffInSection1)
                {
                    //Officer Who Shot Teenager Fired by Police Chief
                    uiManager.addDialogue("Killer Officer", "You called for me Chief?");

                    uiManager.addDialogue(PlayerName, "For misconduct and acting on your own, I am releasing you.");
                }else
                {
                    uiManager.addDialogue("Officer", "Hey Chief. We're with the woman from Ferguson. New information is in, and it turns out she is pregnant. The groping was also caught on camera and she uses this evidence against the officer, but that doesn't stop the FPDE officer from verbally harassing her.");

                    uiManager.addDialogue(PlayerName, "Don't let your guard down.");

                }

                currEvent++;
            }else if(currEvent == 7)
            {

                //make phone ring again
                print("fast fast day 2 phone ring");
                phoneOn = true;
                currEvent++;
            } else if(currEvent == 8)
            {
                //make phone call depending on situation value
                if(situationValue < 2)
                {
                    //Politician Congratulates
                    uiManager.addDialogue("Politician", "I'm calling to thank you Chief. The noise level of the protest has died down significantly and I can finally focus on work.");

                    uiManager.addDialogue(PlayerName, "I'm glad to hear it.");
                }
                else
                {
                    //Officer Reports
                    uiManager.addDialogue("Officer", "Mission report, Chief.");
                    uiManager.addDialogue("Officer", "The protest remains loud and more people are joining in by the hour but no one has shown signs of aggression. We are doing our best in keeping the protest peaceful. ");

                    uiManager.addDialogue(PlayerName, "Thank you for your hard work.");
                }
                currEvent++;
            }
            else
            {
                //end day 2
                currDay++;
                currEvent = 0;

                //fade out then in then call nextEvent

                //fade screen to black
                print("pretend that I faded to black");
                //after fade, call the next event
                nextEvent();
            } 
        }
        /********
         * DAY 3
         ********/
        else if (currDay == 3)
        {
            if(currEvent == 0)
            {
                //set up start day 3 newspaper
                if(situationValue < 2)
                {
                    // Newly Documented Male Held at Gunpoint by Police
                }
                else
                {
                    //Cop Punches Woman But She Is Arrested for Assaulting a Police Officer or Cops Catch Thief Who Robbed A Family Run Fish and Bait Store
                }

                newsOn = true;
                uiManager.setNewspaperActive(true);
                currEvent++;
            } else if(currEvent == 1)
            {
                //make cell phone ring
                print("cell phone ring sound day 3");
                cellOn = true;
                currEvent++;
            } else if(currEvent == 2)
            {
                //Son Calls from Cell Phone
                uiManager.addDialogue("Son", "Hey dad? I saw the news a few days ago and... that guy that was shot... that was really close to where we live.");
                uiManager.addDialogue("Son", "I-I'm scared. Dad, guns are dangerous aren't they? The police have other weapons right? Why do they need guns? They just... they just end things too quickly--without giving the other person a chance to explain themselves.");
                uiManager.addDialogue("Son", "I don't think they're the answer...");

                uiManager.addDialogue(PlayerName, "Don't worry son, I'm taking care of it. Say hi to your mother for me.");

            }else if(currEvent == 3)
            {
                //wait time
                Invoke("nextEvent", twitterReadWaitTime);
                currEvent++;
            } else if(currEvent == 4)
            {
                if(situationValue < 3 && situationValue > 1)
                {
                    //Immigrants Join Peaceful Protest
                    //make desk phone
                    print("desk phone ring day 3 optional thing");
                    phoneOn = true;
                    currEvent++;
                }
                else
                {
                    currEvent += 2;
                }
            } else if(currEvent == 5)
            {
                //Immigrants Join Peaceful Protest
                uiManager.addDialogue("Officer", "Chief. Following earlier events, there have been an increase of immigrants joining the protest. They're chanting 'We are human too', 'Borders are lines drawn by racists' and etc. They don't appear aggressive but we are made to suspect that some of these people are illegal immigrants.");
                uiManager.addDialogue("Officer", "With your permission, we will ask them for papers.");

                uiManager.addDialogue(PlayerName, "Proceed.");

                uiManager.addDialogue("Officer", "Yes sir.");

                currEvent++;
            } else if(currEvent == 6)
            {
                //allocate officers
                uiManager.setOfficerAssignActive(true);
                currEvent++;
            } else if(currEvent == 7)
            {
                numOffInSection1 = uiManager.getOfficersInArea(0); //Write report
                numOffInSection2 = uiManager.getOfficersInArea(1); //PR number
                numOffInSection3 = uiManager.getOfficersInArea(2); //respond to situation number

                if(numOffInSection1 >= numOffInSection2 && numOffInSection1 >= numOffInSection3)
                {
                    //Police Union Issues a Statement Saying 'All Cops Are Not Murderers' 
                    //set up newspaper
                    //show paper
                    newsOn = true;
                    uiManager.setNewspaperActive(true);
                    currEvent += 2;
                }
                else
                {
                    //Are Guns the Problem? OR Group of Illegal Immigrants Arrested at Protest Site
                    print("asd desk phone ring");
                    phoneOn = true;
                    currEvent++;
                }
            } else if (currEvent == 8)
            {
                if(numOffInSection2 >= numOffInSection1 && numOffInSection2 >= numOffInSection3)
                {
                    //Group of Illegal Immigrants Arrested at Protest Site
                    uiManager.addDialogue("Officer", "Hello Chief. Upon further inspection, we found a group of illegal immigrants at the protest.");
                    uiManager.addDialogue("Officer", "They were asked for their papers and some refused, some tried to run and some fought back. We have arrested a handful of them and will continue to report back to you.");

                    uiManager.addDialogue(PlayerName, "Good work.");
                }
                else
                {
                    //Are Guns the Problem?
                    uiManager.addDialogue("Officer", "Yes Chief?");

                    uiManager.addDialogue(PlayerName, "It has come to my attention that we need to reinforce our training. We have batons, we have tasers, yet our first instinct is to reach for our guns.");
                    uiManager.addDialogue(PlayerName, "Especially with the recent events, we aren't giving the citizens a chance to redeem and explain themselves.");
                    uiManager.addDialogue(PlayerName, "We are not only the law, we are law abiders.");
                    uiManager.addDialogue(PlayerName, "Please send out a brief report to the other officers detailing the consequences of gun violence.");

                    uiManager.addDialogue("Officer", "I'm on it sir!");
                }
                currEvent++;
            } else if(currEvent == 9)
            {
                //event with son
                if(situationValue < 4)
                {
                    //Son Worries OR Son Thanks
                    //make cell phone call
                    print("bing new cell ring");
                    cellOn = true;
                    currEvent++;
                }
                else
                {
                    //Son Scolds
                    //make the new text and have the story advance when player closes cell phone
                    currEvent += 2;
                }
            } else if(currEvent == 10)
            {
                if(situationValue < 2)
                {
                    //Son Thanks
                    uiManager.addDialogue("Son", "Hey dad, it's me again. I guess I was just overthinking things again.");
                    uiManager.addDialogue("Son", "Thanks for considering what I said. It really means a lot.");

                    uiManager.addDialogue(PlayerName, "Anything for you, son.");

                    uiManager.addDialogue("Son", "You're the best, dad");
                }
                else
                {
                    //Son Worries
                    uiManager.addDialogue("Son", "Dad... I don't know if you made the right choice, but I hope you did. I want to trust you and your police officers. Mom says I should because she knows you better than anyone.");
                    uiManager.addDialogue("Son", "Please come home safe.");

                    uiManager.addDialogue(PlayerName, "Just trust me.");

                    uiManager.addDialogue("Son", "Alright...");
                }

                currEvent++;
            }
            else
            {
                //end of day 3
                currDay++;
                currEvent = 0;

                //fade out then in then call nextEvent

                //fade screen to black
                print("pretend that I faded to black");
                //after fade, call the next event
                nextEvent();
            }
        }
        /********
         * DAY 4
         ********/
        else if (currDay == 4)
        {
            if(currEvent == 0)
            {
                //open up newspaper for the day with correct info
                if(situationValue < 2)
                {
                    //Newly Documented Male Held at Gunpoint by Police

                } else if(situationValue < 4)
                {
                    //Cop Punches Woman But She Is Arrested for Assaulting a Police Officer or Cops Catch Thief Who Robbed A Family Run Fish and Bait Store
                } else
                {
                    //Unarmed White Teenager Shot by Police
                }
                newsOn = true;
                uiManager.setNewspaperActive(true);
                currEvent++;
            } else if(currEvent == 1)
            {
                //recieve text from daughter
                print("daughter text");
            } else if (currEvent == 2)
            {
                //give player wait time
                Invoke("nextEvent", twitterReadWaitTime);
                currEvent++;
            } else if (currEvent == 3)
            {
                if(situationValue < 4 && situationValue > 2)
                {
                    //make phone ring for Cop Stuns Pregnant Woman With Taser
                    print("day 4 phone ring");
                    phoneOn = true;
                    currEvent++;
                }
                else
                {
                    currEvent += 2;
                }
            } else if(currEvent == 4)
            {
                //Cop Stuns Pregnant Woman With Taser
                uiManager.addDialogue("Officer", "Situation report, Chief. The protest continues to grow uneasy and louder. Officers on site are on standby, but one officer was insulted and he tases a pregnant woman. She was unconscious for a few seconds but she has calmed down since then.");
                uiManager.addDialogue("Officer", "After that, there were no further disruptions.");

                uiManager.addDialogue(PlayerName, "I'm glad you guys have the situation under control.");
            } else if(currEvent == 5)
            {
                //allocate officers
                uiManager.setOfficerAssignActive(true);
                currEvent++;

            } else if(currEvent == 6)
            {
                numOffInSection1 = uiManager.getOfficersInArea(0); //Write report number
                numOffInSection2 = uiManager.getOfficersInArea(1); //PR number
                numOffInSection3 = uiManager.getOfficersInArea(2); //respond to situation number

                if(numOffInSection1 > numOffInSection2 && numOffInSection1 > numOffInSection3)
                {
                    //BKPD Reports That Officers Will Use Weapons if Provoked - Nothing New
                    //newspaper setup
                    newsOn = true;
                    uiManager.setNewspaperActive(true);
                    currEvent+=2;
                }
                else if(numOffInSection2 > numOffInSection1 && numOffInSection2 > numOffInSection3)
                {
                    //Woman Punched By BKPD Officer Arrested Again
                    //phone call
                    print("day 4 phone 2 ring");
                    phoneOn = true;
                    currEvent++;
                }
                else
                {
                    //Police Officer Fired for Misconduct
                    //newspaper
                    newsOn = true;
                    uiManager.setNewspaperActive(true);
                    currEvent += 2;
                }
            }else if (currEvent == 7)
            {
                //Woman Punched By BKPD Officer Arrested Again
                uiManager.addDialogue("Officer", "Hey Chief, I'm down at the station right now and we're in a pickle.");
                uiManager.addDialogue("Officer", "The woman arrested was being uncooperative and verbally aggressive. We had to take physical control of her and she fought with one of our men. He has a slight bruise but we're holding her for another 48 hours to see if she wants to cooperate then.");

                uiManager.addDialogue(PlayerName, "Stay on guard.");

                uiManager.addDialogue("Officer", "Yes sir!");

                currEvent++;
            } else if(currEvent == 8)
            {
                //daughter interaction depending on situation level
                if(situationValue < 2)
                {
                    //Daughter Thanks
                    currEvent += 2;
                } else if(situationValue < 4)
                {
                    //Daughter Worries
                    currEvent += 2;
                }
                else
                {
                    //Daughter Scolds
                    //cell call
                    print("end day 4 cell call xDDD");
                    cellOn = true;
                    currEvent++;

                }
            }else if(currEvent == 9)
            {
                //Daughter scolds
                uiManager.addDialogue("Daughter", "Dad! What are you doing?? You're in charge of the police officers right? These guys are supposed to be keeping us safe!");
                uiManager.addDialogue("Daughter", "My friend knew that woman and now her family is getting harassed every time they leave the house.");
                uiManager.addDialogue("Daughter", "How could you do this?");

                uiManager.addDialogue(PlayerName, "I'm doing what's best for everyone.");

                uiManager.addDialogue("Daughter", "Well, try harder!");
            }
            else
            {
                //end day 4
                currDay++;
                currEvent = 0;

                //fade out then in then call nextEvent

                //fade screen to black
                print("pretend that I faded to black");
                //after fade, call the next event
                nextEvent();
            }
        }
        /********
         * DAY 4
         ********/
        else if (currDay == 5)
        {

        }
        
    }


    public void pickUpCell()
    {
        //currently nothing to do when you are not being called directly
        if (cellOn)
        {
            cellOn = false;
            nextEvent();
        }
        else
        {
            uiManager.activateCellphone();
        }
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
            newsOn = false;
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
