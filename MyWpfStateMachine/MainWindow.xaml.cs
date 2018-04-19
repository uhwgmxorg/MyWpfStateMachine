using MyWpfStateMachine.Tools;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace MyWpfStateMachine
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        #region INotifyPropertyChanged Properties
        private string message;
        public string Message
        {
            get { return message; }
            set { SetField(ref message, value, nameof(Message)); }
        }

        private string machineState;
        public string MachineState
        {
            get { return machineState; }
            set { SetField(ref machineState, value, nameof(MachineState)); }
        }
        #endregion

        public MyStateMachine MyMachine { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            MyMachine = new MyStateMachine();
            MachineState = MyMachine.CurrentState.ToString();
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        /// <summary>
        /// Button_Next_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            StateMachineNextAction();
        }

        /// <summary>
        /// Button_Start_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            MyMachine = new MyStateMachine();
            MachineState = MyMachine.CurrentState.ToString();
            Message = "Start";
        }

        /// <summary>
        /// Button_Command1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Command1_Click(object sender, RoutedEventArgs e)
        {
            Message = "Command #1";
            try{ MyMachine.MoveNext(MyStateMachine.Command.Command01); } catch (System.Exception ex) { LST.Beep(); Message = ex.Message; }            
            MachineState = MyMachine.CurrentState.ToString();
        }

        /// <summary>
        /// Button_Command2_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Command2_Click(object sender, RoutedEventArgs e)
        {
            Message = "Command #2";
            try { MyMachine.MoveNext(MyStateMachine.Command.Command02); } catch (System.Exception ex) { LST.Beep(); Message = ex.Message; }
            MachineState = MyMachine.CurrentState.ToString();
        }

        /// <summary>
        /// Button_Command2_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Command21_Click(object sender, RoutedEventArgs e)
        {
            Message = "Command #21";
            try { MyMachine.MoveNext(MyStateMachine.Command.Command21); } catch (System.Exception ex) { LST.Beep(); Message = ex.Message; }
            MachineState = MyMachine.CurrentState.ToString();
        }

        /// <summary>
        /// Button_Command22_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Command22_Click(object sender, RoutedEventArgs e)
        {
            Message = "Command #22";
            try { MyMachine.MoveNext(MyStateMachine.Command.Command22); } catch (System.Exception ex) { LST.Beep(); Message = ex.Message; }
            MachineState = MyMachine.CurrentState.ToString();
        }

        /// <summary>
        /// Button_Command3_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Command3_Click(object sender, RoutedEventArgs e)
        {
            Message = "Command #3";
            try { MyMachine.MoveNext(MyStateMachine.Command.Command03); } catch (System.Exception ex) { LST.Beep(); Message = ex.Message; }
            MachineState = MyMachine.CurrentState.ToString();
        }

        /// <summary>
        /// Button_Command4_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Command4_Click(object sender, RoutedEventArgs e)
        {
            Message = "Command #4";
            try { MyMachine.MoveNext(MyStateMachine.Command.Command04); } catch (System.Exception ex) { LST.Beep(); Message = ex.Message; }
            MachineState = MyMachine.CurrentState.ToString();
        }

        /// <summary>
        /// Button_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
        /******************************/
        /*      Menu Events          */
        /******************************/
        #region Menu Events

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// StateMachineNextAction
        /// </summary>
        private void StateMachineNextAction()
        {
            switch (MyMachine.CurrentState)
            {
                case MyStateMachine.ProcessState.Start:
                    Message = "Command #1";
                    MyMachine.MoveNext(MyStateMachine.Command.Command01);
                    MachineState = MyMachine.CurrentState.ToString();
                    break;
                case MyStateMachine.ProcessState.State01:
                    if (MessageBox.Show("Would you like to go to State #3 with Command #2 (yes)? Or to State #2 with Command #21 (no)?", "Make a Decision !", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        Message = "Command #21";
                        MyMachine.MoveNext(MyStateMachine.Command.Command21);
                        MachineState = MyMachine.CurrentState.ToString();
                    }
                    else
                    {
                        Message = "Command #2";
                        MyMachine.MoveNext(MyStateMachine.Command.Command02);
                        MachineState = MyMachine.CurrentState.ToString();
                    }
                    break;
                case MyStateMachine.ProcessState.State02:
                    Message = "Command #22";
                    MyMachine.MoveNext(MyStateMachine.Command.Command22);
                    MachineState = MyMachine.CurrentState.ToString();
                    break;
                case MyStateMachine.ProcessState.State03:
                    Message = "Command #3";
                    MyMachine.MoveNext(MyStateMachine.Command.Command03);
                    MachineState = MyMachine.CurrentState.ToString();
                    break;
                case MyStateMachine.ProcessState.State04:
                    Message = "Command #4";
                    MyMachine.MoveNext(MyStateMachine.Command.Command04);
                    MachineState = MyMachine.CurrentState.ToString();
                    break;
                case MyStateMachine.ProcessState.End:
                    Message = "The State Machine has the state End, to start again press Start button";
                    MachineState = MyMachine.CurrentState.ToString();
                    break;
                default:
                    Message = "Unknown Status";
                    break;
            }
        }

        /// <summary>
        /// SetField
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        private void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }

        #endregion
    }
}
