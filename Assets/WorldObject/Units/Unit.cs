using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class Unit : WorldObject
{
    public float moveSpeed, rotateSpeed;

	protected bool moving, rotating;
    private Vector3 destination;
    private Quaternion targetRotation;
  
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
	

	}

    protected override void Update()
    {
        base.Update();
        if (rotating) TurnToTarget();
        else if (moving) MakeMove();
    }

    protected override void OnGUI()
    {
        base.OnGUI();
    }
    /* Public Methods */

    public override void SetHoverState(GameObject hoverObject)
    {
        base.SetHoverState(hoverObject);
        //only handle input if owned by a human player and currently selected
        if (player && player.human && currentlySelected)
        {
            if (hoverObject.transform.parent.name == "Ground") player.hud.SetCursorState(CursorState.Move);
        }
    }
	public override void MouseClick(GameObject hitObject, Vector3 hitPoint, Player controller)
	{
		base.MouseClick(hitObject, hitPoint, controller);
	

		if (player && player.human && currentlySelected)
		{

			if (hitObject.transform.parent.name == "Ground" && hitPoint != ResourceManager.InvalidPosition)
			{
				float x = hitPoint.x;
				//makes sure that the unit stays on top of the surface it is on
				float y = hitPoint.y;
				float z = hitPoint.z;
				Vector3 destination = new Vector3(x, y, z);
				StartMove(destination);
			}
		}
	}

	public void StartMove(Vector3 destination)
	{
		this.destination = destination;
        targetRotation = Quaternion.LookRotation(destination - transform.position);
        rotating = true;
		moving = false;
	}

	/* Private worker methods */

	private void TurnToTarget()
	{
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed);
		//sometimes it gets stuck exactly 180 degrees out in the calculation and does nothing, this check fixes that
		Quaternion inverseTargetRotation = new Quaternion(-targetRotation.x, -targetRotation.y, -targetRotation.z, -targetRotation.w);
		if (transform.rotation == targetRotation || transform.rotation == inverseTargetRotation)
		{
			rotating = false;
			moving = true;
		}
		CalculateBounds();
	}

	private void MakeMove()
	{
        //CharacterController controller = this.GetComponentInChildren<CharacterController>();
        //controller.SimpleMove(destination *  Time.deltaTime * moveSpeed);
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);
        if (transform.position == destination) moving = false;
        CalculateBounds();
    }
}
