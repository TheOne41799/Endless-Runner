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
            Debug.Log("Enable");
        }

        public void Disable()
        {
            gameInputActionsAsset?.Player.Disable();
            Debug.Log("Disable");
        }

        private void OnMovePerformedCallback(InputAction.CallbackContext ctx)
        {
            
        }

        private void OnMoveCanceledCallback(InputAction.CallbackContext ctx)
        {
            
        }

        private void HandleMoveInput()
        {
            
        }
    }
}