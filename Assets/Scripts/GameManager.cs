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
    int numOffInSection1 = 0;
    int numOffInSection2 = 0;
    int numOffInSection3 = 0;

    // Use this for initialization
    void Start () {
        publicPerceptionValue = 0.0f;
        situationValue = 0.0f;
        cityStatusValue = 1.0f;

        uiManager = this.GetComponent<UIManager>();

        //open up initial newspaper with officer assign screen behind
        
        uiManager.setOfficerAssignActive(true);
        //uiManager.setNewspaperActive(true);
        uiManager.setNewspaperActive(true);
    }
	
	//public function for when player is finished with officer assignments
    public void nextEvent()
    {
        //print("starting the day");

        uiManager.closeUI();


        if(currEvent == 0)
        {
            //send the initial politican phone call
            uiManager.addDialogue("dawn of the first day");
            uiManager.addDialogue("Test seccond message");
            uiManager.addDialogue("Test third message");

            //get officer assignments
            //numOffInSection1 = uiManager;

            //set up first decision tree
            //
        }

        //get the current officer assignments

    }

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
