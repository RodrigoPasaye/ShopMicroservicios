﻿namespace Authentication.api.DTO {
  public class RegisterDTO {
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Badge { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Position { get; set; } = null!;
  }
}
