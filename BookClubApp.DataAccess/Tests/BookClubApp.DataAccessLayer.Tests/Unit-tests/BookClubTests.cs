using BookClubApp.DataAccess.Entities;
 
public class BookClubTests
{
    [Fact]
    public void IsOpen_GetsCorrectValue()
    {
        // Arrange
        var bookClub = new BookClub
        {
            IsOpen = true,
            Name = "Test Club",
            Description = "Test Description",
            Type = "Test Type",
            LibrariesId = 1,
            Genre = "Test Genre"
        };
 
        // Act
        var isOpen = bookClub.IsOpen;
 
        // Assert
        Assert.True(isOpen);
    }
 
    [Fact]
    public void IsOpen_SetsCorrectValue()
    {
        // Arrange
        var bookClub = new BookClub
        {
            IsOpen = true,
            Name = "Test Club",
            Description = "Test Description",
            Type = "Test Type",
            LibrariesId = 1,
            Genre = "Test Genre"
        };
 
        // Act
        bookClub.IsOpen = false;
 
        // Assert
        Assert.False(bookClub.IsOpen);
    }
}