using UnityEngine;
using UnityEngine.Serialization;

namespace StarterAssets
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [FormerlySerializedAs("playerInputs")] [FormerlySerializedAs("starterAssetsInputs")] [Header("Output")]
        public StarterAssets starterAssets;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            starterAssets.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            starterAssets.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            starterAssets.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            starterAssets.SprintInput(virtualSprintState);
        }
        
    }

}
