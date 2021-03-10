using System;
using System.Threading;
using FluentAssertions;
using Xunit;

namespace Framework.Domain.Tests.Unit
{
    public class EntityTests
    {
        [Fact]
        public void entity_has_a_id()
        {
            var customer = new Customer(1);

            customer.Id.Should().Be(1);
        }

        [Fact]
        public void entities_with_same_id_are_equal()
        {
            var jack1 = new Customer(1);
            var jack2 = new Customer(1);

            jack2.Equals(jack1).Should().BeTrue();
        }

        [Fact]
        public void entities_with_same_id_but_different_types_are_not_equal()
        {
            var jack = new Customer(1);
            var it = new Department(1);

            jack.Equals(it).Should().BeFalse();
        }

        [Fact]
        public void entity_is_not_same_as_null()
        {
            var jack = new Customer(1);

            jack.Equals(null).Should().BeFalse();
        }

        private class Customer : Entity<long>
        {
            public Customer(long id) : base(id)
            {
            }
        }

        private class Department : Entity<long>
        {
            public Department(long id) : base(id)
            {
            }
        }
    }
}
