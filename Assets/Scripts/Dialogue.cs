using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public List<string> messages = new List<string>();

    public Text mText;

    public void addMessage(string msg)
    {
        
        if (messages.Count == 0)
        {
            mText.text = msg;
        }

        messages.Add(msg);
    } 

    public void nextMessage()
    {
        if (messages.Count > 1)
        {
            string next = messages[1];
            //print("swapping to " + next);
            mText.text = next;
            messages.RemoveAt(0);
        }

        else
        {
            //print("close dialogue");
            gameObject.SetActive(false);
            //transform.gameObject.SetActive(false);
        }
    }
	
}
