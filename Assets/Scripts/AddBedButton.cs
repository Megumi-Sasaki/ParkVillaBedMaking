using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBedButton : MonoBehaviour
{

    public  void PushPrefabAddBedButton()
    {
        GameObject BedPanel = GameObject.Find("BedPanel");
        BedPanelCon bedPanelcon = BedPanel.GetComponent<BedPanelCon>();
        bedPanelcon.PushAddBedButton();
    }
}
