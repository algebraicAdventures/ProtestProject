using UnityEngine;
using System.Collections;

public class ReactToClick : MonoBehaviour {

    public enum ObjectType { Twitter, Cell, Landline, Newspaper};
    public ObjectType mType;
    public GameManager gameManager;

    public UIManager uiManager;

    void OnMouseDown()
    {
        
        switch (mType)
        {
            case ObjectType.Cell:
                uiManager.activateCellphone();
                break;
            case ObjectType.Twitter:
                uiManager.activateTwitter();
                break;
            case ObjectType.Landline:
                //uiManager.activateLandline();
                gameManager.pickUpPhone();
                break;
            case ObjectType.Newspaper:
                uiManager.activateNewspaper();
                break;
        }
    }


}
