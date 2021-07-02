using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Admin.Hubs
{
    public class AppointmentHub:Hub
    {
        private readonly IRepositoryApp<Appointment> _appointment;

        public AppointmentHub(IRepositoryApp<Appointment> Appointment)
        {
            _appointment = Appointment;
        }
         
        public async Task SendAppointment()
        {
            var result = await _appointment.GetAllAsync();
            await Clients.All.SendAsync("receiveAppointment", result.Count());
             
        }
    }
}
