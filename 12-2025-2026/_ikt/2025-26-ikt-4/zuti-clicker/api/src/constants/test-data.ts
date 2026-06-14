export class TestData {
  static readonly BASE_URL = "http://localhost:2710";

  // Generated — call once per test suite so each run gets a unique user
  static generateUser() {
    const suffix = Math.random().toString(36).substring(2, 10);
    return {
      username: `test_${suffix}`,
      email: `test_${suffix}@example.com`,
      password: "TestPassword123!"
    };
  }

  // Hardcoded save payloads
  static readonly VALID_SAVE = {
    tokens: 1234.56,
    totalTokensEarned: 9999.99,
    totalClicks: 42,
    elapsedSeconds: 3600.5,
    units: [
      { unitId: "alpha", owned: 5 },
      { unitId: "beta", owned: 2 }
    ]
  };

  static readonly UPDATED_SAVE = {
    tokens: 5678.9,
    totalTokensEarned: 15000.0,
    totalClicks: 100,
    elapsedSeconds: 7200.0,
    units: [
      { unitId: "alpha", owned: 10 },
      { unitId: "gamma", owned: 3 }
    ]
  };

  // Missing the top-level number fields (tokens is absent)
  static readonly SAVE_MISSING_FIELDS = {
    totalTokensEarned: 100,
    totalClicks: 5,
    elapsedSeconds: 60,
    units: []
  };

  // units array contains invalid shape (wrong types)
  static readonly SAVE_INVALID_UNITS = {
    tokens: 100,
    totalTokensEarned: 100,
    totalClicks: 1,
    elapsedSeconds: 10,
    units: [{ unitId: 123, owned: -1 }]
  };
}
