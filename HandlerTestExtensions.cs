using System;
using NServiceBus;
using NServiceBus.MessageInterfaces;
using NServiceBus.MessageInterfaces.MessageMapper.Reflection;

namespace NullReference.NServiceBus
{
    public static class HandlerTestExtensions
    {
        public static void Handle<T>(this IHandleMessages<T> handler, Action<T> a2) where T : IMessage
        {
            handler.Handle(MessageCreator.CreateMessage(a2));
        }
    }

    public class MessageCreator
    {
        public static T CreateMessage<T>(Action<T> a2) where T : IMessage
        {
            IMessageMapper mapper = new MessageMapper();
            mapper.Initialize(new[] { typeof(T) });

            return mapper.CreateInstance(a2);
        }
    }


}