using System;
using System.Collections.Generic;

namespace Allatmenhely.WebApp.Models;

public partial class Appointment
{
    public Guid Id { get; set; }

    public DateTime AppointmentAt { get; set; }

    public int ReservedTo { get; set; }

    public Guid ReservedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public virtual User ReservedByNavigation { get; set; } = null!;

    public virtual Animal ReservedToNavigation { get; set; } = null!;
}
