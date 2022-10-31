using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private GameObject sliderPrefab;
    [SerializeField] private GameObject panel;

    [HideInInspector] public List<GameObject> slidersObj = new List<GameObject>();
    private GameObject currentSliderObj;

    private float positionY;
    private void PositionSliderBonus()
    {
        var panelSize = panel.transform as RectTransform;
        var sliderSize = sliderPrefab.transform as RectTransform;

        if (slidersObj.Count == 0)
            positionY = panelSize.rect.height / 2 - sliderSize.rect.height;
        else
        {
            float currentPositioY = slidersObj[^1].GetComponent<SliderScript>().positionY;
            if (panelSize.rect.height / 2 - currentPositioY <= 40)
            {
                positionY = currentPositioY - sliderSize.rect.height - 10;
            }
            else
            {
                positionY = currentPositioY + sliderSize.rect.height + 10;
            }           
        }
    }

    public void CreateSlider(float lifeTime, Color sliderColor, string sliderName)
    {
        PositionSliderBonus();

        if (CheclSkiders(sliderName))
        {
            GameObject newSliderObj = Instantiate(sliderPrefab,
               sliderPrefab.transform.position = new Vector3(20, positionY, 0),
               Quaternion.identity) as GameObject;

            SliderScript componentsSlider = newSliderObj.GetComponent<SliderScript>();
            componentsSlider.maxValue = lifeTime;
            componentsSlider.color = sliderColor;
            componentsSlider.name = sliderName;
            componentsSlider.positionY = this.positionY;

            componentsSlider.transform.SetParent(panel.transform, false);
            componentsSlider.transform.SetSiblingIndex(0);

            slidersObj.Insert(slidersObj.Count, newSliderObj);
        }
        else
        {
            currentSliderObj.GetComponent<SliderScript>().SetValue(lifeTime);
        }

    }

    private bool CheclSkiders(string _name)
    {
        foreach (GameObject obj in slidersObj)
        {
            if (obj.GetComponent<SliderScript>().name == _name)
            {
                currentSliderObj = obj;
                return false;
            }
                
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
