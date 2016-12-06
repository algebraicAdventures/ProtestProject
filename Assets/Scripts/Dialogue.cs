using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public List<string> messages = new List<string>();
    public List<string> names = new List<string>();

    public Text mText;
    public Text mName;
    public GameManager gameManager;

    public void addMessage(string speaker, string msg)
    {
        
        if (messages.Count == 0)
        {
            mText.text = msg;
            mName.text = speaker;
        }

        messages.Add(msg);
        names.Add(speaker);
    } 

    public void nextMessage()
    {
        //print("messages count: " + messages.Count);
        if (messages.Count > 1)
        {
            string next = messages[1];
            //print("swapping to " + next);
            mText.text = next;
            mName.text = names[1];

            messages.RemoveAt(0);
            names.RemoveAt(0);
        }

        else
        {
            //print("close dialogue");
            gameObject.SetActive(false);
            messages.RemoveAt(0);
            names.RemoveAt(0);
            //make the next event occur
            gameManager.nextEvent();
            //transform.gameObject.SetActive(false);
        }
    }
	
}
