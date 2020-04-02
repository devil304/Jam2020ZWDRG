// GENERATED AUTOMATICALLY FROM 'Assets/scripts/PlyerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlyerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlyerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlyerInputActions"",
    ""maps"": [
        {
            ""name"": ""map0"",
            ""id"": ""d1e150ae-10dd-4003-9f45-da63604cabf3"",
            ""actions"": [
                {
                    ""name"": ""moveChild"",
                    ""type"": ""Value"",
                    ""id"": ""059ca558-f79e-4538-b00e-b52e5170c24c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveMother"",
                    ""type"": ""Button"",
                    ""id"": ""86bbe513-b8d8-472c-949d-2143c35670d7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionMother"",
                    ""type"": ""Button"",
                    ""id"": ""828b2899-0810-46e9-9a1d-8826c4a5a99d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionChild"",
                    ""type"": ""Button"",
                    ""id"": ""f9b2be76-89b3-49f2-aa88-0cee58f35bc0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpChild"",
                    ""type"": ""Button"",
                    ""id"": ""d4244de2-0534-4a5b-bac6-3dd32b9a5e09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD"",
                    ""id"": ""bc8ca778-f391-4aab-aee3-dabecc29095c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveChild"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""ab375159-094d-40f6-ab77-a3b0fb2ec5d2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveChild"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""dd494448-4d2d-423b-96c9-7f97fa222263"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveChild"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""60981b70-7c00-4ebd-a23e-3c816c63012f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveMother"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5c6fca36-35e2-47d6-aeb0-777ff907de47"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveMother"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c7031bc-aa29-427f-b206-d06c8f08026f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveMother"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9eb5f985-9a51-499a-a4db-54d1a9c1928a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveMother"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""797caaa0-2fa0-4ff1-9f84-57f5f9181603"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveMother"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""255e885a-769c-4bcd-b737-4354b216569a"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionMother"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b517f4c5-1e40-4c4f-aa80-002378f8e0b0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionChild"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e2343ef-cc2f-4ab0-8a5e-02fa7beeed26"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JumpChild"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // map0
        m_map0 = asset.FindActionMap("map0", throwIfNotFound: true);
        m_map0_moveChild = m_map0.FindAction("moveChild", throwIfNotFound: true);
        m_map0_MoveMother = m_map0.FindAction("MoveMother", throwIfNotFound: true);
        m_map0_ActionMother = m_map0.FindAction("ActionMother", throwIfNotFound: true);
        m_map0_ActionChild = m_map0.FindAction("ActionChild", throwIfNotFound: true);
        m_map0_JumpChild = m_map0.FindAction("JumpChild", throwIfNotFound: true);
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

    // map0
    private readonly InputActionMap m_map0;
    private IMap0Actions m_Map0ActionsCallbackInterface;
    private readonly InputAction m_map0_moveChild;
    private readonly InputAction m_map0_MoveMother;
    private readonly InputAction m_map0_ActionMother;
    private readonly InputAction m_map0_ActionChild;
    private readonly InputAction m_map0_JumpChild;
    public struct Map0Actions
    {
        private @PlyerInputActions m_Wrapper;
        public Map0Actions(@PlyerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @moveChild => m_Wrapper.m_map0_moveChild;
        public InputAction @MoveMother => m_Wrapper.m_map0_MoveMother;
        public InputAction @ActionMother => m_Wrapper.m_map0_ActionMother;
        public InputAction @ActionChild => m_Wrapper.m_map0_ActionChild;
        public InputAction @JumpChild => m_Wrapper.m_map0_JumpChild;
        public InputActionMap Get() { return m_Wrapper.m_map0; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Map0Actions set) { return set.Get(); }
        public void SetCallbacks(IMap0Actions instance)
        {
            if (m_Wrapper.m_Map0ActionsCallbackInterface != null)
            {
                @moveChild.started -= m_Wrapper.m_Map0ActionsCallbackInterface.OnMoveChild;
                @moveChild.performed -= m_Wrapper.m_Map0ActionsCallbackInterface.OnMoveChild;
                @moveChild.canceled -= m_Wrapper.m_Map0ActionsCallbackInterface.OnMoveChild;
                @MoveMother.started -= m_Wrapper.m_Map0ActionsCallbackInterface.OnMoveMother;
                @MoveMother.performed -= m_Wrapper.m_Map0ActionsCallbackInterface.OnMoveMother;
                @MoveMother.canceled -= m_Wrapper.m_Map0ActionsCallbackInterface.OnMoveMother;
                @ActionMother.started -= m_Wrapper.m_Map0ActionsCallbackInterface.OnActionMother;
                @ActionMother.performed -= m_Wrapper.m_Map0ActionsCallbackInterface.OnActionMother;
                @ActionMother.canceled -= m_Wrapper.m_Map0ActionsCallbackInterface.OnActionMother;
                @ActionChild.started -= m_Wrapper.m_Map0ActionsCallbackInterface.OnActionChild;
                @ActionChild.performed -= m_Wrapper.m_Map0ActionsCallbackInterface.OnActionChild;
                @ActionChild.canceled -= m_Wrapper.m_Map0ActionsCallbackInterface.OnActionChild;
                @JumpChild.started -= m_Wrapper.m_Map0ActionsCallbackInterface.OnJumpChild;
                @JumpChild.performed -= m_Wrapper.m_Map0ActionsCallbackInterface.OnJumpChild;
                @JumpChild.canceled -= m_Wrapper.m_Map0ActionsCallbackInterface.OnJumpChild;
            }
            m_Wrapper.m_Map0ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @moveChild.started += instance.OnMoveChild;
                @moveChild.performed += instance.OnMoveChild;
                @moveChild.canceled += instance.OnMoveChild;
                @MoveMother.started += instance.OnMoveMother;
                @MoveMother.performed += instance.OnMoveMother;
                @MoveMother.canceled += instance.OnMoveMother;
                @ActionMother.started += instance.OnActionMother;
                @ActionMother.performed += instance.OnActionMother;
                @ActionMother.canceled += instance.OnActionMother;
                @ActionChild.started += instance.OnActionChild;
                @ActionChild.performed += instance.OnActionChild;
                @ActionChild.canceled += instance.OnActionChild;
                @JumpChild.started += instance.OnJumpChild;
                @JumpChild.performed += instance.OnJumpChild;
                @JumpChild.canceled += instance.OnJumpChild;
            }
        }
    }
    public Map0Actions @map0 => new Map0Actions(this);
    public interface IMap0Actions
    {
        void OnMoveChild(InputAction.CallbackContext context);
        void OnMoveMother(InputAction.CallbackContext context);
        void OnActionMother(InputAction.CallbackContext context);
        void OnActionChild(InputAction.CallbackContext context);
        void OnJumpChild(InputAction.CallbackContext context);
    }
}
