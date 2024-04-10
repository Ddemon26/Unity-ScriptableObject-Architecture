# Unity-Scriptable-Object-Architecture

This is built from the Unite 2017 Austin Conference by @roboryantron, Ryan Hipple.

## Navigation

* [Home](#unity-scriptable-object-architecture)
* [Features](#features)
* [Usage](#usage)
* [Example Usage](#example-usage)
* [Event Channels](#event-channels)

## GitHub URL Link
***
```
"com.ddemon26.scriptableobjectarchitecture": https://github.com/Ddemon26/Unity-ScriptableObject-Architecture.git
```
***
![ScriptableObject-](https://github.com/Ddemon26/Unity-ScriptableObject-Architecture/assets/95268795/0540d975-d821-4b5c-be7f-51253df91c4d)
***

## Scriptable Architect Variables

This repository contains a collection of ScriptableObject variables for Unity. These variables can be used to create a more modular and scalable architecture in your Unity projects.

***

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

***

![image-1 png](https://github.com/Ddemon26/Unity-ScriptableObject-Architecture/assets/95268795/4b2fa58c-b7ca-4504-8288-e7705fd8bd15)

***

### Usage

1. Create a new ScriptableObject variable by right-clicking in the Project window, navigating to the "Variables" menu, and selecting the desired variable type.
2. Set the variable's value in the Inspector or through scripts.
3. Reference the variable in your scripts using the appropriate reference type.

***

### Custom Property Drawers and Editors

This project includes custom property drawers and editors to enhance the usability of the ScriptableObject variables in the Unity Editor.

- **ReferenceDrawer**: A custom property drawer for FloatReference that provides a convenient way to choose between using a constant value or a reference to a FloatVariable.
- ![GifReference](https://github.com/Ddemon26/Unity-ScriptableObject-Architecture/assets/95268795/71e3c096-a90d-45fa-be94-f994681396d8)
- **VariableEditor**: A custom editor for FloatVariable that adds a slider in the inspector when the UseMinMaxSlider option is enabled, allowing for easy value adjustments within the specified range.
- ![GifVariable](https://github.com/Ddemon26/Unity-ScriptableObject-Architecture/assets/95268795/8beb9f19-a628-4e8a-b388-33e4bf7df835)


***

### Example Usage

Here's an example of how to use the FloatVariable in a Unity script:

```csharp
using ScriptableArchitect.variables;
using UnityEngine;

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
***

## Event Channels

This architecture includes a system for event channels that allows for decoupled communication between different parts of your game. Event channels are defined for different data types, enabling the broadcasting and listening of events with specific payloads.

- **EventChannel**: An abstract class for creating event channels that can handle events of a specific type.
- **EventListener**: A component that listens for events on a specific event channel and invokes a response when an event is broadcasted.
- **FloatEventChannel & FloatEventListener**: Specialized event channel and listener for events carrying a `float` payload.
- **IntEventChannel & IntEventListener**: Specialized event channel and listener for events carrying an `int` payload.

Event channels provide a flexible way to send notifications or data across different parts of your project without requiring a direct reference between the sender and the receiver.

***

### Example Usage

Here's an example of how to use the EventChannel in a Unity script:

```csharp
using ScriptableArchitect.Events;
using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    // Reference to the event channel asset
    public EventChannel<float> floatEventChannel;

    // Method to invoke the event
    public void TriggerFloatEvent(float value)
    {
        floatEventChannel.Invoke(value);
    }
}

// Listener component that responds to the event
public class FloatEventListener : MonoBehaviour
{
    public EventListener<float> listener;

    private void OnEnable()
    {
        listener.Register();
    }

    private void OnDisable()
    {
        listener.Deregister();
    }

    // This method will be called when the event is invoked
    public void OnFloatEvent(float value)
    {
        Debug.Log($"Received float event with value: {value}");
    }
}
```

In this example, `ExampleUsage` is a class that can trigger a float event through the `floatEventChannel`. The `FloatEventListener` class listens for the event and executes the `OnFloatEvent` method when the event is triggered.

***
