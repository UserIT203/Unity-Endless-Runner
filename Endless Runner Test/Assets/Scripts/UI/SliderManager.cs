using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private GameObject sliderPrefab;
    [SerializeField] private GameObject panel;

    [HideInInspector] public List<GameObject> slidersObj = new List<GameObject>();
    private GameObject currentSliderObj; 

    public void CreateSlider(float lifeTime, Color sliderColor, string sliderName)
    {
        if (CheclSkiders(sliderName))
        {
            float positionY = 50 * slidersObj.Count;

            GameObject newSliderObj = Instantiate(sliderPrefab,
               sliderPrefab.transform.position = new Vector3(20, positionY, 0),
               Quaternion.identity) as GameObject;

            SliderScript componentsSlider = newSliderObj.GetComponent<SliderScript>();
            componentsSlider.maxValue = lifeTime;
            componentsSlider.color = sliderColor;
            componentsSlider.name = sliderName;

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

    private void PrintArray()
    {
        foreach (var item in slidersObj)
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
