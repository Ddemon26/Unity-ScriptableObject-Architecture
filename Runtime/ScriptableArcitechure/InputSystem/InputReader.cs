using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine;
using static PlayerInput;

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
        Rotate.Invoke(context.ReadValue<Vector2>(), IsDeviceMouse(context));
    }
    bool IsDeviceMouse(InputAction.CallbackContext context) => context.control.device.name == "Mouse";
    public void OnRotatePlayerController(InputAction.CallbackContext context)
    {
        RotateController.Invoke(context.ReadValue<Vector2>(), IsDeviceGamepad(context));
    }
    bool IsDeviceGamepad(InputAction.CallbackContext context) => context.control.device.name == "<Gamepad>/RightStick";

    public void OnRun(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Run.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Run.Invoke(false);
                break;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Jump.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Jump.Invoke(false);
                break;
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Attack.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Attack.Invoke(false);
                break;
        }
    }
    public void OnBlock(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Block.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Block.Invoke(false);
                break;
        }
    }
    public void OnCrouch(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Crouch.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Crouch.Invoke(false);
                break;
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Interact.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Interact.Invoke(false);
                break;
        }
    }
    public void OnEscape(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Escape.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Escape.Invoke(false);
                break;
        }
    }
    public void OnOpenUI(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                OpenUI.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                OpenUI.Invoke(false);
                break;
        }
    }
    public void OnEmote(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                Emote.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                Emote.Invoke(false);
                break;
        }
    }
    public void OnCommandKey(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                CommandKey.Invoke(true);
                break;
            case InputActionPhase.Canceled:
                CommandKey.Invoke(false);
                break;
        }
    }
}
