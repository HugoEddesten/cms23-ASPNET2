﻿namespace AccountProvider.Models;

public class AccountModel
{
    public string UserId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string? PhoneNumber { get; set; }
}
