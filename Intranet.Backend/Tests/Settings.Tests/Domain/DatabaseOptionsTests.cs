using FluentAssertions;
using Settings.Domain;
using TestHelper.Helpers;

namespace Settings.Tests.Domain;

internal sealed class DatabaseOptionsTests
{
    private readonly DatabaseOptions _databaseOptions = new()
    {
        InMemoryConnectionstring = "InMemoryConnectionstring",
        SQLConnectionstring = "SQLConnectionstring",
        SQLiteConnectionstring = "SQLiteConnectionstring",
        UseInMemory = false,
        UseSQL = true,
        UseSQLite = false
    };

    private readonly DatabaseOptions _emptyDatabaseOptions = new()
    {
        InMemoryConnectionstring = string.Empty,
        SQLConnectionstring = string.Empty,
        SQLiteConnectionstring = string.Empty,
        UseInMemory = false,
        UseSQL = true,
        UseSQLite = false
    };

    private readonly DatabaseOptions _minLengthDatabaseOptions = new()
    {
        InMemoryConnectionstring = "a",
        SQLConnectionstring = "a",
        SQLiteConnectionstring = "a",
        UseInMemory = false,
        UseSQL = true,
        UseSQLite = false
    };

    private readonly DatabaseOptions _maxLengthDatabaseOptions = new()
    {
        InMemoryConnectionstring = "a".PadLeft(256, 'a'),
        SQLConnectionstring = "a".PadLeft(256, 'a'),
        SQLiteConnectionstring = "a".PadLeft(256, 'a'),
        UseInMemory = false,
        UseSQL = true,
        UseSQLite = false
    };

    [Test]
    public void InMemoryConnectionstring_Should_Have_Correct_Value()
    {
        _databaseOptions.InMemoryConnectionstring.Should().Be("InMemoryConnectionstring");
    }

    [Test]
    public void SQLConnectionstring_Should_Have_Correct_Value()
    {
        _databaseOptions.SQLConnectionstring.Should().Be("SQLConnectionstring");
    }

    [Test]
    public void SQLiteConnectionstring_Should_Have_Correct_Value()
    {
        _databaseOptions.SQLiteConnectionstring.Should().Be("SQLiteConnectionstring");
    }

    [Test]
    public void UseInMemory_Should_Have_Correct_Value()
    {
        _databaseOptions.UseInMemory.Should().Be(false);
    }

    [Test]
    public void UseSQL_Should_Have_Correct_Value()
    {
        _databaseOptions.UseSQL.Should().Be(true);
    }

    [Test]
    public void UseSQLite_Should_Have_Correct_Value()
    {
        _databaseOptions.UseSQLite.Should().Be(false);
    }

    [Test]
    public void InMemoryConnectionstring_Should_Be_Required()
    {
        Assert.That(ValidationHelpers.ValidateModel(_emptyDatabaseOptions).Any( q => 
            q.MemberNames.Contains("InMemoryConnectionstring") &&
            q.ErrorMessage.Contains("required")));
    }

    [Test]
    public void InMemoryConnectionstring_Should_Have_MinLength()
    {
        Assert.That(ValidationHelpers.ValidateModel(_minLengthDatabaseOptions).Any( q => 
            q.MemberNames.Contains("InMemoryConnectionstring") &&
            q.ErrorMessage.Contains("minimum length") &&
            q.ErrorMessage.Contains("5")));
    }

    [Test]
    public void InMemoryConnectionstring_Should_Have_MaxLength()
    {
        Assert.That(ValidationHelpers.ValidateModel(_maxLengthDatabaseOptions).Any( q => 
            q.MemberNames.Contains("InMemoryConnectionstring") &&
            q.ErrorMessage.Contains("maximum length") &&
            q.ErrorMessage.Contains("50")));
    }

    [Test]
    public void SQLConnectionstring_Should_Be_Required()
    {
        Assert.That(ValidationHelpers.ValidateModel(_emptyDatabaseOptions).Any( q => 
            q.MemberNames.Contains("SQLConnectionstring") &&
            q.ErrorMessage.Contains("required")));
    }

    [Test]
    public void SQLConnectionstring_Should_Have_MinLength()
    {
        Assert.That(ValidationHelpers.ValidateModel(_minLengthDatabaseOptions).Any( q => 
            q.MemberNames.Contains("SQLConnectionstring") &&
            q.ErrorMessage.Contains("minimum length") &&
            q.ErrorMessage.Contains("10")));
    }

    [Test]
    public void SQLConnectionstring_Should_Have_MaxLength()
    {
        Assert.That(ValidationHelpers.ValidateModel(_maxLengthDatabaseOptions).Any( q => 
            q.MemberNames.Contains("SQLConnectionstring") &&
            q.ErrorMessage.Contains("maximum length") &&
            q.ErrorMessage.Contains("255")));
    }

    [Test]
    public void SQLiteConnectionstring_Should_Be_Required()
    {
        Assert.That(ValidationHelpers.ValidateModel(_emptyDatabaseOptions).Any( q => 
            q.MemberNames.Contains("SQLiteConnectionstring") &&
            q.ErrorMessage.Contains("required")));
    }

    [Test]
    public void SQLiteConnectionstring_Should_Have_MinLength()
    {
        Assert.That(ValidationHelpers.ValidateModel(_minLengthDatabaseOptions).Any( q => 
            q.MemberNames.Contains("SQLiteConnectionstring") &&
            q.ErrorMessage.Contains("minimum length") &&
            q.ErrorMessage.Contains("5")));
    }

    [Test]
    public void SQLiteConnectionstring_Should_Have_MaxLength()
    {
        Assert.That(ValidationHelpers.ValidateModel(_maxLengthDatabaseOptions).Any( q => 
            q.MemberNames.Contains("SQLiteConnectionstring") &&
            q.ErrorMessage.Contains("maximum length") &&
            q.ErrorMessage.Contains("255")));
    }
}