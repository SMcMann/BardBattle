using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TickSystem : MonoBehaviour
{

  // public static event EventHandler<OnTickEventArgs> onTick;
  private const float TICK_TIMER_MAX = .2f;

  private int tick;
  private float tickTimer;

  private void Awake() {
    tick = 0;
  }

  // Update is called once per frame
  void Update()
  {
      tickTimer += Time.deltaTime;
      tick++;
      // if (onTick !== null) onTick(this, new OnTickEventArgs { tick = tick });

      // Debug.Log("tick: " + tick);
  }
}
