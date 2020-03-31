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
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""059ca558-f79e-4538-b00e-b52e5170c24c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""bc8ca778-f391-4aab-aee3-dabecc29095c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ab375159-094d-40f6-ab77-a3b0fb2ec5d2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dd494448-4d2d-423b-96c9-7f97fa222263"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""558496c9-b420-43a0-b96c-629f49c684bb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c2964682-32e7-492a-9f08-6b931f41398a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // map0
        m_map0 = asset.FindActionMap("map0", throwIfNotFound: true);
        m_map0_move = m_map0.FindAction("move", throwIfNotFound: true);
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
    private readonly InputAction m_map0_move;
    public struct Map0Actions
    {
        private @PlyerInputActions m_Wrapper;
        public Map0Actions(@PlyerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_map0_move;
        public InputActionMap Get() { return m_Wrapper.m_map0; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Map0Actions set) { return set.Get(); }
        public void SetCallbacks(IMap0Actions instance)
        {
            if (m_Wrapper.m_Map0ActionsCallbackInterface != null)
            {
                @move.started -= m_Wrapper.m_Map0ActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_Map0ActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_Map0ActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_Map0ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
            }
        }
    }
    public Map0Actions @map0 => new Map0Actions(this);
    public interface IMap0Actions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
