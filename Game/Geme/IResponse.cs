using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IResponse
    {
        /// <summary>
        /// Вызывается при попадании снаряда в обьект
        /// </summary>
        /// <param name="shellObj">Ссылка на снаряд</param>
        void Response(ShellObj shellObj);
    }
}
