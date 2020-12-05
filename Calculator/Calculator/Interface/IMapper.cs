using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interface
{
    public interface IMapper<TFrom, TTo>
    {
        TTo Map(TFrom value);

        IEnumerable<TTo> Map(IEnumerable<TFrom> values);
    }
}
