using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp;

public class AuthService
{
    private List<UserModel> _users = new List<UserModel>();
    private UserModel _currentUser;

    public bool Register(string username, string email, string password)
    {
        if (_users.Any(u => u.Username == username || u.Email == email))
            return false;

        var user = new UserModel
        {
            Id = _users.Count + 1,
            Username = username,
            Email = email,
            PasswordHash = password
        };
        
        _users.Add(user);
        return true;
    }

    public bool Login(string username, string password)
    {
        var user = _users.FirstOrDefault(u => u.Username == username && u.PasswordHash == password);
        if (user == null) return false;
        
        _currentUser = user;
        return true;
    }

    public UserModel GetCurrentUser() => _currentUser;
    
    public void Logout() => _currentUser = null;
}
