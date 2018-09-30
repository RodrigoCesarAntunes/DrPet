using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DrPet.Model.Token
{
    public class TokenDeCancelamento
    {
        private CancellationTokenSource cts;
        public TokenDeCancelamento()
        {
            cts= new CancellationTokenSource();
        }

        public CancellationToken getCancellationToken()
        {
            cts.CancelAfter(8000);
            return cts.Token;
        }
    }
}
