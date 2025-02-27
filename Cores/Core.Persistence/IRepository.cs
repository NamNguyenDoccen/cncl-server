﻿using Ardalis.Specification;
using Core.Domain.Contracts;

namespace Core.Persistence;

public interface IRepository<T> : IRepositoryBase<T>
    where T : class, IAggregateRoot
{ }

public interface IReadRepository<T> : IReadRepositoryBase<T>
    where T : class, IAggregateRoot
{ }