using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private GameObject sliderPrefab;
    [SerializeField] private GameObject panel;

    [HideInInspector] public List<GameObject> slidersObj = new List<GameObject>();
    private GameObject currentSliderObj;

    [Header("Const Positions")]
    public float[] constPositionX;
    public float[] constPositionY;


    public void CreateSlider(float lifeTime, Color sliderColor, string sliderName, Sprite sprite)
    {

        if (CheclSkiders(sliderName))
        {
            GameObject newSliderObj = Instantiate(sliderPrefab,
               sliderPrefab.transform.position = new Vector3(constPositionX[slidersObj.Count], constPositionY[slidersObj.Count], 0),
               Quaternion.identity) as GameObject;

            SliderScript componentsSlider = newSliderObj.GetComponentInChildren<SliderScript>();
            componentsSlider.maxValue = lifeTime;
            componentsSlider.color = sliderColor;
            componentsSlider.name = sliderName;
            componentsSlider.image.sprite = sprite;

            componentsSlider.transform.SetParent(panel.transform, false);
            componentsSlider.transform.SetSiblingIndex(0);

            slidersObj.Add(newSliderObj);
        }
        else
        {
            currentSliderObj.GetComponent<SliderScript>().SetValue(lifeTime);
        }

    }

    public void ChangePositionBonus()
    {
        for (int i = 0; i < slidersObj.Count; i++)
        {
            slidersObj[i].transform.localPosition = new Vector3(constPositionX[i], constPositionY[i], 0);
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
