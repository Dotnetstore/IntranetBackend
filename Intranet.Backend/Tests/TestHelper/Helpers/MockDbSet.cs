using Microsoft.EntityFrameworkCore;
using Moq;
using TestHelper.Helpers.TestDbAsync;

namespace TestHelper.Helpers;

public static class MockDbSet
{
    public static Mock<DbSet<TEntity>> Build<TEntity>(List<TEntity> data) where TEntity : class
    {
        var queryable = data.AsQueryable();
        var mockSet = new Mock<DbSet<TEntity>>();

        mockSet.As<IQueryable<TEntity>>().Setup(q => q.Provider).Returns(queryable.Provider);
        mockSet.As<IQueryable<TEntity>>().Setup(q => q.Expression).Returns(queryable.Expression);
        mockSet.As<IQueryable<TEntity>>().Setup(q => q.ElementType).Returns(queryable.ElementType);
        mockSet.As<IQueryable<TEntity>>().Setup(q => q.GetEnumerator()).Returns(queryable.GetEnumerator());

        mockSet.Setup(q => q.Add(It.IsAny<TEntity>())).Callback<TEntity>(data.Add);
        return mockSet;
    }

    public static Mock<DbSet<TEntity>> BuildAsync<TEntity>(List<TEntity> data) where TEntity : class
    {
        var queryable = data.AsQueryable();
        var mockSet = new Mock<DbSet<TEntity>>();

        mockSet.As<IAsyncEnumerable<TEntity>>()
            .Setup(q => q.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
            .Returns(new AsyncEnumerator<TEntity>(queryable.GetEnumerator()));

        mockSet.As<IQueryable<TEntity>>()
            .Setup(q => q.Provider)
            .Returns(new TestAsyncQueryProvider<TEntity>(queryable.Provider));
        
        mockSet.As<IQueryable<TEntity>>().Setup(q => q.Expression).Returns(queryable.Expression);
        mockSet.As<IQueryable<TEntity>>().Setup(q => q.ElementType).Returns(queryable.ElementType);
        mockSet.As<IQueryable<TEntity>>().Setup(q => q.GetEnumerator()).Returns(() => queryable.GetEnumerator());

        mockSet.Setup(q => q.Add(It.IsAny<TEntity>())).Callback<TEntity>(data.Add);
        return mockSet;
    }
}