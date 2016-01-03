using Gadgeteer;
using Gadgeteer.Modules;
using Gadgeteer.SocketInterfaces;
using Microsoft.SPOT;

namespace GarageDoor
{
    public class GarageDoorButton : Module
    {
        Socket _socket;
        DigitalOutput _output;


        public event EventHandler Clicked = (s, e) => { };
        
        public GarageDoorButton(int socketNumber)
        {
            _socket = Socket.GetSocket(socketNumber, true, this, null);

            _socket.EnsureTypeIsSupported(new char[] { 'X', 'Y' }, this);

            var input = InterruptInputFactory.Create(_socket, Socket.Pin.Three, GlitchFilterMode.On, ResistorMode.PullUp, InterruptMode.RisingAndFallingEdge, this);
            input.Interrupt += Input_Interrupt;

            _output = DigitalOutputFactory.Create(_socket, Socket.Pin.Four, true, this);
        }

        void Input_Interrupt(InterruptInput sender, bool value)
        {
            if (value == true) Clicked(this, new EventArgs());
        }
    }
}
