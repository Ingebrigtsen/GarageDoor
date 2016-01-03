using Gadgeteer.Modules.GHIElectronics;

namespace GarageDoor
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            var garageDoorButton = new GarageDoorButton(3);

        }
    }
}
