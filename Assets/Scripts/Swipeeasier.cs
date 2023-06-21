using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swipeeasier : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public RectTransform canvas;
    private Vector3 panelLocation;
    public float percentThresholds;
    private Vector2 Press;
    private Vector2 AfterDrag;
    public float easing = 0.5f;

    public int totalPages = 2;
    public int currantpages = 1; 

    void Start()
    {
        panelLocation = transform.position;
        percentThresholds = 0.4f;
        easing = 0.3f;
    }
 
    public void OnDrag(PointerEventData data)
    {

        Press = Camera.main.ScreenToWorldPoint(data.pressPosition);
        AfterDrag = Camera.main.ScreenToWorldPoint(data.position);
        float difference = Press.x - AfterDrag.x;
       transform.position = (panelLocation - new Vector3(difference, 0, 0))*1f;
      
    }
    public void OnEndDrag(PointerEventData data)//�h���b�O�I����A
    {
        Vector3 ScreenWorldSize = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height,0));
       float percentage = (Press.x - AfterDrag.x) / ScreenWorldSize.x;

        if(Mathf.Abs(percentage) >= percentThresholds)//0.2����percentage���傫�������ꍇ
        {
            Vector3 newLocation = panelLocation;
            if(percentage > 0 && currantpages < totalPages)
            {
                currantpages++;
                newLocation += new Vector3(-ScreenWorldSize.x*2, 0, 0);
            }
            else if(percentage < 0 && currantpages > 1)
            {
                currantpages--;
                newLocation += new Vector3(ScreenWorldSize.x*2, 0, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));

            panelLocation = newLocation;
        }else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
        IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float seconds)
        {
            float t = 0f;
            while (t <= 1.0f )
            {
                t += Time.deltaTime/seconds;
                transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, t));
                //�����̕����ɂ͕K���P�i�P�O�O�p�[�j���w�肵�Ȃ��ƁA�y�[�W���r���Ŏ~�܂��Ă��܂��B
                //���Ƃ����āA�P���Ƃ߂����ᑁ���y�[�W���؂�ւ��B��u�łP�O�O�p�[�ɂȂ邩��B
                //Smooth���g�����Ƃɂ��A�P�Ɏ���܂ŁAt�̌��ʂɂ��X���[�Y�ɂO���琔���𑝂₹��
                yield return null;
            }
        }
    }
       
}
