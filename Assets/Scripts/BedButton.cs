using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BedButton : MonoBehaviour
{
    [SerializeField]
    private Text mytext;

    public int BedNoforList;
    public int RoomNoforList;

    public GameObject CheckImage;
    public bool Check;

    public CanvasGroup canvasGroup;

    public void Start()
    {
        Tweener tweener = canvasGroup.DOFade(endValue: 1f, duration: 0.5f);
    }

    public void SetText(string textstring)
    {
        mytext.text = textstring;

    }
    public void PushBedbutton()
    {
      //チェックマークつける、リストに入れる
        GameObject BedPanel = GameObject.Find("BedPanel");
        BedPanelCon bedPanelcon = BedPanel.GetComponent<BedPanelCon>();
               Button Thisbtn = GetComponent<Button>();
       
        Check = false;
        //クリックもう一回したら、チェックが消える＆リストから外れるように
        for (int i = 0; i < bedPanelcon.bedDataList.Count; i++)
        {
            if (RoomNoforList == bedPanelcon.bedDataList[i].RoomNo)
            {
                if (BedNoforList == bedPanelcon.bedDataList[i].BedNo)
                {
                    Check = true;
                    bedPanelcon.bedDataList.RemoveAt(i);
                    bedPanelcon.BedandShowerChecked -= 1;
                    
                }
            }
        }
            if(Check == true)
            {
                CheckImage.SetActive(false);
                bedPanelcon.CheckImage.Remove(CheckImage);
                bedPanelcon.BedandShowerButtonList.Remove(Thisbtn);
            }
            else
            {
                bedPanelcon.PushBedButtonMakinglist(RoomNoforList, BedNoforList);
                CheckImage.SetActive(true);
            bedPanelcon.BedandShowerChecked += 1;

            bedPanelcon.CheckImage.Add(CheckImage);
                bedPanelcon.BedandShowerButtonList.Add(Thisbtn);
            }
        
    }
}
