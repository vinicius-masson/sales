

using Sales.Domain.Enums;

namespace Sales.Domain.Entities;


/// <summary>
/// Represents a user in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Gets the user's full name.
    /// Must not be null or empty and should contain both first and last names.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets the user's email address.
    /// Must be a valid email format and is used as a unique identifier for authentication.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets the user's phone number.
    /// Must be a valid phone number format following the pattern (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; set; } = string.Empty ;

    /// <summary>
    /// Gets the hashed password for authentication.
    /// Password must meet security requirements: minimum 8 characters, at least one uppercase letter,
    /// one lowercase letter, one number, and one special character.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets the user's role in the system.
    /// Determines the user's permissions and access levels.
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// Gets the user's current status.
    /// Indicates whether the user is active, inactive, or blocked in the system.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the user's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Initializes a new instance of the User class.
    /// </summary>
    public User()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Activates the user account.
    /// Changes the user's status to Active.
    /// </summary>
    public void Activate()
    {
        Status = UserStatus.Active;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Deactivates the user account.
    /// Changes the user's status to Inactive.
    /// </summary>
    public void Deactivate()
    {
        Status = UserStatus.Inactive;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Blocks the user account.
    /// Changes the user's status to Blocked.
    /// </summary>
    public void Suspend()
    {
        Status = UserStatus.Suspended;
        UpdatedAt = DateTime.UtcNow;
    }
}