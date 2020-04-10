﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBoardTest : MonoBehaviour
{
    [SerializeField] private GameObject m_Prefab;
    [SerializeField] private List<GameObject> m_ListCornerPoint;
    [SerializeField] private float m_MovementSpeed = 0.0f;
    [SerializeField] private float m_DistanceWithGround = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        FloorDetection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * m_MovementSpeed * Time.deltaTime;
    }

    private void FloorDetection()
    {
        RaycastHit hit;

        for (int i = 0; i < m_ListCornerPoint.Count; i++)
        {
            Vector3 dir = -(m_ListCornerPoint[i].transform.up);
            Vector3 point = m_ListCornerPoint[i].transform.position - m_ListCornerPoint[i].transform.up;

            if (Physics.Raycast(m_ListCornerPoint[i].transform.position, dir, out hit))
            {
                Debug.DrawRay(m_ListCornerPoint[i].transform.position, dir, Color.red);
                if (hit.transform.name == "Ground")
                {
                    if (i <= m_ListCornerPoint.Count)
                    {
                        GameObject go = Instantiate(m_Prefab, point, Quaternion.identity);
                    }                        
                }
            }
        }
    }
}
