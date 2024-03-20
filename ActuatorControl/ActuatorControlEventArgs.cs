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
        public readonly string direction;
        public PositionChangeReqestEventArgs(double posChange, bool isRel, string direction)
        {
            newPosition = posChange;
            isRelativeChange = isRel;
            this.direction = direction;
        }
    }
    public class PositionParametersChangeReqestEventArgs : EventArgs
    {
        public readonly double[] newStepSize;
        public readonly double newVelocity;
        public readonly double newAcceleration;
        public readonly string direction;
        public PositionParametersChangeReqestEventArgs(double[] _steps, double _vel, double _acc, string direction)
        {
            newStepSize = _steps;
            newAcceleration = _acc;
            newVelocity = _vel;
            this.direction = direction;
        }
    }
}
