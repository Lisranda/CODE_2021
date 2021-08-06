// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""CharacterInput"",
            ""id"": ""48af32ab-832a-4364-9ca5-7c3cf474096d"",
            ""actions"": [
                {
                    ""name"": ""Cursor"",
                    ""type"": ""Value"",
                    ""id"": ""f5da95b6-8be8-4ae9-b820-332f5d75f5e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Locomotion"",
                    ""type"": ""Value"",
                    ""id"": ""d9987911-167c-4b06-af87-0682df4044ba"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""194b4731-1010-4d40-8f51-2ca343933cbf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""ce8e613b-b70d-439b-be20-73ed1ed5ef05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""db592f82-f401-4d7f-bc0d-0f39661456fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cfe42c4c-f4cc-4bdf-9753-b546c54b3d80"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24bc1af9-29a9-4958-89ff-efc428e9cd34"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""720ec474-2adb-4b94-98ca-eb1a7cfbc128"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""2dd74ebb-bbad-4963-9827-5bc1954da13f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Locomotion"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""69cdb7e0-f58d-4e4c-b278-0f6d67a63462"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""77d83b61-0e07-47bc-812f-e1f68425db67"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0f70bf84-a9c8-45c2-9a2a-1fbf9d51e364"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e77d02f7-aee7-4f9a-89d4-ff7817d4c22a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Locomotion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6cb1518e-32bc-4b84-bd34-59b082c314a0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CharacterInput
        m_CharacterInput = asset.FindActionMap("CharacterInput", throwIfNotFound: true);
        m_CharacterInput_Cursor = m_CharacterInput.FindAction("Cursor", throwIfNotFound: true);
        m_CharacterInput_Locomotion = m_CharacterInput.FindAction("Locomotion", throwIfNotFound: true);
        m_CharacterInput_Sprint = m_CharacterInput.FindAction("Sprint", throwIfNotFound: true);
        m_CharacterInput_Walk = m_CharacterInput.FindAction("Walk", throwIfNotFound: true);
        m_CharacterInput_Dodge = m_CharacterInput.FindAction("Dodge", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // CharacterInput
    private readonly InputActionMap m_CharacterInput;
    private ICharacterInputActions m_CharacterInputActionsCallbackInterface;
    private readonly InputAction m_CharacterInput_Cursor;
    private readonly InputAction m_CharacterInput_Locomotion;
    private readonly InputAction m_CharacterInput_Sprint;
    private readonly InputAction m_CharacterInput_Walk;
    private readonly InputAction m_CharacterInput_Dodge;
    public struct CharacterInputActions
    {
        private @PlayerInput m_Wrapper;
        public CharacterInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Cursor => m_Wrapper.m_CharacterInput_Cursor;
        public InputAction @Locomotion => m_Wrapper.m_CharacterInput_Locomotion;
        public InputAction @Sprint => m_Wrapper.m_CharacterInput_Sprint;
        public InputAction @Walk => m_Wrapper.m_CharacterInput_Walk;
        public InputAction @Dodge => m_Wrapper.m_CharacterInput_Dodge;
        public InputActionMap Get() { return m_Wrapper.m_CharacterInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterInputActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterInputActions instance)
        {
            if (m_Wrapper.m_CharacterInputActionsCallbackInterface != null)
            {
                @Cursor.started -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnCursor;
                @Cursor.performed -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnCursor;
                @Cursor.canceled -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnCursor;
                @Locomotion.started -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnLocomotion;
                @Locomotion.performed -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnLocomotion;
                @Locomotion.canceled -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnLocomotion;
                @Sprint.started -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnSprint;
                @Walk.started -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnWalk;
                @Dodge.started -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnDodge;
                @Dodge.performed -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnDodge;
                @Dodge.canceled -= m_Wrapper.m_CharacterInputActionsCallbackInterface.OnDodge;
            }
            m_Wrapper.m_CharacterInputActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Cursor.started += instance.OnCursor;
                @Cursor.performed += instance.OnCursor;
                @Cursor.canceled += instance.OnCursor;
                @Locomotion.started += instance.OnLocomotion;
                @Locomotion.performed += instance.OnLocomotion;
                @Locomotion.canceled += instance.OnLocomotion;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Dodge.started += instance.OnDodge;
                @Dodge.performed += instance.OnDodge;
                @Dodge.canceled += instance.OnDodge;
            }
        }
    }
    public CharacterInputActions @CharacterInput => new CharacterInputActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface ICharacterInputActions
    {
        void OnCursor(InputAction.CallbackContext context);
        void OnLocomotion(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
    }
}
