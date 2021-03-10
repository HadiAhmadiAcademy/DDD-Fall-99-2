using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Framework.Domain.Tests.Unit
{
    public class AggregateRootTests
    {
        [Fact]
        public void keeps_events_in_the_list_of_uncommitted_changes()
        {
            var customer = new Customer(10);

            customer.Activate();

            var expectedEvent = new CustomerActivated(10);
            customer.GetUncommittedEvents().Should().HaveCount(1);
            customer.GetUncommittedEvents()
                .First().Should().BeEquivalentTo(expectedEvent, 
                        a => a.Excluding(z => z.EventId).Excluding(z=> z.PublishDateTime));
        }

        [Fact]
        public void clears_events()
        {
            var customer = new Customer(10);
            customer.Activate();

            customer.GetUncommittedEvents().Should().HaveCount(1);
        }

        private class Customer : AggregateRoot<long>
        {
            public Customer(long id): base(id)
            {
                
            }

            public void Activate()
            {
                this.Publish(new CustomerActivated(this.Id));
            }
        }
        private class CustomerActivated : DomainEvent
        {
            public long Id { get; private set; }
            public CustomerActivated(long id)
            {
                Id = id;
            }
        }
    }
}
