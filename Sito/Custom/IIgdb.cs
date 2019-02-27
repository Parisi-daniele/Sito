using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sito.Custom
{
    public interface IIgdb
    {

        List<GameDetails> getBest10Games();

        List<GameDetails> getWorst10Games();

    }
}
