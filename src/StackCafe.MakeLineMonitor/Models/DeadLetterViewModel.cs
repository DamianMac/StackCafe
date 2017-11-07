using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Nimbus;

namespace StackCafe.MakeLineMonitor.Models
{
    public class DeadLetterViewModel
    {
        private readonly NimbusMessage message;
        private readonly int numberOfDeadLetters;
        public DeadLetterViewModel(int numberOfDeadLetters, NimbusMessage message)
        {
            this.numberOfDeadLetters = numberOfDeadLetters;
            this.message = message;
        }

        public DeadLetterViewModel() : this(0, null)
        {
        }

        public string Title
        {
            get { return this.message == null ? "No Dead Letters!" : "Decide This Message's Fate - there are " + this.numberOfDeadLetters + " more to deal with:"; }
        }

        public string Message
        {
            get { return this.message == null ? string.Empty : JsonConvert.SerializeObject(this.message.Payload); }
        }
    }
}