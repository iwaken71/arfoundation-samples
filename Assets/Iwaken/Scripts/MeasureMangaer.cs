using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;
namespace Iwaken
{
public enum MeasrueState
{
    None,
    One,
    Two
}

public class MeasureMangaer : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private TextMeshProUGUI distanceText;
    List<ARRaycastHit> hitResluts = new List<ARRaycastHit>();
    private MeasrueState state;

    private Vector3 startPosition, endPosition;

    private GameObject startPoint, endPoint;

    private float distance = 0f;

    [SerializeField]private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        state = MeasrueState.None;
        startPoint = Instantiate(pointPrefab) as GameObject;
        endPoint = Instantiate(pointPrefab) as GameObject;
        startPoint.SetActive(false);
        endPoint.SetActive(false);
        lr.startWidth =0.005f;
        lr.endWidth =0.005f;
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == MeasrueState.One)
        {
            if (raycastManager.Raycast(new Vector2(Screen.width/2,Screen.height/2), hitResluts))
            {
                Vector3 position = hitResluts[0].pose.position;
                endPosition = position;
                endPoint.transform.position = position;
                distance = Vector3.Distance(startPosition, endPosition);
                distanceText.text = (distance * 100).ToString("f1");
                lr.SetPosition(1, endPosition);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (raycastManager.Raycast(new Vector2(Screen.width/2,Screen.height/2), hitResluts))
            {
                Vector3 position = hitResluts[0].pose.position;
                switch (state)
                {
                case MeasrueState.None:
                    startPosition = position;
                    startPoint.transform.position = position;
                    startPoint.SetActive(true);
                    endPoint.SetActive(true);
                    state = MeasrueState.One;
                    lr.SetPosition(0, startPosition);
                    lr.SetPosition(1, endPosition);
                    lr.enabled = true;
                    break;
                case MeasrueState.One:
                    endPosition = position;
                    endPoint.transform.position = position;
                    lr.SetPosition(1, endPosition);
                    state = MeasrueState.Two;
                    break;
                case MeasrueState.Two:
                    startPoint.SetActive(false);
                    endPoint.SetActive(false);
                    state = MeasrueState.None;
                    lr.enabled = false;
                    break;
                default:
                    break;
                }
            }
        }
    }
}
}
