
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace Anton.audioMove 
{
    public class audioMove : UdonSharpBehaviour
    {
        VRCPlayerApi playerApi;
        private Vector3 playerPosition;
        public GameObject audioObject;
        public Vector3 lowLimit;
        public Vector3 highLimit;

        public Vector3 clamp(Vector3 playerPosition, Vector3 lowLimit, Vector3 highLimit) 
        {
            if (playerPosition[0] > highLimit[0]) 
            {
                playerPosition[0] = highLimit[0];
            }
            if (playerPosition[1] > highLimit[1]) 
            {
                playerPosition[1] = highLimit[1];
            }
            if (playerPosition[2] > highLimit[2]) 
            {
                playerPosition[2] = highLimit[2];
            }

            if (playerPosition[0] < lowLimit[0]) 
            {
                playerPosition[0] = lowLimit[0];
            }
            if (playerPosition[1] < lowLimit[1]) 
            {
                playerPosition[1] = lowLimit[1];
            }
            if (playerPosition[2] < lowLimit[2]) 
            {
                playerPosition[2] = lowLimit[2];
            }

            return playerPosition;//new Vector3(-30,0,0);//
        }

        void Update()
        {
            playerPosition = Networking.LocalPlayer.GetPosition();
            audioObject.transform.position = clamp(playerPosition, lowLimit, highLimit);//new Vector3(-30,0,0);//
        }

        void Start()
        {
            
        }
    }
    
}

