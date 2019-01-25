using Newtonsoft.Json;
using System;

namespace WebCommon.Models
{
    [Serializable]
    public class MessageDialogVM
    {
        public bool IsError { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public string AsString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static MessageDialogVM FromString(string value)
        {
            return JsonConvert.DeserializeObject<MessageDialogVM>(value);
        }
    }
}
