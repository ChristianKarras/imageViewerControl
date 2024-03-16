using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace ActuatorControl
{




    public partial class ActuatorControl : UserControl
    {
        /// <summary>
        /// A controll for an actuator. Note: this isn't controlling any actuator but only for managing user inputs (It's a User controll!)
        /// </summary>
        /// <param name="NameOfActuator">Name of the actuator (will be displayed above controlles)</param>
        /// <param name="Direction">Direction of the actuator (will be displayed above controlles)</param>
        /// <param name="Stepsizes">Stepsizes: Small, Middle, Large, has to be array of length 3 -> if shorter, largers steps will be zero, if longer will be ignored</param>
        /// <param name="velocity">Speed for the actuator</param>
        /// <param name="acceleration">Acceleration for the actuator</param>
        /// <param name="unit">Name of the actuator (will be displayed above controlles)</param>
        public ActuatorControl(string NameOfActuator, string Direction, double[] StepSizes, double velocity, double acceleration, string Unit)
        {
            InitializeComponent();
            if (StepSizes != null)
            {
                if (StepSizes.Length > 0) { _stepsize[0] = StepSizes[0]; }
                if (StepSizes.Length > 1) { _stepsize[1] = StepSizes[1]; }
                if (StepSizes.Length > 2) { _stepsize[2] = StepSizes[2]; }
            }
            name = NameOfActuator;
            direction = Direction;
            unit = Unit;
            stepsize = _stepsize;
            this.velocity = velocity;
            this.acceleration = acceleration;


        }

     

        double[] _stepsize = new double[3] { 0, 0, 0 };

        /// <summary>
        /// Event is triggered, if some button is clicked or the position is updated. Eventargumetns are PositionChangeReqestEventArgs and they contain the new position as well as a flag to determine if motion is relative or not
        /// </summary>
        public event EventHandler<PositionChangeReqestEventArgs> PositionChange;
        protected virtual void OnPositionChanged(PositionChangeReqestEventArgs e) => PositionChange?.Invoke(this, e);

        /// <summary>
        /// Event is triggered, if some parameter (stepsize, velocity, acceleration) is changed. Eventargumetns are PositionParametersChangeReqestEventArgs and they contain the new stepsizes, velocity and accelerration
        /// </summary>

        public event EventHandler<PositionParametersChangeReqestEventArgs> PositionParametersChange;
        protected virtual void OnPositionParametersChanged(PositionParametersChangeReqestEventArgs e) => PositionParametersChange?.Invoke(this, e);

        /// <summary>
        /// Name of the actuator (will be displayed above controlles)
        /// </summary>             
        public string name { set => LAB_NAME.Text = value; }
        /// <summary>
        /// Direction of the actuator (will be displayed above controlles)
        /// </summary>
        public string direction { set => LAB_DIRECTION.Text = value; }
        /// <summary>
        /// Unit of the actuator (will be displayed above controlles)
        /// </summary>
        public string unit { set => LAB_UNI.Text = value; }
        /// <summary>
        /// Speed for the actuator
        /// </summary>
        public double velocity { set => cmTextBox_Vel.Text = formatText(value, "V"); }
        /// <summary>
        /// Acceleration for the actuator
        /// </summary>
        public double acceleration { set => cmTextBox_Acc.Text = formatText(value, "A"); }
        /// <summary>
        /// Stepsizes: Small, Middle, Large, has to be array of length 3 -> if shorter, largers steps will be zero, if longer will be ignored
        /// </summary>
        public double[] stepsize
        {
            set
            {
                if (value != null)
                {
                    if (value.Length > 0)
                    {
                        _stepsize[0] = value[0];
                        cmTextBox_StepMin.Text = formatText(value[0], "Min");
                    }
                    if (value.Length > 1)
                    {
                        _stepsize[1] = value[1];
                        cmTextBox_StepMid.Text = formatText(value[1], "Mid");
                    }
                    if (value.Length > 2)
                    {
                        _stepsize[2] = value[2];
                        cmTextBox_StepMax.Text = formatText(value[2], "Max");
                    }
                }
            }

        }

        private string formatText(double value, string input)
        {
            return (input + " = "+ String.Format("{0:0.000}", value));
        }
        private double valueFromString(string input)
        {
            input = input.Replace(",", ".");
            double val = 0;
            Regex rx = new Regex(@"-?\d+(?:\.\d+)?");
            MatchCollection matches = rx.Matches(input);
            if (matches.Count > 0) val = Convert.ToDouble(matches[0].Value, CultureInfo.InvariantCulture);
            return (val);
        }


        private void BUTTON_pos0_Click(object sender, EventArgs e)
        {
            OnPositionChanged(new PositionChangeReqestEventArgs(_stepsize[0], true));
        }

        private void BUTTON_pos1_Click(object sender, EventArgs e)
        {
            OnPositionChanged(new PositionChangeReqestEventArgs(_stepsize[1], true));
        }

        private void BUTTON_pos2_Click(object sender, EventArgs e)
        {
            OnPositionChanged(new PositionChangeReqestEventArgs(_stepsize[2], true));
        }

        private void BUTTON_neg0_Click(object sender, EventArgs e)
        {
            OnPositionChanged(new PositionChangeReqestEventArgs(-_stepsize[0], true));
        }

        private void BUTTON_neg1_Click(object sender, EventArgs e)
        {
            OnPositionChanged(new PositionChangeReqestEventArgs(-_stepsize[1], true));
        }

        private void BUTTON_neg2_Click(object sender, EventArgs e)
        {
            OnPositionChanged(new PositionChangeReqestEventArgs(-_stepsize[2], true));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            OnPositionChanged(new PositionChangeReqestEventArgs((double)numericUpDown1.Value, false));
        }

        private void cmTextBox_TextChanged(object sender, EventArgs e)
        {
            double[] _s = new double[3] { 0, 0, 0 };
            double _v = valueFromString(cmTextBox_Vel.Text);
            double _a = valueFromString(cmTextBox_Acc.Text);
            _s[0] = valueFromString(cmTextBox_StepMin.Text);
            _s[1] = valueFromString(cmTextBox_StepMid.Text);
            _s[2] = valueFromString(cmTextBox_StepMax.Text);
            OnPositionParametersChanged(new PositionParametersChangeReqestEventArgs(_s, _v, _a));
        }


    }
}
