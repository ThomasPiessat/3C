using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    #region ATTRIBUTES

    [SerializeField] private string m_weaponsTag = "Weapon";

    #endregion

    #region PROPERTIES

    [SerializeField] private List<GameObject> m_listWeapons = null;
    [SerializeField] private int m_maxWeapons = 2;
    [SerializeField] private GameObject m_currentWeapon = null;
    [SerializeField] private Transform m_characterHand = null;
    [SerializeField] private FTPSCamera m_camera = null;
    [SerializeField] private Transform m_dropPoint = null;
    #endregion

    #region MONOBEHAVIOUR METHODS

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Select(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Select(1);
        }

        PickUpWeapon();
        DropWeapon();
    }

    #endregion

    #region PRIVATE METHODS

    private void PickUpWeapon()
    {
        RaycastHit hit;
        Ray ray = new Ray(m_camera.transform.position, m_camera.transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag(m_weaponsTag) && m_listWeapons.Count < m_maxWeapons && Input.GetKeyDown(KeyCode.E))
            {
                m_listWeapons.Add(hit.collider.gameObject);

                hit.collider.gameObject.SetActive(false);

                hit.transform.parent = m_characterHand;
                hit.transform.localPosition = Vector3.zero;
            }
        }
    }

    private void DropWeapon()
    {
        if (m_currentWeapon != null && Input.GetKeyDown(KeyCode.F))
        {
            m_currentWeapon.transform.parent = null;
            m_currentWeapon.transform.position = m_dropPoint.position;

            //virtualInventory
            var weaponID = m_currentWeapon.GetInstanceID();

            for (int i = 0; i < m_listWeapons.Count; i++)
            {
                if (m_listWeapons[i].GetInstanceID() == weaponID)
                {
                    m_listWeapons.RemoveAt(i);
                    break;
                }
            }

            m_currentWeapon = null;
        }
    }

    private void Select(int _index)
    {
        if (m_listWeapons.Count > _index && m_listWeapons[_index] != null)
        {
            if (m_currentWeapon != null)
            {
                m_currentWeapon.gameObject.SetActive(false);
            }

            m_currentWeapon = m_listWeapons[_index];
            m_currentWeapon.SetActive(true);
        }
    }

    #endregion
}
