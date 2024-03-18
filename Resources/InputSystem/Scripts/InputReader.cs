using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine;
using static PlayerInput;

namespace ScriptableArchitect.InputSettings
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "PlayerController/InputReader")]
    public class InputReader : ScriptableObject, ICharacterControlsActions
    {
        PlayerInput inputActions;

        public event UnityAction<Vector2> Move = delegate { };
        public Vector3 Direction => inputActions.CharacterControls.Move.ReadValue<Vector2>();

        public event UnityAction<Vector2, bool> Rotate = delegate { };
        public event UnityAction<Vector2, bool> RotateController = delegate { };
        public event UnityAction<float> ScrollWheel = delegate { };

        public event UnityAction<bool> Jump = delegate { };
        public event UnityAction<bool> Run = delegate { };
        public event UnityAction<bool> Attack = delegate { };
        public event UnityAction<bool> Crouch = delegate { };
        public event UnityAction<bool> Block = delegate { };
        public event UnityAction<bool> Interact = delegate { };
        public event UnityAction<bool> Escape = delegate { };
        public event UnityAction<bool> OpenUI = delegate { };
        public event UnityAction<bool> Emote = delegate { };
        public event UnityAction<bool> CommandKey = delegate { };

        #region inputActions Initialization

        void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerInput();
                inputActions.CharacterControls.SetCallbacks(this);
            }
        }

        public void EnablePlayerActions()
        {
            inputActions.Enable();
        }
        public void DisablePlayerActions()
        {
            inputActions.Disable();
        }

        #endregion

        #region Helper Methods

        private bool IsMouseDevice(InputAction.CallbackContext context) => context.control.device.name == "Mouse";
        private bool IsGamepadDevice(InputAction.CallbackContext context) => context.control.device.name.Contains("Gamepad");
        private void HandleBinaryAction(InputAction.CallbackContext context, UnityAction<bool> action)
        {
            if (context.phase == InputActionPhase.Started)
                action.Invoke(true);
            else if (context.phase == InputActionPhase.Canceled)
                action.Invoke(false);
        }

        #endregion

        #region ReadValue Actions

        public void OnMove(InputAction.CallbackContext context)
        {
            Move.Invoke(context.ReadValue<Vector2>());
        }
        public void OnScrollWheel(InputAction.CallbackContext context)
        {
            ScrollWheel.Invoke(context.ReadValue<float>());
        }

        public void OnRotatePlayer(InputAction.CallbackContext context)
        {
            Rotate.Invoke(context.ReadValue<Vector2>(), IsMouseDevice(context));
        }
        //bool IsDeviceMouse(InputAction.CallbackContext context) => context.control.device.name == "Mouse";
        public void OnRotatePlayerController(InputAction.CallbackContext context)
        {
            RotateController.Invoke(context.ReadValue<Vector2>(), IsGamepadDevice(context));
        }
        //bool IsDeviceGamepad(InputAction.CallbackContext context) => context.control.device.name == "<Gamepad>/RightStick";

        #endregion 

        #region Button Actions

        public void OnRun(InputAction.CallbackContext context)
        {
            HandleBinaryAction(context, Run);
        }
        public void OnJump(InputAction.CallbackContext context)
        {
            HandleBinaryAction(context, Jump);
        }
        public void OnAttack(InputAction.CallbackContext context)
        {
            HandleBinaryAction(context, Attack);
        }
        public void OnBlock(InputAction.CallbackContext context)
        {
            HandleBinaryAction(context, Block);
        }
        public void OnCrouch(InputAction.CallbackContext context)
        {
            HandleBinaryAction(context, Crouch);
        }
        public void OnInteract(InputAction.CallbackContext context)
        {
            HandleBinaryAction(context, Interact);
        }
        public void OnEscape(InputAction.CallbackContext context)
        {
            HandleBinaryAction(context, Escape);
        }
        public void OnOpenUI(InputAction.CallbackContext context)
        {
            HandleBinaryAction(context, OpenUI);
        }
        public void OnEmote(InputAction.CallbackContext context)
        {
            HandleBinaryAction(context, Emote);
        }
        public void OnCommandKey(InputAction.CallbackContext context)
        {
            HandleBinaryAction(context, CommandKey);
        }

        #endregion
    }
}