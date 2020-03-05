using UnityEngine;

public class FireBall : DamageSpells
{

    #region ATTRIBUTES



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
