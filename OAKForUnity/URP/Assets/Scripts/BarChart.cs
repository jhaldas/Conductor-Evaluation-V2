using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarChart : MonoBehaviour
{
    public Bar barPrefab;
    public Summary summaryPrefab;
    float chartWidth;
    List<Bar> bars = new List<Bar>();
    void Start()
    {
        chartWidth = Screen.width + GetComponent<RectTransform>().sizeDelta.x;
        float[] values = { 0.84f, 0.54f, 0.35f, .95f};
        string[] labels = { "Top Left", "Top Right", "Bottom Left", "Bottom Right" };
        DisplayGraph(values, labels);
        DisplaySummary(values);
       
    }

    void DisplayGraph(float[] vals, string[] labels)
    {
        for(int i = 0; i < vals.Length; i++)
        {
            Bar newBar = Instantiate(barPrefab) as Bar;
            newBar.transform.SetParent(transform);
            RectTransform rt = newBar.bar.GetComponent<RectTransform>();
            if (vals[i] == 1f)
            {
                rt.sizeDelta = new Vector2(rt.sizeDelta.x, chartWidth * vals[i]) * 0.99f;
            }
            else
            {
                rt.sizeDelta = new Vector2(rt.sizeDelta.x, chartWidth * vals[i]);
            }
            newBar.barValue.text = (vals[i] * 100).ToString() + "%";
            newBar.spaceLabel.text = labels[i];
        }
    }
    void DisplaySummary(float[] vals)
    {
        Summary newSum = Instantiate(summaryPrefab) as Summary;
        newSum.transform.SetParent(transform);
        newSum.summaryDescription.text = "You used " + (vals[0] * 100).ToString() + "% of your Top Left portion of your space. \n" + "You used " + (vals[1] * 100).ToString() + "% of your Top Right portion of your space. \n" +
                                         "You used " + (vals[2] * 100).ToString() + "% of your Bottom Left portion of your space. \n" + "You used " + (vals[3] * 100).ToString() + "% of your Bottom Right portion of your space. \n";
    }
   
}
