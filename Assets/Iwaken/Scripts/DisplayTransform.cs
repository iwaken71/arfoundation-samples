using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Iwaken
{


    public class DisplayTransform : MonoBehaviour
    {
        [SerializeField] private TextMeshPro label;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            label.text = transform.position.ToString();
        }
    }
}