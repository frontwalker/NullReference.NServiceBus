using System;
using NServiceBus;
using NServiceBus.Testing;

namespace NullReference.NServiceBus
{
    public static class HandlerTestExtensions
    {
        public static void Handle<T>(this IHandleMessages<T> handler, Action<T> a2) where T : IMessage
        {
            Test.Initialize();

            var message = Test.CreateInstance(a2);

            handler.Handle(message);
        }
    }
}