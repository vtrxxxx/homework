using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_13_Service
{
    public interface IRequestHandler<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }

    public interface IRequestHandler<TResponse>
    {
        Task<TResponse> Handle();
    }
}
