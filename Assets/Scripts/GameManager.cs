using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float maxFieldValue = 5.0f;
    public int twitterReadWaitTime = 3;
    public AudioSource desktopPhone;
    public AudioSource cellText;
    public AudioSource cellRing;

    public Sprite[] newspapers;

    public Sprite[] Texts;

    //public UIManager uiManager;

    //private AudioSource ring;

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
    bool textOn = false;

    bool haveUsedPunchWoman = false;
    bool haveUsedTeenRaiseGun = false;
    

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

        //uiManager.closeUI();
        uiManager.setOfficerAssignActive(false);

        /********
         * DAY 1
         ********/
        if (currDay == 1)
        {
            if (currEvent == 0)
            {
                //make the phone ring
                print("phone is ring");

                //ring.Play();
                desktopPhone.Play();
                phoneOn = true;
                currEvent++;
            }
            else if (currEvent == 1)
            {
                //testing, please remove
                //uiManager.addDecision("me", "hello decision", "yes", "no");
                //send the initial politican phone call
                uiManager.addDialogue("Politician", "Good morning Chief, a small group of young adults gathered this morning at Berkeley City Hall. They were holding up posters with 'Am I next?', 'Will You Shoot Me?' and others. They continuously chanted 'Hands up, don't shoot' which garnered attention and attracted crowds of people.");
                uiManager.addDialogue("Politician", "Currently, the protest appears peaceful but I can never predict these situations. ");
                //uiManager.addDialogue("Politician", "Please send some men over.");
                uiManager.addDecision("Politician", "Please send some men over.", "There's no need to send men over.", "They're on their way.", 0.5f, -0.5f);


                //uiManager.addDialogue(PlayerName, "They're on their way.");

                //uiManager.addDialogue("Politician", "Thank you.");
                uiManager.addBranchingText("Politician", "If you think so, chief", "Thank you");
                currEvent++;

            }
            else if (currEvent == 2)
            {
                //wait for the player to have time to read twitter and stuff
                Invoke("nextEvent", twitterReadWaitTime);
                currEvent++;

            } else if(currEvent == 3)
            {
                desktopPhone.Play();
                phoneOn = true;
                currEvent++;
            } else if( currEvent == 4)
            {
                uiManager.addDialogue("Officer", "Emergency chief! We have a 444 involving one of our own men. He was down at Berkeley City Hall and he took things into his own hands. He reported that the teenager fled the McDonald's at the sight of him. He held up his gun and chased him.");
                uiManager.addDialogue("Officer", "Unfortunately, he killed the teenager. The teenager fought back but I don't think...");
                //uiManager.addDialogue("Officer", "I don't think shooting him was necessary...");
                uiManager.addDecision("Officer", "I don't think shooting him was necessary...", "It was the only thing he could do in that situation.", "Please remain alert officer.", 0.5f, -0.05f);

                //uiManager.addDialogue(PlayerName, "Please remain alert officer.");

                //uiManager.addDialogue("Officer", "Yes sir!");
                uiManager.addBranchingText("Officer", "I... I guess", "Yes sir!");
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
                    //uiManager.addDialogue("Officer", "With your permission, I will write off the protest as peaceful.");
                    uiManager.addDecision("Officer", "With  your permission, I will write off the protest as peaceful.", "Proceed", "Let's hold off", 0.05f, 0.15f);

                    uiManager.addDialogue(PlayerName, "Proceed.");

                }
                else
                {
                    //more officers on PR
                    //Police Union Threatens Protesters

                    uiManager.addDialogue("Officer", "With our current evidence, we found a connection between the shooting and the protest at City Hall. Protesters are threatening our officers on site, none of whom are related to the shooting. We're afraid this might lead to an increase in aggression.");
                    //uiManager.addDialogue("Officer", "What should we do, Chief?");
                    uiManager.addDecision("Officer", "What should we do Chief?", "Our priority is to secure the safety of the people.", "Do what you need to keep our people safe", -0.4f, 0.5f);

                    //uiManager.addDialogue(PlayerName, "If we see any suspicious behaviors, our priority is to secure the safety of the people. ");

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
                //update newspaper
                uiManager.updateNewspaper(newspapers[0]);
                //display newspaper
                uiManager.setNewspaperActive(true);
                newsOn = true;

                currEvent++;
            }
            else if(currEvent == 1)
            {
                //phone ring thing
                desktopPhone.Play();
                phoneOn = true;
                currEvent++;
            } else if(currEvent == 2)
            {
                //Officer Reports Increasing Unrest at Formerly Declared 'Peaceful' Protest
                uiManager.addDialogue("Officer", "How's your morning going, Chief?");
                //uiManager.addDialogue("Officer", "Well this morning, more people joined in on the protest and chants grow louder. The politician in Berkeley City Hall, who called yesterday, reports that the protest is a 'huge disruption to work'.");
                uiManager.addDecision("Officer", "Well this morning, more people joined in on the protest and chants grow louder. The politician in Berkeley City Hall, who called yesterday, reports that the protest is a 'huge disruption to work'.", "Tell him to wear earplugs", "I'll see what I can do", -0.05f, +0.05f);

                //uiManager.addDialogue(PlayerName, "I'll see what I can do. ");
                uiManager.addBranchingText("Officer", "Sir...", "Thank you so much.");

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
                    desktopPhone.Play();
                    currEvent++;
                } else if(numOffInSection2 >= numOffInSection3 && numOffInSection2 >= numOffInSection1)
                {
                    //Pregnant Woman Harassed by BKPD Officer
                    print("day 2 part 2 phone ring");
                    phoneOn = true;
                    desktopPhone.Play();
                    currEvent++;
                }
                else
                {
                    //Police Union is Watching the Protest Carefully
                    //change newspaper display
                    uiManager.updateNewspaper(newspapers[1]);

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
                    //uiManager.addDialogue("Officer", "Hey Chief. We're with the woman from Ferguson. New information is in, and it turns out she is pregnant. The groping was also caught on camera and she uses this evidence against the officer, but that doesn't stop the FPDE officer from verbally harassing her.");
                    uiManager.addDecision("Officer", "Hey Chief. We're with the woman from Ferguson. New information is in, and it turns out she is pregnant. The groping was also caught on camera and she uses this evidence against the officer, but that doesn't stop the FPDE officer from verbally harassing her.", "Don't let your guard down", "I would've fired him if I was his chief", -0.05f, +0.7f);
                    //uiManager.addDialogue(PlayerName, "Don't let your guard down.");

                }

                currEvent++;
            }else if(currEvent == 7)
            {

                //make phone ring again
                print("fast fast day 2 phone ring");
                phoneOn = true;
                desktopPhone.Play();
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
                    uiManager.updateNewspaper(newspapers[2]);
                }
                else
                {
                    //Cop Punches Woman But She Is Arrested for Assaulting a Police Officer or Cops Catch Thief Who Robbed A Family Run Fish and Bait Store
                    uiManager.updateNewspaper(newspapers[3]);
                    haveUsedPunchWoman = true;
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
                //uiManager.addDialogue("Son", "I don't think they're the answer...");
                uiManager.addDecision("Son", "I don't think they're the answer...", "You've never felt the power of holding a gun.", " Don't worry son, I'm taking care of it. Say hi to your mother for me. ", +1, -0.1f);

                //uiManager.addDialogue(PlayerName, "Don't worry son, I'm taking care of it. Say hi to your mother for me.");

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
                    phoneOn = true;
                    desktopPhone.Play();
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
                    //show paper
                    uiManager.updateNewspaper(newspapers[4]);
                    newsOn = true;
                    uiManager.setNewspaperActive(true);
                    currEvent += 2;
                }
                else
                {
                    //Are Guns the Problem? OR Group of Illegal Immigrants Arrested at Protest Site
                    print("asd desk phone ring");
                    phoneOn = true;
                    desktopPhone.Play();
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
                    uiManager.updateCellImage(Texts[3]);
                    textOn = true;
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
                    uiManager.updateNewspaper(newspapers[2]);

                } else if(situationValue < 4)
                {
                    
                    if (haveUsedPunchWoman)
                    {
                        //Cops Catch Thief Who Robbed A Family Run Fish and Bait Store
                        uiManager.updateNewspaper(newspapers[5]);
                    }
                    else
                    {
                        //Cop Punches Woman But She Is Arrested for Assaulting a Police Officer
                        uiManager.updateNewspaper(newspapers[3]);
                    }
                } else
                {
                    //Unarmed White Teenager Shot by Police
                    uiManager.updateNewspaper(newspapers[6]);
                }
                newsOn = true;
                uiManager.setNewspaperActive(true);
                currEvent++;
            } else if(currEvent == 1)
            {
                //recieve text from daughter
                textOn = true;
                uiManager.updateCellImage(Texts[0]);
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
                    desktopPhone.Play();
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
                    uiManager.updateNewspaper(newspapers[19]);
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
                    desktopPhone.Play();
                    currEvent++;
                }
                else
                {
                    //Police Officer Fired for Misconduct
                    //newspaper
                    uiManager.updateNewspaper(newspapers[7]);
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
                    textOn = true;
                    uiManager.updateCellImage(Texts[1]);
                    currEvent += 2;
                } else if(situationValue < 4)
                {
                    //Daughter Worries
                    textOn = true;
                    uiManager.updateCellImage(Texts[2]);
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
                //uiManager.addDialogue("Daughter", "How could you do this?");
                uiManager.addDecision("Daughter", "How could you do this?", "I'm trying to doing what's best for everyone", "At least it's not us", -0.5f, +1.0f);

                //uiManager.addDialogue(PlayerName, "I'm doing what's best for everyone.");

                //uiManager.addDialogue("Daughter", "Well, try harder!");
                uiManager.addBranchingText("Daughter", "Well, try harder!", "How can you even say that!");
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
         * DAY 5
         ********/
        else if (currDay == 5)
        {
            if(currEvent == 0)
            {
                //set up newspaper for day
                if(situationValue < 2)
                {
                    //BKPD Officers Currently Investigating Alleged Theft
                    uiManager.updateNewspaper(newspapers[8]);
                } else if(situationValue < 4)
                {
                    //Teen Raised Gun Before Officer Shot Him or  Protest Diffuses After Chief Tightens Security
                    uiManager.updateNewspaper(newspapers[9]);
                    haveUsedTeenRaiseGun = true;
                } else
                {
                    //FPDE Officer Fatally Shoots a 60-Year-Old Woman
                    uiManager.updateNewspaper(newspapers[10]);
                }
                //activate newspaper
                newsOn = true;
                uiManager.activateNewspaper();
                currEvent++;
            } else if(currEvent == 1)
            {
                //Officer call from desk phone
                //start call
                print("start of D5 phone");
                phoneOn = true;
                desktopPhone.Play();
                currEvent++;

            } else if(currEvent == 2)
            {
                //Officer call from desk phone
                uiManager.addDialogue("Officer", "Hey Chief. How's it going? Things are starting to look pretty busy around here.");
                uiManager.addDialogue("Officer", "Aside from Ferguson, Berkeley is getting a lot more visitors--press people, criminals, investigators, you name it.");
                //uiManager.addDialogue("Officer", "You're going to have to make a lot of tough decisions around here. But the guys and I on the force are always on our guards.");

                uiManager.addDecision("Officer", "You're going to have to make a lot of tough decisions around here. But the guys and I on the force are always on our guards.", "Thank you for trusting me.", "If things get tough, I'll just flip a coin.", -0.05f, 0.8f);

                uiManager.addBranchingText("Officer", "Of course sir", "Chief, I don't think that's a good idea.");

                currEvent++;
            } else if(currEvent == 3)
            {
                //wait time
                Invoke("nextEvent", twitterReadWaitTime);
                currEvent++;
            } else if(currEvent == 4)
            {
                if(situationValue < 5 && situationValue> 3)
                {
                    //Peaceful Protest Turns Violent As protesters Are Seen With Weapons
                    //phone call setup
                    print("Phone ring for violence");
                    phoneOn = true;
                    desktopPhone.Play();
                    currEvent++;
                }else
                {
                    currEvent += 2;
                }
            } else if(currEvent == 5)
            {
                //Peaceful Protest Turns Violent As protesters Are Seen With Weapons
                uiManager.addDialogue("Officer", "Hello Chief. This morning, formerly unarmed protesters arrive on site with pocket knives and switchblades to protect themselves. However, because of an increase in weapons, there are fewer protesters than usual. Officers are on standby and it doesn't appear as if the protesters are actively looking to harm anyone.");

                uiManager.addDialogue(PlayerName, "Keep your eyes out");
                currEvent++;
            } else if(currEvent == 6)
            {
                //player allocations
                uiManager.setOfficerAssignActive(true);
                currEvent++;
            } else if(currEvent == 7)
            {
                //get values
                numOffInSection1 = uiManager.getOfficersInArea(0); //Write report number
                numOffInSection2 = uiManager.getOfficersInArea(1); //PR number
                numOffInSection3 = uiManager.getOfficersInArea(2); //respond to situation number

                if(numOffInSection1 >= numOffInSection2 && numOffInSection1>= numOffInSection3)
                {
                    //Chief of Police Issues a Statement Regarding Police Brutality
                    uiManager.updateNewspaper(newspapers[12]);
                    //make newspaper active
                    newsOn = true;
                    uiManager.activateNewspaper();
                    currEvent += 2;
                } else if(numOffInSection2 >= numOffInSection1 && numOffInSection2 >= numOffInSection3)
                {
                    //Teenager's Family Questions Silence
                    //start call
                    //print("teen family sad call start");
                    phoneOn = true;
                    desktopPhone.Play();
                    currEvent++;
                }
                else
                {
                    //BKPD Officer Stabbed by Several Protesters at Berkeley City Hall

                    //make newspaper active
                    uiManager.updateNewspaper(newspapers[11]);
                    newsOn = true;
                    uiManager.activateNewspaper();
                    currEvent+=2;
                }
            } else if(currEvent == 8)
            {
                //Teenager's Family Questions Silence
                uiManager.addDialogue("Officer", "Hello? The family of the teenager from this morning wants us to continue the investigation on the death of their son.");
                //uiManager.addDialogue("Officer", "They are claiming that the case was dismissed too early and requests that we continue until we find definitive proof and ask that we at least give them the name of the officer who shot him.");
                uiManager.addDecision("Officer", "They are claiming that the case was dismissed too early and requests that we continue until we find definitive proof and ask that we at least give them the name of the officer who shot him.", "I'll consider it", "I'll look into it", -0.05f, 0.05f);

                currEvent++;
            } else if(currEvent == 9)
            {
                //make phone call
                print("end of day 5 call");
                phoneOn = true;
                desktopPhone.Play();
                currEvent++;
            } else if(currEvent == 10)
            {
                if(situationValue < 2)
                {
                    //officer congratulations
                    uiManager.addDialogue("Officer", "Good work today, most of the noise has died down.");
                    uiManager.addDialogue("Officer", "I'll keep you posted.");

                    uiManager.addDialogue(PlayerName, "Thanks for the update.");

                    uiManager.addDialogue("Officer", "Of course");

                } else if(situationValue < 4)
                {
                    //Officer reports
                    uiManager.addDialogue("Officer", "It looks like things will stay the same for a while. I'm not sure how things are looking right now.");
                    uiManager.addDialogue("Officer", "Everyone's scared, scared of what's yet to come and the things that happened.");
                    uiManager.addDialogue("Officer", "I'm starting to question if we're actually doing justice for our people.");
                }
                else
                {
                    //Mayor calls
                    uiManager.addDialogue("Mayor", "I'm cutting straight to the point--things are getting out of hand. Chief you need to focus. You're not the one out there dealing with the people directly and your men are facing the consequences.");
                    uiManager.addDialogue("Mayor", "They are serving our city, our country, our people.");
                    uiManager.addDialogue("Mayor", "If you can't focus, I'll have to replace you.");
                    uiManager.addDialogue("Mayor", "...");
                    uiManager.addDialogue("Mayor", "I'm sending some more men over to you tomorrow morning.");

                    uiManager.addDialogue(PlayerName, "Thank you for entrusting your men to me. I'll try to refocus.");

                    uiManager.addDialogue("Mayor", "Good.");
                }

                currEvent++;
            }
            else
            {
                //end day 5
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
         * DAY 6
         ********/
        else if (currDay == 6)
        {
            if (currEvent == 0)
            {
                //newspaper based on situation
                if(situationValue < 2)
                {
                    //BKPD Officers Further Investigate Alleged Theft
                    uiManager.updateNewspaper(newspapers[13]);

                } else if(situationValue < 4)
                {
                    //Teen Raised Gun Before Officer Shot Him or  Protest Diffuses After Chief Tightens Security
                    if (haveUsedTeenRaiseGun)
                    {
                        //Protest Diffuses After Chief Tightens Security
                        uiManager.updateNewspaper(newspapers[14]);
                    }
                    else
                    {
                        //Teen Raised Gun Before Officer Shot Him
                        uiManager.updateNewspaper(newspapers[9]);
                    }

                }
                else
                {
                    //Mayor of St. Louis Allocates More Officers to Quell Protest
                    uiManager.updateNewspaper(newspapers[15]);
                }
                //activate newspaper

                newsOn = true;
                uiManager.activateNewspaper();
                currEvent++;
            } else if(currEvent == 1)
            {
                //cell phone call
                print("wife cell call start 6");
                cellOn = true;
                currEvent++;
            } else if(currEvent == 2)
            {
                //Wife calls from cell phone
                uiManager.addDialogue("Wife", "Honey, you looked upset this morning. I was busy with lunch so I couldn't ask but I hope things are alright?");
                uiManager.addDialogue("Wife", "I know with the protest down at City Hall and the crimes around the city, you are very stressed. But the city needs you now more than ever.");
                //uiManager.addDialogue("Wife", "Take care of yourself before you take on the fate of thousands of people ok? ");
                uiManager.addDecision("Wife", "Take care of yourself before you take on the fate of thousands of people ok?", "I'll be fine, thanks honey", "I just need some Advil", 0.05f, -0.05f);

                //uiManager.addDialogue(PlayerName, "I'll be fine, thanks honey.");

                //uiManager.addDialogue("Wife", "I love you, bye. ");
                uiManager.addBranchingText("Wife", "I love you, bye.", "Take a box with you next time");

                currEvent++;
            } else if(currEvent == 3)
            {
                //wait for tweets, etc.
                //give player wait time
                Invoke("nextEvent", twitterReadWaitTime);
                currEvent++;
            } else if (currEvent == 4)
            {
                //allocate officers
                uiManager.setOfficerAssignActive(true);
                currEvent++;

            } else if(currEvent == 5)
            {
                numOffInSection1 = uiManager.getOfficersInArea(0); //Write report number
                numOffInSection2 = uiManager.getOfficersInArea(1); //PR number
                numOffInSection3 = uiManager.getOfficersInArea(2); //respond to situation number

                if(numOffInSection1 >= numOffInSection2 && numOffInSection1 >= numOffInSection3)
                {
                    //Police Chief Tells News Reporters That Violence Is Unnecessary
                    uiManager.updateNewspaper(newspapers[18]);
                } else if(numOffInSection2 >= numOffInSection1 && numOffInSection2 >= numOffInSection3)
                {
                    //Officer Names Released in Fatal Shootings
                    uiManager.updateNewspaper(newspapers[16]);
                }
                else
                {
                    //Friend Says He Would Kill '6 White Devils' in Revenge for Black Teen's Death
                    uiManager.updateNewspaper(newspapers[17]);
                }
                //activate newspaper
                newsOn = true;
                uiManager.activateNewspaper();
                currEvent++;
            } else if(currEvent == 6)
            {
                if(situationValue < 4)
                {
                    //cell phone call from wife
                    print("end of game wife call");
                    cellOn = true;
                    currEvent++;
                }
                else
                {
                    currEvent += 2;
                }
            } else if(currEvent == 7)
            {
                if(situationValue < 2)
                {
                    //wife praises
                    uiManager.addDialogue("Wife", "Hey hon, just following up from earlier today. It looks like things are quiet for now. I'm proud of you.");

                    uiManager.addDialogue(PlayerName, "Anything to make you sleep better at night.");
                }
                else
                {
                    //wife worries
                    uiManager.addDialogue("Wife", "Hey hon, do you need a day off?");
                    uiManager.addDialogue("Wife", "It might be impossible but you need a clear mind to make sound decisions.");
                    //uiManager.addDialogue("Wife", "I'll always be cheering for you dear.");
                    uiManager.addDecision("Wife", "I'll always be cheering for you dear.", "I think I could us a vacation or two", "I can't take a day off, but I'm trying my best.", -0.5f, 0.5f);

                    //uiManager.addDialogue(PlayerName, "I can't take a day off, but I'm trying my best.");

                    //uiManager.addDialogue("Wife", "I hope so.");
                    uiManager.addBranchingText("Wife", "The guys on the force might not appreciate that.", "I hope so.");
                }
                currEvent++;
            }
            else
            {
                //the end of the game
                print("game is OVER");

                print("fade to black");

                print("your score was " + situationValue);
            }
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
            desktopPhone.Stop();
            nextEvent();
        }
    }

    public void setCellInactive()
    {
        uiManager.setCellphoneActive(false);
        if (textOn)
        {
            textOn = false;
            nextEvent();
        }
    }
    
    public void setNewspaperInactive()
    {
        print("newspaper inactive");
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
