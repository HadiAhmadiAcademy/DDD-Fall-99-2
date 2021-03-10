using System;
using System.Reflection.PortableExecutable;
using FluentAssertions;
using Xunit;

namespace Framework.Domain.Tests.Unit
{
    public class DomainEventTests
    {
        [Fact]
        public void each_event_has_a_unique_identifier()
        {
            var @event = new UserRegistered();

            @event.EventId.Should().NotBeEmpty();
        }

        //TODO: this test needs a fix
        [Fact]
        public void events_have_publish_date_time_based_on_current_time_of_server()
        {
            var beforeCreatingEvent = DateTime.Now;
            var @event = new UserRegistered();

            @event.PublishDateTime.Should().BeAfter(beforeCreatingEvent);
        }

        private class UserRegistered : DomainEvent{ }
    }
}