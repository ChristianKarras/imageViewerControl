using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActuatorControl
{
    public class PositionChangeReqestEventArgs : EventArgs
    {
        public readonly double newPosition;
        public readonly bool isRelativeChange;
        public PositionChangeReqestEventArgs(double posChange, bool isRel)
        {
            newPosition = posChange;
            isRelativeChange = isRel;
        }
    }
    public class PositionParametersChangeReqestEventArgs : EventArgs
    {
        public readonly double[] newStepSize;
        public readonly double newVelocity;
        public readonly double newAcceleration;
        public PositionParametersChangeReqestEventArgs(double[] _steps, double _vel, double _acc)
        {
            newStepSize = _steps;
            newAcceleration = _acc;
            newVelocity = _vel;
        }
    }
}
