using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryUI.Models
{
    public class JsonResponse
    {
        public string Status { get; set; } = "S";
        public string Message { get; set; } = "Success";
        public object Data { get; set; }
    }
}