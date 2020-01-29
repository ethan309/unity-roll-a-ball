﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Resetable
{
    GameObject gameObject { get; }

    void ToggleReset(bool status);
}
