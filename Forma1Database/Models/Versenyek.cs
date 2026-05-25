using System;
using System.Collections.Generic;

namespace Forma1Database.Models;

public partial class Versenyek
{
    public string Vkod { get; set; } = null!;

    public DateTime Datum { get; set; }

    public string Vnev { get; set; } = null!;

    public string Hely { get; set; } = null!;

    public int Kor { get; set; }

    public int Hossz { get; set; }
}
