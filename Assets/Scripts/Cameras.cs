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
    //HUD canvases of each area
    [SerializeField] private CanvasGroup pantryCanvas;
    [SerializeField] private CanvasGroup kitchenCanvas;
    [SerializeField] private CanvasGroup diningCanvas;
    [SerializeField] private CanvasGroup everythingCanvas;
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

        pantryCam.Priority = 0;
        kitchenCam.Priority = 0;
        diningCam.Priority = 0;
        everythingCam.Priority = 0;

        CanvasGroupOff(pantryCanvas);
        CanvasGroupOff(kitchenCanvas);
        CanvasGroupOff(diningCanvas);
        CanvasGroupOff(everythingCanvas);

        //start with everything view
        EverythingCam();
    }

    //all inputs correlate to function to activate a single cam and disable all others
    //save lines and cleanup later by switching Cam() code to be like CanvasSwap() code?
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
        CanvasSwap(pantryCanvas);
    }
    public void KitchenCam()
    {
        pantryCam.Priority = 0;
        kitchenCam.Priority = 10;
        diningCam.Priority = 0;
        everythingCam.Priority = 0;
        CanvasSwap(kitchenCanvas);
    }
    public void DiningCam()
    {
        pantryCam.Priority = 0;
        kitchenCam.Priority = 0;
        diningCam.Priority = 10;
        everythingCam.Priority = 0;
        CanvasSwap(diningCanvas);
    }
    public void EverythingCam()
    {
        pantryCam.Priority = 0;
        kitchenCam.Priority = 0;
        diningCam.Priority = 0;
        everythingCam.Priority = 10;
        CanvasSwap(everythingCanvas);
    }

    //this pops up the correct area HUD while disabling the others
    public void CanvasSwap(CanvasGroup whichCanvas)
    {
        CanvasGroupOff(pantryCanvas);
        CanvasGroupOff(kitchenCanvas);
        CanvasGroupOff(diningCanvas);
        CanvasGroupOff(everythingCanvas);
        CanvasGroupOn(whichCanvas);
    }

    public void CanvasGroupOff(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void CanvasGroupOn(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}
