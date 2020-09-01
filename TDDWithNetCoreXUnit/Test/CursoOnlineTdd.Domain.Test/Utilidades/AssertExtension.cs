﻿using System;
using Xunit;

namespace TDDWithNetCoreXUnit.Test.Utilidades
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
