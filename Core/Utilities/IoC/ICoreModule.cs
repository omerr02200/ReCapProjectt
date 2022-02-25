using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection); //Genel bağımlılıkların yüklemek için, parametre olarak, startup.cs'de bağımlılıkları belirttiğimiz
                                                         //tip olan IServiceCollection veriyoruz.
    }
}
