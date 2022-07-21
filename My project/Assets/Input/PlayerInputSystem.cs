// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputSystem"",
    ""maps"": [
        {
            ""name"": ""GunAction"",
            ""id"": ""cdd1e898-ab4a-4507-b247-097f0e2bdbc7"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""bd3e5405-8f31-4c4b-9182-2e503c11538a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeGun1"",
                    ""type"": ""Button"",
                    ""id"": ""918493b7-7aa6-4674-8670-582ab71b5590"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeGun2"",
                    ""type"": ""Button"",
                    ""id"": ""14515cd2-77d7-4787-abd4-46321a3af347"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b9dee7d7-515e-4a73-8102-dd80018cff46"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7bd67a7f-89d7-4408-8454-0bc580e466e6"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeGun1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eea4c275-69c1-4f19-a4cd-9d339885868d"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeGun2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Move"",
            ""id"": ""57a0e712-b1bf-4b25-8159-ba00d7a558bf"",
            ""actions"": [
                {
                    ""name"": ""Run"",
                    ""type"": ""Value"",
                    ""id"": ""0f89b395-4730-4b72-9c14-fe286c60a86b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""af3860bb-da18-4083-9ef3-ec90b8c99b19"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Run WASD"",
                    ""id"": ""89a1998e-e64f-4848-94c0-33617eb894b2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1c7e5183-67e1-49ee-a4b7-7a95ed3a5b9d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9f88153b-74a1-4954-ac8e-5c468d7c01ed"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2c683f9b-9a02-454e-a5fa-e24f30cc360f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""16ee5791-0c4f-4a81-be80-1c9f0182835a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Run Arrow key"",
                    ""id"": ""6e4e01b6-f0c0-49d0-9a35-4e505c217c8c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3ec04938-1db5-4daf-8b5c-012eadc96ada"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""af6ed3b3-03a4-40c0-976f-b6839550dd8f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3ac709a5-94e0-4fe5-98de-b8859875ea6c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c6aac15f-fa12-4f88-9ec2-671a1080089a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""32b83d31-0e22-412c-9a79-5223d240f3c0"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GunAction
        m_GunAction = asset.FindActionMap("GunAction", throwIfNotFound: true);
        m_GunAction_Fire = m_GunAction.FindAction("Fire", throwIfNotFound: true);
        m_GunAction_ChangeGun1 = m_GunAction.FindAction("ChangeGun1", throwIfNotFound: true);
        m_GunAction_ChangeGun2 = m_GunAction.FindAction("ChangeGun2", throwIfNotFound: true);
        // Move
        m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
        m_Move_Run = m_Move.FindAction("Run", throwIfNotFound: true);
        m_Move_Dash = m_Move.FindAction("Dash", throwIfNotFound: true);
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

    // GunAction
    private readonly InputActionMap m_GunAction;
    private IGunActionActions m_GunActionActionsCallbackInterface;
    private readonly InputAction m_GunAction_Fire;
    private readonly InputAction m_GunAction_ChangeGun1;
    private readonly InputAction m_GunAction_ChangeGun2;
    public struct GunActionActions
    {
        private @PlayerInputSystem m_Wrapper;
        public GunActionActions(@PlayerInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_GunAction_Fire;
        public InputAction @ChangeGun1 => m_Wrapper.m_GunAction_ChangeGun1;
        public InputAction @ChangeGun2 => m_Wrapper.m_GunAction_ChangeGun2;
        public InputActionMap Get() { return m_Wrapper.m_GunAction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GunActionActions set) { return set.Get(); }
        public void SetCallbacks(IGunActionActions instance)
        {
            if (m_Wrapper.m_GunActionActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_GunActionActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GunActionActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GunActionActionsCallbackInterface.OnFire;
                @ChangeGun1.started -= m_Wrapper.m_GunActionActionsCallbackInterface.OnChangeGun1;
                @ChangeGun1.performed -= m_Wrapper.m_GunActionActionsCallbackInterface.OnChangeGun1;
                @ChangeGun1.canceled -= m_Wrapper.m_GunActionActionsCallbackInterface.OnChangeGun1;
                @ChangeGun2.started -= m_Wrapper.m_GunActionActionsCallbackInterface.OnChangeGun2;
                @ChangeGun2.performed -= m_Wrapper.m_GunActionActionsCallbackInterface.OnChangeGun2;
                @ChangeGun2.canceled -= m_Wrapper.m_GunActionActionsCallbackInterface.OnChangeGun2;
            }
            m_Wrapper.m_GunActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @ChangeGun1.started += instance.OnChangeGun1;
                @ChangeGun1.performed += instance.OnChangeGun1;
                @ChangeGun1.canceled += instance.OnChangeGun1;
                @ChangeGun2.started += instance.OnChangeGun2;
                @ChangeGun2.performed += instance.OnChangeGun2;
                @ChangeGun2.canceled += instance.OnChangeGun2;
            }
        }
    }
    public GunActionActions @GunAction => new GunActionActions(this);

    // Move
    private readonly InputActionMap m_Move;
    private IMoveActions m_MoveActionsCallbackInterface;
    private readonly InputAction m_Move_Run;
    private readonly InputAction m_Move_Dash;
    public struct MoveActions
    {
        private @PlayerInputSystem m_Wrapper;
        public MoveActions(@PlayerInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Run => m_Wrapper.m_Move_Run;
        public InputAction @Dash => m_Wrapper.m_Move_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Move; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MoveActions set) { return set.Get(); }
        public void SetCallbacks(IMoveActions instance)
        {
            if (m_Wrapper.m_MoveActionsCallbackInterface != null)
            {
                @Run.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnRun;
                @Dash.started -= m_Wrapper.m_MoveActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_MoveActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_MoveActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_MoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public MoveActions @Move => new MoveActions(this);
    public interface IGunActionActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnChangeGun1(InputAction.CallbackContext context);
        void OnChangeGun2(InputAction.CallbackContext context);
    }
    public interface IMoveActions
    {
        void OnRun(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
    }
}
