using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonus : MonoBehaviour
{
    [SerializeField] private Score scoreScripts;

    [HideInInspector] public int moneyMulti = 1;
    public bool isImmortal;

    [HideInInspector] public Coroutine starCor;
    [HideInInspector] public Coroutine shieldCor;
    [HideInInspector] public Coroutine moneyMultidCor;

    // Start is called before the first frame update
    void Start()
    {
        isImmortal = false;
        moneyMulti = 1;
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


    public IEnumerator MoneyBonus(float lifetime)
    {
        moneyMulti = 2;

        yield return new WaitForSeconds(lifetime);

        moneyMulti = 1;
        moneyMultidCor = null;
    }
    private void Update()
    {

    }
}
