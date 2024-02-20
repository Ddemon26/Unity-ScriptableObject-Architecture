# Unity-Scriptable-Object-Architecture
this is built from the Unite 2017 Austin Conference.  @roboryantron Ryan Hipple

# Scriptable Architect Variables
This repository contains a collection of ScriptableObject variables for Unity. These variables can be used to create a more modular and scalable architecture in your Unity projects.

Features
BoolVariable: A boolean variable that can be toggled, set to true or false, or set based on another BoolVariable.
FloatVariable: A float variable with optional min-max clamping. It can be set directly, from another FloatVariable, or incremented by a specified amount.
StringVariable: A simple string variable.
Vector3Variable: A Vector3 variable that can be set directly or from another Vector3Variable.
Each variable type also includes a corresponding reference type (e.g., BoolReference, FloatReference) that allows for dynamic referencing between local and ScriptableObject values.

Usage
Create a new ScriptableObject variable by right-clicking in the Project window, navigating to the "Variables" menu, and selecting the desired variable type.
Set the variable's value in the Inspector or through scripts.
Reference the variable in your scripts using the appropriate reference type.

## Example Usage

Here's an example of how to use the `FloatVariable` in a Unity script:

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

Installation
To use these variables in your project, simply clone this repository or download the desired script files and place them in your Unity project's Assets folder.

License
This project is licensed under the MIT License - see the LICENSE file for details.
