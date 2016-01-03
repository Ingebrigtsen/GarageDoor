using Gadgeteer;
using Gadgeteer.Modules.GHIElectronics;

namespace GarageDoor
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            relayX1.TurnOn();
            var garageDoorButton = new GarageDoorButton(3);
            garageDoorButton.Click += (s) => ToggleGarageDoor();
            rfidReader.IdReceived += RfidReaderIdReceived;

            characterDisplay.Clear();
            characterDisplay.BacklightEnabled = true;

            Print("Waiting...");
        }
        
        void RfidReaderIdReceived(RFIDReader sender, string e)
        {
            var allowedKeys = new string[] { "0D00197224", "000083D4DD" };
            foreach( var key in allowedKeys )
            {
                if( e == key )
                {
                    ToggleGarageDoor();
                    break;
                }
            }
        }

            
        void ToggleGarageDoor()
        {
            Print("Opening/closing...");
            DelayPrint(2000, "Waiting...");

            relayX1.TurnOff();
            var timer = new Timer(500);
            timer.Tick += (t) =>
            {
                relayX1.TurnOn();
                t.Stop();
                timer = null;
                Reboot();
            };
            timer.Start();
        }

        void DelayPrint(int milliseconds, string top, string bottom = "")
        {
            var timer = new Timer(milliseconds);
            timer.Tick += (t) => {
                Print(top, bottom);
                timer.Stop();
                timer = null;
            };
            timer.Start();
        }

        void Print(string top, string bottom = "")
        {
            characterDisplay.Clear();
            characterDisplay.SetCursorPosition(0, 0);
            characterDisplay.Print(top);
            characterDisplay.SetCursorPosition(1, 0);
            characterDisplay.Print(bottom);
        }
    }
}
