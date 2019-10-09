using System;

namespace Shelter.Mvc.Models
{
    public class AnimalViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
