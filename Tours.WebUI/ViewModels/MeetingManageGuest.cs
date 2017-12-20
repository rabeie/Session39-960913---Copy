using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SessionModel;

namespace Session.WebUI.ViewModels
{
    public class MeetingManageGuest
    {
        public int MeetingId { get; set; }
        public int GuestId { get; set; }
        public IEnumerable<Guest> Guests;


    }
}