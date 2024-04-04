using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level : MonoBehaviour
{
    public List<GameObject> gameObjects;

    [SerializeField] private LineRenderer line;

    private TouchPoint fistCollected;

    List<TouchPoint> listCollected = new List<TouchPoint>();

    [SerializeField] private List<TouchPoint> list1;
    [SerializeField] private List<TouchPoint> list2;
    [SerializeField] private List<TouchPoint> list3;
    [SerializeField] private List<TouchPoint> list4;
    [SerializeField] private List<TouchPoint> list5;
    [SerializeField] private List<TouchPoint> list6;
    [SerializeField] private List<TouchPoint> list7;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            listCollected.Clear();
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                //pl.localScale = Vector3.one * 0.6f;
                line.positionCount = 0;
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, targetObject.transform.position);
            }
        }

        if (Input.GetMouseButton(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                var tp = targetObject.GetComponent<TouchPoint>();
                if (tp != null)
                {
                    if (fistCollected == null)
                    {
                        fistCollected = tp;
                        if (!listCollected.Contains(tp))
                            listCollected.Add(tp);
                        line.positionCount++;
                        line.SetPosition(line.positionCount - 1, tp.transform.position);
                    }
                    else
                    {
                        if (!listCollected.Contains(tp))
                            listCollected.Add(tp);
                        line.positionCount++;
                        line.SetPosition(line.positionCount - 1, tp.transform.position);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            line.positionCount = 0;

            if (CheckList(listCollected))
            {
                foreach(TouchPoint point in listCollected)
                {
                    point.SetCompleted();
                }
            }
            else
                return;
        }
    }

    private bool CheckList(List<TouchPoint> touchPoints)
    {
        if (AreTwoListEqual(list1, touchPoints))
            return true;
        else if (AreTwoListEqual(list2, touchPoints))
            return true;
        else if (AreTwoListEqual(list3, touchPoints))
            return true;
        else if (AreTwoListEqual(list4, touchPoints))
            return true;
        else if (AreTwoListEqual(list5, touchPoints))
            return true;
        else if (AreTwoListEqual(list6, touchPoints))
            return true;
        else if (AreTwoListEqual(list7, touchPoints))
            return true;
        else
            return false;
    }

    private bool AreTwoListEqual(List<TouchPoint> list_1, List<TouchPoint> list_2)
    {


        if (list_1.Count != list_2.Count)
        {
            return false;
        }

        for (int i = 0; i < list_1.Count; i++)
        {
            if (list_1[i].GetIndex() != list_2[i].GetIndex())
            {
                return false;
            }
        }
        return true;
    }
}
