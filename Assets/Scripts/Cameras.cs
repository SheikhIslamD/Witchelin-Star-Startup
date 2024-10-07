using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cameras : MonoBehaviour
{
    //assigned cameras in inspector
    [SerializeField] private CinemachineCamera pantryCam;
    [SerializeField] private CinemachineCamera kitchenCam;
    [SerializeField] private CinemachineCamera diningCam;
    [SerializeField] private CinemachineCamera everythingCam;
    //input control schemes
    InputAction previous;
    InputAction middle;
    InputAction next;
    InputAction back;

    //for making this a singleton
    public static Cameras instance;
    void Awake()
    {
        //for making this a singleton
        if (instance == null)
        {
            instance = this;
        }

        previous = InputSystem.actions.FindAction("Previous");
        middle = InputSystem.actions.FindAction("Middle");
        next = InputSystem.actions.FindAction("Next");
        back = InputSystem.actions.FindAction("Back");
    }

    //all inputs correlate to function to activate a single cam and disable all others 
    void Update()
    {
        if (previous.WasPerformedThisFrame())
        {
            PantryCam();
        }
        if (middle.WasPerformedThisFrame())
        {
            KitchenCam();
        }
        if (next.WasPerformedThisFrame())
        {
            DiningCam();
        }
        if (back.WasPerformedThisFrame())
        {
            EverythingCam();
        }
    }

    public void PantryCam()
    {
        pantryCam.Priority = 10;
        kitchenCam.Priority = 0;
        diningCam.Priority = 0;
        everythingCam.Priority = 0;
    }
    public void KitchenCam()
    {
        pantryCam.Priority = 0;
        kitchenCam.Priority = 10;
        diningCam.Priority = 0;
        everythingCam.Priority = 0;
    }
    public void DiningCam()
    {
        pantryCam.Priority = 0;
        kitchenCam.Priority = 0;
        diningCam.Priority = 10;
        everythingCam.Priority = 0;
    }
    public void EverythingCam()
    {
        pantryCam.Priority = 0;
        kitchenCam.Priority = 0;
        diningCam.Priority = 0;
        everythingCam.Priority = 10;
    }
}
