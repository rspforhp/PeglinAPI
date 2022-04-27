using System;
using UnityEngine;

namespace API
{
    public class ActivateOnCreate : MonoBehaviour
    {
        private void Awake()
        {
            this.gameObject.SetActive(true);
        }
    }
}