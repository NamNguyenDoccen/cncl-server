﻿using Core.Domain.Events;
using System.Collections.ObjectModel;

namespace Core.Domain.Contracts;

public interface IEntity
{
    Collection<DomainEvent> DomainEvents { get; }
}

public interface IEntity<out TId> : IEntity
{
    TId Id { get; }
}