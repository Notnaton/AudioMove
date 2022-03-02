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

        public Vector3 clamp(Vector3 playerPos, Vector3 lowLimit, Vector3 highLimit) 
        {
            playerPos = Vector3.Min(playerPos, highLimit);
            playerPos = Vector3.Max(playerPos, lowLimit);
            return playerPos;
        }

        void Update()
        {
            playerPosition = Networking.LocalPlayer.GetPosition();
            playerPosition = Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Head);
            audioObject.transform.position = clamp(playerPosition, lowLimit, highLimit);
        }
    }
}

