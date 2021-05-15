using System.Collections.Generic;

namespace REST_with_ASP_NET.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);

    }
}
