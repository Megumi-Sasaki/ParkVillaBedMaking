using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartPanel : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject bedpanelCon;
    CanvasGroup bedpanel;
    public GameObject Startpanel;


    void Start()
    {
        canvasGroup.DOFade(endValue: 1f, duration: 1f);
       bedpanel = bedpanelCon.GetComponent<CanvasGroup>();
    }

    public void PushstartButton()
    {
        Startpanel.SetActive(false);
        bedpanel.DOFade(endValue: 1f, duration: 1f);

    }


}
