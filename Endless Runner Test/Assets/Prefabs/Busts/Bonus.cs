using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    public Color sliderColor;
    public float lifeTime;
    public string bonusName;

    public Sprite bonusSprite;

    private void Update()
    {
        transform.Rotate(0, 45 * Time.deltaTime, 0);
    }
}
