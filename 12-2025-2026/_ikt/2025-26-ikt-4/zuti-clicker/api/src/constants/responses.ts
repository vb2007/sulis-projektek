export class Responses {
  static readonly AUTH = {
    MISSING_REGISTER_FIELDS: {
      status: 400,
      body: { error: "The username, email, and password fields are required." }
    },
    MISSING_LOGIN_FIELDS: { status: 400, body: { error: "Email and password are required." } },
    EMAIL_EXISTS: { status: 409, body: { error: "A user with that email already exists." } },
    USERNAME_EXISTS: { status: 409, body: { error: "A user with that username already exists." } },
    INVALID_CREDENTIALS: { status: 401, body: { error: "Invalid credentials." } },
    UNAUTHORIZED: { status: 401, body: { error: "Unauthorized." } },
    INTERNAL_ERROR: { status: 500, body: { error: "Internal server error." } },
    REGISTER_SUCCESS: { status: 201, body: { message: "User registered successfully." } },
    LOGIN_SUCCESS: { status: 200, body: { message: "Login successful." } }
  } as const;

  static readonly SAVE = {
    MISSING_FIELDS: {
      status: 400,
      body: {
        error: "tokens, totalTokensEarned, totalClicks, elapsedSeconds, and units are required."
      }
    },
    INVALID_UNITS: {
      status: 400,
      body: { error: "Each unit must have a valid unitId (string) and owned count (number >= 0)." }
    },
    NOT_FOUND: { status: 404, body: { save: null } },
    SAVE_SUCCESS: { status: 200, body: { message: "Save updated successfully." } },
    RESET_SUCCESS: { status: 200, body: { message: "Save reset successfully." } },
    INTERNAL_ERROR: { status: 500, body: { error: "Internal server error." } }
  } as const;
}
