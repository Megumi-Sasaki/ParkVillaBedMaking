using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class BedPanelCon : MonoBehaviour
{
    public BedPanelButton bedPanelButton;

    [SerializeField]
    public int[] BedandShowerNumberR;

    public int roomNoforList;
    public int bedNoforList;


    GameObject BedPanel;
    public List<RectTransform> Buttons;
    public int countBed = 0;

    public GameObject UpperBedImageDark;
    public GameObject UpperShowerImageDark;
    public GameObject LeftRoomContents;
    public GameObject CenterBedContents;
    public GameObject CenterShowerContents;

    public List<BedData> bedDataList;
    
    public int BedandShowerGrossN;
    public int BedandShowerChecked;

    public GameObject ClosePopupWindow;
    GameObject smilingBaby;
    GameObject cryingBaby;
    GameObject StopTouchPanel;
    GameObject Okbutton;
    GameObject YesnoPanel;
    GameObject PlusminusBedPanel;
    bool CloseOK;

    public List<GameObject> CheckImage;
    public List<Button> BedandShowerButtonList;

    public int plusminusNumber;
    public  int roomN;

    public RectTransform AddbedbuttonPrefab;

    GameObject childText;

    public ScrollRect scrollrect;

    public void Start()
    {
        BedPanel = this.gameObject;
        Buttons = new List<RectTransform>();
      
        BedandShowerNumberR = new int[13] { 8, 4, 2, 4, 2, 2, 6, 8, 1, 1, 1, 1, 1 };

         int i = 0;
         while (i <= 12)
         {
            BedandShowerGrossN += BedandShowerNumberR[i];
             i++;
          }
        cryingBaby = ClosePopupWindow.transform.GetChild(2).gameObject;
        smilingBaby = ClosePopupWindow.transform.GetChild(3).gameObject;
        StopTouchPanel = ClosePopupWindow.transform.GetChild(4).gameObject;
        Okbutton = ClosePopupWindow.transform.GetChild(5).gameObject;
        YesnoPanel = ClosePopupWindow.transform.GetChild(6).gameObject;
        PlusminusBedPanel = ClosePopupWindow.transform.GetChild(7).gameObject;
        childText = ClosePopupWindow.transform.GetChild(1).gameObject;

    }
    public void PushUpperBedButton()
    {
        UpperBedImageDark.SetActive(true);
        UpperShowerImageDark.SetActive(false);
        CenterBedContents.SetActive(true);
        CenterShowerContents.SetActive(false);
    }
    public void PushUpperShowerButton()
    {
        UpperShowerImageDark.SetActive(true);
        UpperBedImageDark.SetActive(false);
        CenterShowerContents.SetActive(true);
        CenterBedContents.SetActive(false);
    }


    public void PushClose()
    {
        ClosePopupWindow.SetActive(true);
        StopTouchPanel.SetActive(true);
        childText.SetActive(true);
        Okbutton.SetActive(true);
        if (BedandShowerGrossN == BedandShowerChecked)
        {
            childText.GetComponent<Text>().text = "You completed\nall checks!";
            smilingBaby.SetActive(true);
            CloseOK = true;

        }
        else
        {           
            childText.GetComponent<Text>().text = " Please complete\nall checks!";
            cryingBaby.SetActive(true);
            CloseOK = false;
        }
    }

    public void PushOKButton()
    {
        if (CloseOK)//Work finished
        {
            ClosePopupWindow.SetActive(false);
            BedPanel.SetActive(false);
        }
        else
        {
            ClosePopupWindow.SetActive(false);
            cryingBaby.SetActive(false);
        }
        Okbutton.SetActive(false);
        StopTouchPanel.SetActive(false);
        childText.SetActive(false);
    }
    public void pushReset()
    {
        GameObject childText = ClosePopupWindow.transform.GetChild(1).gameObject;
        ClosePopupWindow.SetActive(true);
        StopTouchPanel.SetActive(true);
        YesnoPanel.SetActive(true);
        Okbutton.SetActive(false);
        childText.GetComponent<Text>().text = "Reset all checks ?";
        childText.SetActive(true);

    }
    public void PushYesReset()
    {
        bedDataList.Clear();
        ClosePopupWindow.SetActive(false);
        YesnoPanel.SetActive(false);
        //Clear All Check
        if (CheckImage.Count > 0)
        {
            for (int i = 0; i < CheckImage.Count; i++)
            {
                CheckImage[i].SetActive(false);
            }
            CheckImage.Clear();
           
            //Interactable button
            for (int i = 0; i < BedandShowerButtonList.Count; i++)
            {
                BedandShowerButtonList[i].interactable = true;
            }
            BedandShowerButtonList.Clear();
            //Cound Reset
            BedandShowerChecked = 0;
        }

    }
    public void PushNoReset()
    {
        ClosePopupWindow.SetActive(false);
        YesnoPanel.SetActive(false);
     }

    public void PushBedButtonMakinglist(int roomNO, int BedNo)
    {
       BedData b = new BedData();
       b.RoomNo = roomNO;
       b.BedNo = BedNo;
       bedDataList.Add(b);
    }

    public void PushAddBedButton()
    {
        ClosePopupWindow.SetActive(true);
        PlusminusBedPanel.SetActive(true);
    }
    
    public void PushPlusMinus(int LeftoneRighttwoOKthree)
    {
        GameObject LayoutPanel = PlusminusBedPanel.transform.GetChild(1).gameObject;
        GameObject Number = LayoutPanel.transform.GetChild(1).gameObject;
        GameObject NumberText =  Number.transform.GetChild(0).gameObject;
       
        if (LeftoneRighttwoOKthree == 1)
        {

           if( BedandShowerNumberR[roomN - 1] - Mathf.Abs(plusminusNumber) > 0)
            {
                plusminusNumber -= 1;

            }
        }
        else if(LeftoneRighttwoOKthree == 2)
        {
            if(plusminusNumber < 20)
            plusminusNumber += 1;
        }
        string number = plusminusNumber.ToString();
        NumberText.GetComponent<Text>().text = number;

        if (LeftoneRighttwoOKthree == 3)
        {
            if (BedandShowerNumberR[roomN - 1] - plusminusNumber > 0)
            {
                if (roomN != 0)
                {
                    BedandShowerNumberR[roomN - 1] += plusminusNumber;
                    BedandShowerGrossN += plusminusNumber;
                    int test = roomN - 1;

                    GetComponent<BedPanelButton>().BedButtonSystem(BedandShowerNumberR[test], roomN);

                }
            }
            plusminusNumber = 0;
            NumberText.GetComponent<Text>().text = "0";
            PlusminusBedPanel.SetActive(false);
            ClosePopupWindow.SetActive(false);
        }
        
           }


}


[System.Serializable]
public class BedData
{
    public int RoomNo;
    public int BedNo;
}
