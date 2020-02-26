using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsManager : MonoBehaviour
{
    enum AllSpell
    {
        Fireball,
        IceBall,
        Regen
    }
    
    #region ATTRIBUTES

    [SerializeField] private Dictionary<int, Spells> m_ListSpells;
    

    #endregion

    #region COMPONENTS    



    #endregion

    #region MONOBEHAVIOUR METHODS

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region PUBLIC METHODS



    #endregion

    #region PRIVATE METHODS

    private void Init()
    {

    }

    #endregion
}
