//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GarageDoor {
    using Gadgeteer;
    using GTM = Gadgeteer.Modules;
    
    
    public partial class Program : Gadgeteer.Program {
        
        /// <summary>The USB Client DP module using socket 8 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.USBClientDP usbClientDP;
        
        /// <summary>The Relay X1 module using socket 4 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.RelayX1 relayX1;
        
        /// <summary>The RFID Reader module using socket 6 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.RFIDReader rfidReader;
        
        /// <summary>The Character Display module using socket 7 of the mainboard.</summary>
        private Gadgeteer.Modules.GHIElectronics.CharacterDisplay characterDisplay;
        
        /// <summary>This property provides access to the Mainboard API. This is normally not necessary for an end user program.</summary>
        protected new static GHIElectronics.Gadgeteer.FEZCerberus Mainboard {
            get {
                return ((GHIElectronics.Gadgeteer.FEZCerberus)(Gadgeteer.Program.Mainboard));
            }
            set {
                Gadgeteer.Program.Mainboard = value;
            }
        }
        
        /// <summary>This method runs automatically when the device is powered, and calls ProgramStarted.</summary>
        public static void Main() {
            // Important to initialize the Mainboard first
            Program.Mainboard = new GHIElectronics.Gadgeteer.FEZCerberus();
            Program p = new Program();
            p.InitializeModules();
            p.ProgramStarted();
            // Starts Dispatcher
            p.Run();
        }
        
        private void InitializeModules() {
            this.usbClientDP = new GTM.GHIElectronics.USBClientDP(8);
            this.relayX1 = new GTM.GHIElectronics.RelayX1(4);
            this.rfidReader = new GTM.GHIElectronics.RFIDReader(6);
            this.characterDisplay = new GTM.GHIElectronics.CharacterDisplay(7);
        }
    }
}
