using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : WorldObject
{
    //public override void SetHoverState(GameObject hoverObject)
    //{
    //    base.SetHoverState(hoverObject);
    //    //only handle input if owned by a human player and currently selected
    //    if (player && player.human && currentlySelected)
    //    {
    //        if (hoverObject.name == "Ground") player.hud.SetCursorState(CursorState.Move);
    //    }
    //}
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
    }

    protected override void OnGUI()
    {
        base.OnGUI();
    }
}
