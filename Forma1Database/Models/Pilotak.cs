using System;
using System.Collections.Generic;

namespace Forma1Database.Models;

public partial class Pilotak
{
    public int Pazon { get; set; }

    public string Pnev { get; set; } = null!;

    public int Szev { get; set; }

    public int Csapat { get; set; }

    public virtual Csapatok CsapatNavigation { get; set; } = null!;
}
