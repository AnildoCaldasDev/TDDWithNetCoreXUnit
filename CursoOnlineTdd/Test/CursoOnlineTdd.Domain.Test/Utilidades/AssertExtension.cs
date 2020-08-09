using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnlineTdd.Domain.Test.Utilidades
{
    public static class AssertExtension
    {
        public static void ValidarMenssagem(this ArgumentException argumentException, string messageError)
        {
            if (argumentException.Message.Equals(messageError))
                Assert.True(true);
            else
                Assert.False(true, $"A mensagem esperada era: '{messageError}'");
        }
    }
}
