using System;
using UnityEngine;

namespace _gAME.Scripts
{
    public class StartGame : MonoBehaviour
    {
        private void Start()
        {
            GameObject.FindGameObjectWithTag("ScoreSetter").GetComponent<ScoreSetter>().StartCounter();
        }
    }
}