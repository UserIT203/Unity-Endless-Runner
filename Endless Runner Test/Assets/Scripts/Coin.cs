using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : Bonus
{
    private void OnDestroy()
    {
        var mainModulePartical = takeEffeck.GetComponent<ParticleSystem>().main;
        mainModulePartical.startColor = effectColor;

        Instantiate(takeEffeck, new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), Quaternion.identity);
    }

}
