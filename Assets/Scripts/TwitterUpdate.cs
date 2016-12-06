using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TwitterUpdate : MonoBehaviour {

    
    public Sprite[] level0Tweets;
    public Sprite[] level1Tweets;
    public Sprite[] level2Tweets;
    public Sprite[] level3Tweets;
    public Sprite[] level4Tweets;
    public Sprite[] level5Tweets;

    //public GUITexture testTg;
    public Image tweet1;
    public Image tweet2;
    public Image tweet3;

    public void updateTwitter(float curSitVal)
    {
        int sitVal = Mathf.RoundToInt(curSitVal);
        //update the tweets displayed based on the given situation value
        //situation value is rounded down
        if(sitVal == 0)
        {
            //do the smart thing only if there are more than 3 tweets for a given level
            if(level0Tweets.Length > 3)
            {
                //generate 3 random numbers that are distnct
                int tweet1Index = Random.Range(0, level0Tweets.Length - 1);
                int tweet2Index = tweet1Index;
                while(tweet2Index == tweet1Index)
                {
                    tweet1Index = Random.Range(0, level0Tweets.Length - 1);
                }

                int tweet3Index = tweet1Index;
                while(tweet3Index == tweet1Index || tweet3Index == tweet2Index)
                {
                    tweet3Index = Random.Range(0, level0Tweets.Length - 1);
                }

                //now set the tweet images to the correct indicies
                tweet1.sprite = level0Tweets[tweet1Index];
                tweet2.sprite = level0Tweets[tweet2Index];
                tweet3.sprite = level0Tweets[tweet3Index];
            }
        } else if (sitVal == 1)
        {
            //do the smart thing only if there are more than 3 tweets for a given level
            if (level1Tweets.Length > 3)
            {
                //generate 3 random numbers that are distnct
                int tweet1Index = Random.Range(0, level1Tweets.Length - 1);
                int tweet2Index = tweet1Index;
                while (tweet2Index == tweet1Index)
                {
                    tweet1Index = Random.Range(0, level1Tweets.Length - 1);
                }

                int tweet3Index = tweet1Index;
                while (tweet3Index == tweet1Index || tweet3Index == tweet2Index)
                {
                    tweet3Index = Random.Range(0, level1Tweets.Length - 1);
                }

                //now set the tweet images to the correct indicies
                tweet1.sprite = level1Tweets[tweet1Index];
                tweet2.sprite = level1Tweets[tweet2Index];
                tweet3.sprite = level1Tweets[tweet3Index];
            }
        }
        else if (sitVal == 2)
        {
            //do the smart thing only if there are more than 3 tweets for a given level
            if (level2Tweets.Length > 3)
            {
                //generate 3 random numbers that are distnct
                int tweet1Index = Random.Range(0, level2Tweets.Length - 1);
                int tweet2Index = tweet1Index;
                while (tweet2Index == tweet1Index)
                {
                    tweet1Index = Random.Range(0, level2Tweets.Length - 1);
                }

                int tweet3Index = tweet1Index;
                while (tweet3Index == tweet1Index || tweet3Index == tweet2Index)
                {
                    tweet3Index = Random.Range(0, level2Tweets.Length - 1);
                }

                //now set the tweet images to the correct indicies
                tweet1.sprite = level2Tweets[tweet1Index];
                tweet2.sprite = level2Tweets[tweet2Index];
                tweet3.sprite = level2Tweets[tweet3Index];
            }
        }
        else if (sitVal == 3)
        {
            //do the smart thing only if there are more than 3 tweets for a given level
            if (level3Tweets.Length > 3)
            {
                //generate 3 random numbers that are distnct
                int tweet1Index = Random.Range(0, level3Tweets.Length - 1);
                int tweet2Index = tweet1Index;
                while (tweet2Index == tweet1Index)
                {
                    tweet1Index = Random.Range(0, level3Tweets.Length - 1);
                }

                int tweet3Index = tweet1Index;
                while (tweet3Index == tweet1Index || tweet3Index == tweet2Index)
                {
                    tweet3Index = Random.Range(0, level3Tweets.Length - 1);
                }

                //now set the tweet images to the correct indicies
                tweet1.sprite = level3Tweets[tweet1Index];
                tweet2.sprite = level3Tweets[tweet2Index];
                tweet3.sprite = level3Tweets[tweet3Index];
            }
        }
        else if (sitVal == 4)
        {
            //do the smart thing only if there are more than 3 tweets for a given level
            if (level4Tweets.Length > 3)
            {
                //generate 3 random numbers that are distnct
                int tweet1Index = Random.Range(0, level4Tweets.Length - 1);
                int tweet2Index = tweet1Index;
                while (tweet2Index == tweet1Index)
                {
                    tweet1Index = Random.Range(0, level4Tweets.Length - 1);
                }

                int tweet3Index = tweet1Index;
                while (tweet3Index == tweet1Index || tweet3Index == tweet2Index)
                {
                    tweet3Index = Random.Range(0, level4Tweets.Length - 1);
                }

                //now set the tweet images to the correct indicies
                tweet1.sprite = level4Tweets[tweet1Index];
                tweet2.sprite = level4Tweets[tweet2Index];
                tweet3.sprite = level4Tweets[tweet3Index];
            }
        }
        else
        {
            //do the smart thing only if there are more than 3 tweets for a given level
            if (level5Tweets.Length > 3)
            {
                //generate 3 random numbers that are distnct
                int tweet1Index = Random.Range(0, level5Tweets.Length - 1);
                int tweet2Index = tweet1Index;
                while (tweet2Index == tweet1Index)
                {
                    tweet1Index = Random.Range(0, level5Tweets.Length - 1);
                }

                int tweet3Index = tweet1Index;
                while (tweet3Index == tweet1Index || tweet3Index == tweet2Index)
                {
                    tweet3Index = Random.Range(0, level5Tweets.Length - 1);
                }

                //now set the tweet images to the correct indicies
                tweet1.sprite = level5Tweets[tweet1Index];
                tweet2.sprite = level5Tweets[tweet2Index];
                tweet3.sprite = level5Tweets[tweet3Index];
            }
        }
    }
}
