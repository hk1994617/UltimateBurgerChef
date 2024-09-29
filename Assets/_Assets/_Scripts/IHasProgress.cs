using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProgress
{
    public event EventHandler<OnProgressChangedEvendArgs> OnProgressChanged;

    public class OnProgressChangedEvendArgs : EventArgs
    {
        public float progressNormalized;
    }

}
