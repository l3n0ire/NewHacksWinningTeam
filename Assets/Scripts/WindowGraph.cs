using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject MeasuringPoint;
    private List<int> valueList = new List<int>() {};


    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
    }

    public void runGraphFromButton(){
        StartCoroutine(InvokeMethod(addPointtoGraph, 0.5f, 12));
    }
    private void addPointtoGraph()
    {
        float dist = Vector3.Distance(Ball.transform.position, MeasuringPoint.transform.position);
        valueList.Add(Mathf.RoundToInt(dist));
        showGraph(valueList);
    }

    public IEnumerator InvokeMethod(Action method, float interval, int invokeCount){
        for(int i = 0; i < invokeCount; i++){
            method();
            yield return new WaitForSeconds(interval);
        }
    }

    private void CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.tag = "DeleteThis";
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    private void showGraph(List<int> valueList)
    {
        clearOldGraph();
        float graphHeight = graphContainer.sizeDelta.y;
        float xSize = 25f;
        float yMaximum = 100f;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            CreateCircle(new Vector2(xPosition, yPosition));

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer);
            labelX.gameObject.SetActive(true);
            labelX.gameObject.tag = "DeleteThis";
            labelX.anchoredPosition = new Vector2(xPosition, -5f);
            labelX.GetComponent<Text>().text = i.ToString();
        }

        int seperatorCount = 10;

        for (int i = 0; i <= seperatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer);
            labelY.gameObject.SetActive(true);
            labelY.gameObject.tag = "DeleteThis";
            float normalizedValue = i * 1f / seperatorCount;
            labelY.anchoredPosition = new Vector2(-7f, normalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue * yMaximum).ToString();
        }
    }

    private void clearOldGraph()
    {
        foreach(Transform child in graphContainer) {
            if (child.gameObject.tag == "DeleteThis"){
                Destroy(child.gameObject);
            }
        }
    }

}
