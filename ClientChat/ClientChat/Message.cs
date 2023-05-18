using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChat
{
    internal class Message
    {
    
            public string? ToSide { get; set; }
            public string? FromSide { get; set; }
            public DateTime TimeSend { get; set; }
            public string? TypeMessage { get; set; }
            public bool? StatusSend { get; set; }
            public string? ContentSend { get; set; }
        }
    }

