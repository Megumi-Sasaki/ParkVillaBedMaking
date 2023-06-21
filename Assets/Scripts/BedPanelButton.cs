using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedPanelButton : MonoBehaviour
{
    //RoomButton
    [SerializeField]
    private GameObject BedPanel;
    public RectTransform prefab;//Bed
    public RectTransform contents;
    public RectTransform bedAddbutton;

    RectTransform BedPrefab;
    BedPanelCon bedPanelCon;

    GameObject RoomButton;
    static GameObject CheckedMark;

    public void Start()
    {
        bedPanelCon = BedPanel.GetComponent<BedPanelCon>();
      
    }

    public void PushRoomEachButton(int roomN)
    {
        //Scrollback
        bedPanelCon.scrollrect.verticalNormalizedPosition = 1.0f;
        bedPanelCon.roomN = roomN;
        //RemoveAllcheck
        if (bedPanelCon.CheckImage.Count > 0)
        {
            bedPanelCon.CheckImage.Clear();
        }
        //RemoveAllButtons
        if (bedPanelCon.BedandShowerButtonList.Count > 0)
        {
            bedPanelCon.BedandShowerButtonList.Clear();
        }
        if (CheckedMark == true)
        {
            CheckedMark.SetActive(false);
        }
        if (roomN == 1)
        {
            BedButtonSystem(bedPanelCon.BedandShowerNumberR[roomN - 1], roomN);
            RoomButton = GameObject.Find("R1");
        }
        else if (roomN == 2)
        {
            BedButtonSystem(bedPanelCon.BedandShowerNumberR[roomN - 1], roomN);
            RoomButton = GameObject.Find("R2");
         }
        else if (roomN == 3)
        {
            BedButtonSystem(bedPanelCon.BedandShowerNumberR[roomN - 1], roomN);
            RoomButton = GameObject.Find("R3");
        }
        else if (roomN == 4)
        {
            BedButtonSystem(bedPanelCon.BedandShowerNumberR[roomN - 1], roomN);
            RoomButton = GameObject.Find("R4");
        }
        else if (roomN == 5)
        {
            BedButtonSystem(bedPanelCon.BedandShowerNumberR[roomN - 1], roomN);
            RoomButton = GameObject.Find("R5");
        }
        else if (roomN == 6)
        {
            BedButtonSystem(bedPanelCon.BedandShowerNumberR[roomN - 1], roomN);
            RoomButton = GameObject.Find("R6");
        }
        else if (roomN == 7)
        {
            BedButtonSystem(bedPanelCon.BedandShowerNumberR[roomN - 1], roomN);
            RoomButton = GameObject.Find("R7");
        }
        else if (roomN == 8)
        {
            BedButtonSystem(bedPanelCon.BedandShowerNumberR[roomN - 1], roomN);
            RoomButton = GameObject.Find("R8");
        }
       CheckedMark  = RoomButton.transform.GetChild(1).gameObject;
        CheckedMark.SetActive(true);

    }
    public void BedButtonSystem(int Bednumber, int roomNo)
    {
      
       if (bedPanelCon.countBed == Bednumber)
        {
            return;
        }

        bedPanelCon.countBed = 0;
        if (bedPanelCon.Buttons.Count > 0)
        {
            foreach (RectTransform bedbutton in bedPanelCon.Buttons)
            {
                Destroy(bedbutton.gameObject);
            }
            bedPanelCon.Buttons.Clear();
        }

        if (bedPanelCon.AddbedbuttonPrefab == true)
        {
            Destroy(bedPanelCon.AddbedbuttonPrefab.gameObject);
        }

        for (int i = 1; i <= Bednumber; i++)
        {
           RectTransform  BedPrefab = GameObject.Instantiate(prefab);

            BedPrefab.SetParent(contents, false);

            BedPrefab.GetComponent<BedButton>().SetText("Bed " + i);

            bedPanelCon.Buttons.Add(BedPrefab);
            bedPanelCon.countBed++;
            bedPanelCon.roomNoforList = roomNo;
            bedPanelCon.bedNoforList = i;

            BedPrefab.GetComponent<BedButton>().RoomNoforList = bedPanelCon.roomNoforList;
            BedPrefab.GetComponent<BedButton>().BedNoforList = bedPanelCon.bedNoforList;

            //もしRoomNoBedNoがリストの中にある場合、チェックマーク表示
            for (int j = 0; j < bedPanelCon.bedDataList.Count; j++)
            {
                if (bedPanelCon.bedDataList[j].RoomNo == bedPanelCon.roomNoforList)
                {
                    if (bedPanelCon.bedDataList[j].BedNo == bedPanelCon.bedNoforList)
                    {
                        BedPrefab.GetComponent<BedButton>().CheckImage.SetActive(true);

                    }
                }

            }
            
        }
        RectTransform bedAddbuttonPrefab = GameObject.Instantiate(bedAddbutton);

        bedAddbuttonPrefab.SetParent(contents, false);
        bedPanelCon.AddbedbuttonPrefab = bedAddbuttonPrefab;
    }
}
