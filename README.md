# UnityVirtualKeyboard v.0.1
This is an early version of the Unity Virtual Keyboard. 

## Getting started
Open the scene: 

```Assets/Plugins/VirtualKeyboard/Examples/Example 1 - Simple Style/Scenes/Example_1.unity```
## Features:
### Input fields support
Currently supported input fields are:
* uGUI native Input Field
* Text Mesh Pro Input Field
* You can add support for a custom field by extending **AbstractInputFieldSelectionConfig**.

Only input fields listed in the **selection config container** (*InputFieldSelectionConfigContainer*) will be "noticed" by the virtual keyboard. Therefore, if you want to ignore some field types, remove the corresponding instance of AbstractInputFieldSelectionConfig-based config from the container.

### Keyboard Controllers
### Button Styles
### Layouts
### Languages
### VR Support
### Tests
The project currently has: 
* **102** Play Mode Tests
* **5** Edit Mode Tests


## Plugins
The following plugins are used in the project:
* UniRx
* Zenject
* NSubstitute
* NUnit

