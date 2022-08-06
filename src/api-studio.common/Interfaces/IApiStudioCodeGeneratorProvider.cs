using System.Collections.Generic;
using ApiStudioIO.Common.Models.Build;

namespace ApiStudioIO.Common.Interfaces
{
    public interface IApiStudioCodeGeneratorProvider
    {
        List<SourceCodeEntity> Run();
    }
}
