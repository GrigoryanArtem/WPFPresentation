using API.Model.Data;
using GalaSoft.MvvmLight.Messaging;

namespace GUI.Messages
{
    public class UpdateSomethingMessage : MessageBase
    {
        public UpdateSomethingMessage() { }

        public UpdateSomethingMessage(Something something) : base()
        {
            Something = something;
        }

        public Something Something { get; set; }
    }
}
