using System;
using System.Collections.Generic;
using System.Text;

namespace TrainerAPI
{
    public interface IEpochInfo
    {
        int Id { get; }

        double Loss { get; }
    }
}
