# UnityVirtualKeyboard v.0.1
This is an early version of the Unity Virtual Keyboard. 

![UnityVirtualKeyboard demo](https://media.giphy.com/media/5ngLQHM48BlMmQ4jqA/giphy.gif)

## Getting started
Please note that the project is using the new Prefab workflows whic are availble starting from **Unity 2018.3**.

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
Virtual Keyboard has several controllers that affect the behaviour. 

All the controllers are optional. If you do not need a certain behaviour, exclude the controllers.
*Detailed description will be added soon*
#### Show/Hide Controller
#### Position Controller
#### Canvas Controller
#### Layout Controller

*Description will be added soon*
### Button Styles
*Description will be added soon*
### Layouts
*Description will be added soon*
### Languages
*Description will be added soon*
### VR Support
*Description will be added soon*
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

