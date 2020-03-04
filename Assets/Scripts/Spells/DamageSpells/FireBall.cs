using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Spells
{

    #region ATTRIBUTES

    public DamageSpellsData FireBallData;
    private float m_TimeToDestroy = 15f;

    #endregion

    private void Update()
    {
        base.Update();
        DestroyByTime();
    }

    private void DestroyByTime()
    {
        if (m_IsCast)
        {
            m_TimeToDestroy -= Time.deltaTime;
            if (m_TimeToDestroy <= 0)
            {
                Destroy(this);
            }
        }
    }

}
