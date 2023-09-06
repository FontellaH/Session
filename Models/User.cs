using System.ComponentModel.DataAnnotations;

namespace Session.Models;

public class User
{
    [Required(ErrorMessage = "Please enter your name!")]
    public string Name { get; set; }

    public int CurrentNumber { get; set; }
}