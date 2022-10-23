using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonus : MonoBehaviour
{
    [SerializeField] private Score scoreScripts;

    public bool isImmortal;

    [HideInInspector] public Coroutine starCor;
    [HideInInspector] public Coroutine shieldCor;

    // Start is called before the first frame update
    void Start()
    {
        isImmortal = false;
    }


    public IEnumerator StarBonus(float lifetime)
    {
        scoreScripts.scoreMultiplier = 2;

        yield return new WaitForSeconds(lifetime);

        scoreScripts.scoreMultiplier = 1;
        starCor = null;
    }

    public IEnumerator ShieldBonus(float lifetime)
    {
        isImmortal = true;

        yield return new WaitForSeconds(lifetime);

        isImmortal = false;
        shieldCor = null;
    }

    private void Update()
    {

    }
}
