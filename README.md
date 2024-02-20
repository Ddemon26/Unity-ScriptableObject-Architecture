# Unity-Scriptable-Object-Architecture

This is built from the Unite 2017 Austin Conference by @roboryantron, Ryan Hipple.

## Scriptable Architect Variables

This repository contains a collection of ScriptableObject variables for Unity. These variables can be used to create a more modular and scalable architecture in your Unity projects.

### Features

- **BoolVariable**: A boolean variable that can be toggled, set to true or false, or set based on another BoolVariable.
- **FloatVariable**: A float variable with optional min-max clamping. It can be set directly, from another FloatVariable, or incremented by a specified amount.
- **StringVariable**: A simple string variable that can be set or retrieved.
- **Vector3Variable**: A Vector3 variable that can be set directly or from another Vector3Variable.
- **AudioClipListVariable**: A variable to reference an array of AudioClips.
- **AudioClipVariable**: A variable to reference an AudioClip.
- **ColorVariable**: A variable to reference a color.
- **Vector2Variable**: A variable to reference a Vector2.

Each variable type includes a corresponding reference type (e.g., BoolReference, FloatReference, StringReference, Vector3Reference) that allows for dynamic referencing between local and ScriptableObject values.

### Usage

1. Create a new ScriptableObject variable by right-clicking in the Project window, navigating to the "Variables" menu, and selecting the desired variable type.
2. Set the variable's value in the Inspector or through scripts.
3. Reference the variable in your scripts using the appropriate reference type.

### Custom Property Drawers and Editors

This project includes custom property drawers and editors to enhance the usability of the ScriptableObject variables in the Unity Editor.

- **FloatReferenceDrawer**: A custom property drawer for FloatReference that provides a convenient way to choose between using a constant value or a reference to a FloatVariable.
- **FloatVariableEditor**: A custom editor for FloatVariable that adds a slider in the inspector when the UseMinMaxSlider option is enabled, allowing for easy value adjustments within the specified range.

### Example Usage

Here's an example of how to use the FloatVariable in a Unity script:

```csharp
public class PlayerMovement : MonoBehaviour
{
    public FloatReference moveSpeed;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed.Value * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
```
