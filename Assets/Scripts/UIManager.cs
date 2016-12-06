using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Canvas newspaperCanvas;
    public Canvas twitterCanvas;
    public Canvas landlineCanvas;
    public Canvas cellphoneCanvas;
    public Canvas officerAssignCanvas;
    public Canvas dialogueCanvas;
    public Canvas desktopCanvas;

    public GameManager gameManger;

    public TwitterUpdate twitterUpdater;

    public AudioSource desktopSound;

    public DropZone[] dropZones;

    private Dialogue mDialogue;

    //bool inUse = true;

    // Use this for initialization
    void Start () {
        //hide the UI
        //newspaperCanvas.SetActive(false);
        newspaperCanvas.gameObject.SetActive(false);
        twitterCanvas.gameObject.SetActive(false);
        landlineCanvas.gameObject.SetActive(false);
        cellphoneCanvas.gameObject.SetActive(false);
        officerAssignCanvas.gameObject.SetActive(false);
        dialogueCanvas.gameObject.SetActive(false);
        desktopCanvas.gameObject.SetActive(false);

        mDialogue = dialogueCanvas.GetComponent<Dialogue>();
    }

    public int getOfficersInArea(int areaIndex)
    {
        //get the number of elements in the area corresponding to the index given
        //DropZone mZone = dialogueCanvas.GetComponent<DropZone>();
        //print(mZone.ToString());
        //print(dz1.ToString());
        print(dropZones[areaIndex].transform.childCount);
        //dz1.chi

        return dropZones[areaIndex].transform.childCount;
    }

    public void addDialogue(string speaker, string message)
    {
        //print("got messages to add " + message);
        //print("adding message " + message);
        mDialogue.addMessage(speaker, message);
        dialogueCanvas.gameObject.SetActive(true);
    }

    private bool inUse()
    {
        //return newspaperCanvas.gameObject.active;
        return newspaperCanvas.isActiveAndEnabled || twitterCanvas.isActiveAndEnabled ||
            landlineCanvas.isActiveAndEnabled || cellphoneCanvas.isActiveAndEnabled
            || officerAssignCanvas.isActiveAndEnabled || dialogueCanvas.isActiveAndEnabled ||
            desktopCanvas.isActiveAndEnabled;
    }



    public void closeUI()
    {
        //hide the UI
        newspaperCanvas.gameObject.SetActive(false);
        twitterCanvas.gameObject.SetActive(false);
        landlineCanvas.gameObject.SetActive(false);
        cellphoneCanvas.gameObject.SetActive(false);
        officerAssignCanvas.gameObject.SetActive(false);
        desktopCanvas.gameObject.SetActive(false);
    }

    public void activateDesktop()
    {
        if (!inUse())
        {
            desktopSound.Play();
            desktopCanvas.gameObject.SetActive(true);
        }
    }
    public void deactivateDesktop()
    {
        desktopCanvas.gameObject.SetActive(false);
    }

    public void activateNewspaper()
    {
        if (!inUse())
        {
            newspaperCanvas.gameObject.SetActive(true);
            //inUse = true;
        }
    }
    public void deactivateNewspaper()
    {
        newspaperCanvas.gameObject.SetActive(false);
        //inUse = false;
    }


    public void activateTwitter()
    {
        if (!inUse())
        {
            twitterCanvas.gameObject.SetActive(true);
            //inUse = true;
        }
    }
    public void deactivateTwitter()
    {
        twitterCanvas.gameObject.SetActive(false);
        //inUse = false;
    }


    public void activateLandline()
    {
        if (!inUse())
        {
            landlineCanvas.gameObject.SetActive(true);
            //inUse = true;
        }
    }
    public void deactivateLandline()
    {
        landlineCanvas.gameObject.SetActive(true);
        //inUse = true;
    }


    public void activateCellphone()
    {
        if (!inUse())
        {
            cellphoneCanvas.gameObject.SetActive(true);
            //inUse = true;
        }
    }
    public void deactivateCellphone()
    {
        cellphoneCanvas.gameObject.SetActive(true);
        //inUse = true;
    }


    public void activateOfficerAssign()
    {
        if (!inUse())
        {
            officerAssignCanvas.gameObject.SetActive(true);
            //inUse = true;
        }
    }
    public void deactivateOfficerAssign()
    {
        officerAssignCanvas.gameObject.SetActive(true);
        //inUse = true;
    }


    
    public void setNewspaperActive(bool val)
    {
        closeUI();
        newspaperCanvas.gameObject.SetActive(val);
        //inUse = val;
    }

    public void setTwitterActive(bool val)
    {
        closeUI();
        twitterUpdater.updateTwitter(gameManger.getSituationValue());
        twitterCanvas.gameObject.SetActive(val);
        //inUse = val;
    }

    public void setLandlineActive(bool val)
    {
        landlineCanvas.gameObject.SetActive(val);
        //inUse = val;
    }

    public void setCellphoneActive(bool val)
    {
        cellphoneCanvas.gameObject.SetActive(val);
        //inUse = val;
    }

    public void setOfficerAssignActive(bool val)
    {
        officerAssignCanvas.gameObject.SetActive(val);
        //inUse = val;
    }

}
