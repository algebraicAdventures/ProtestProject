using UnityEngine;
using System.Collections;

public class ReactToClick : MonoBehaviour {

    public enum ObjectType { Desktop, Cell, Landline, Newspaper};
    public ObjectType mType;
    public GameManager gameManager;

    public UIManager uiManager;



    void OnMouseDown()
    {
        print("clicked it xD");
        /*
        switch (mType)
        {
            case ObjectType.Cell:
                //uiManager.activateCellphone();
                gameManager.pickUpCell();
                break;
            case ObjectType.Desktop:
                uiManager.activateDesktop();
                break;
            case ObjectType.Landline:
                //uiManager.activateLandline();
                gameManager.pickUpPhone();
                break;
            case ObjectType.Newspaper:
                uiManager.activateNewspaper();
                break;
        }*/
    }


}
