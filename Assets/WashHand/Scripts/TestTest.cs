using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTest : MonoBehaviour
{
    [SerializeField] private Material m_material;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float time =  Time.time -Mathf.Floor(Time.time);
        m_material.SetFloat("_Infection", time);

    }
}
