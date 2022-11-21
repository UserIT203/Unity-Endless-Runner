using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Image line;
    public Image image;
    private SliderManager sliderManager;

    [HideInInspector] public Color color;
    [HideInInspector] public float maxValue;
    [HideInInspector] public string name;
    [HideInInspector] public float positionY;

    private Slider _slider;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name += "_" + name;

        _slider = GetComponentInChildren<Slider>();
        _slider.maxValue = maxValue;
        _slider.value = maxValue;

        line.color = color;

        sliderManager = GameObject.Find("SliderManager").GetComponent<SliderManager>();
    }

    public void SetValue(float _value) => _slider.value = _value;


    // Update is called once per frame
    void Update()
    {
        if (_slider.value > 0)
        {
            _slider.value -= Time.deltaTime;
        }
        else
        {
            index = sliderManager.slidersObj.IndexOf(this.gameObject);

            sliderManager.slidersObj.RemoveAt(index);
            Destroy(this.gameObject);

            sliderManager.ChangePositionBonus();
        }
            
    }
}
