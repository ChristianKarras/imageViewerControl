namespace ActuatorControl
{
    public partial class TestActuatorControl : Form
    {
        public TestActuatorControl()
        {

            double[] stepsizes = new double[3] { 0.005, 0.02, 0.1 };
            actuatorControl1 = new ActuatorControl("MyActuator", "X", stepsizes, 100, 0, "mm");

            // 
            // actuatorControl1
            // 
            actuatorControl1.Location = new Point(66, 35);
            actuatorControl1.Name = "actuatorControl1";
            actuatorControl1.Size = new Size(158, 134);
            actuatorControl1.TabIndex = 0;
            InitializeComponent();
            actuatorControl1.PositionChange += ActuatorCtrl_OnPosChange;
            actuatorControl1.PositionParametersChange += ActuatorCtrl_OnParaChange;
            
        }

        private void ActuatorCtrl_OnPosChange(object sender, PositionChangeReqestEventArgs e)
        {
            Console.WriteLine("Pos changed: {0}, Relative?  {1}", e.newPosition, e.isRelativeChange);
        }

        private void ActuatorCtrl_OnParaChange(object sender, PositionParametersChangeReqestEventArgs e)
        {
            Console.WriteLine("input changed: stepsizes: {0}, {1}, {2}, v : {3}, a: {4}", e.newStepSize[0], e.newStepSize[1], e.newStepSize[2],e.newVelocity, e.newAcceleration);

        }
    }
}
