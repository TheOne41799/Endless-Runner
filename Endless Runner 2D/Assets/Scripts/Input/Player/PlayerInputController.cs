using UnityEngine;
using UnityEngine.InputSystem;

namespace EndlessRunner.Inputs
{
    public class PlayerInputController
    {
        private InputManager inputManager;
        private GameInputActionsAsset gameInputActionsAsset;

        public PlayerInputController(InputManager inputManager, GameInputActionsAsset gameInputActionsAsset)
        {
            this.inputManager = inputManager;
            this.gameInputActionsAsset = gameInputActionsAsset;
        }

        public void Enable()
        {
            gameInputActionsAsset?.Player.Enable();
            //Debug.Log("Enable");

            gameInputActionsAsset.Player.Jump.performed += OnJumpPerformedCallback;
        }

        public void Disable()
        {
            gameInputActionsAsset?.Player.Disable();
            //Debug.Log("Disable");

            gameInputActionsAsset.Player.Jump.performed -= OnJumpPerformedCallback;
        }

        private void OnJumpPerformedCallback(InputAction.CallbackContext ctx)
        {
            //Debug.Log("Jump");
        }

        private void OnJumpCanceledCallback(InputAction.CallbackContext ctx)
        {

        }

        private void HandleMoveInput()
        {

        }
    }
}