using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowerpanelButton : MonoBehaviour
{
   public GameObject CheckImage;

   public int RoomNo;
   public int ShowerNo;

    public bool Check;
  
    public void PushShowerEachButton()
    {
        Button Thisbtn = GetComponent<Button>();
        GameObject BedPanel = GameObject.Find("BedPanel");
        BedPanelCon bedPanelcon = BedPanel.GetComponent<BedPanelCon>();

        Check = false;
        //クリックもう一回したら、チェックが消える＆リストから外れるように
        for (int i = 0; i < bedPanelcon.bedDataList.Count; i++)
        {
            if (RoomNo == bedPanelcon.bedDataList[i].RoomNo)
            {
                if (ShowerNo == bedPanelcon.bedDataList[i].BedNo)
                {
                    Check = true;
                    bedPanelcon.bedDataList.RemoveAt(i);
                    bedPanelcon.BedandShowerChecked -= 1;

                }
            }
        }
        if (Check == true)
        {
            CheckImage.SetActive(false);
            bedPanelcon.CheckImage.Remove(CheckImage);
            bedPanelcon.BedandShowerButtonList.Remove(Thisbtn);
        }
        else
        {
            bedPanelcon.PushBedButtonMakinglist(RoomNo, ShowerNo);
            CheckImage.SetActive(true);
            bedPanelcon.BedandShowerChecked += 1;

            bedPanelcon.CheckImage.Add(CheckImage);
            bedPanelcon.BedandShowerButtonList.Add(Thisbtn);
        }


    }

}
