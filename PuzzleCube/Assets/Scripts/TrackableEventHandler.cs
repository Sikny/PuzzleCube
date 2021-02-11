using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackableEventHandler : DefaultTrackableEventHandler
{
    public BallTrigger ball;
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound ();
        ball.DoEnable();
    }
}
