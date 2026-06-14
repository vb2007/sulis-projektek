import swaggerJsdoc from "swagger-jsdoc";
import { fileURLToPath } from "url";
import path from "path";

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

/**
 * Called after dotenv.config() so that IP/PORT env vars are resolved at
 * invocation time rather than at module evaluation time.
 */
export const buildSwaggerSpec = (): object => {
  const options: swaggerJsdoc.Options = {
    definition: {
      openapi: "3.1.0",
      info: {
        title: "Zuti Clicker API",
        version: "1.0.0",
        description: "REST API for the Zuti Clicker game."
      },
      servers: [
        {
          url: `http://${process.env.IP ?? "localhost"}:${process.env.PORT ?? "3000"}`
        }
      ],
      components: {
        securitySchemes: {
          cookieAuth: {
            type: "apiKey",
            in: "cookie",
            name: "AUTH_TOKEN",
            description:
              "Session token issued on a successful `/login` call. " +
              "Set automatically via `Set-Cookie`; pass it manually when using the Try-it-out panel."
          }
        },
        schemas: {
          RegisterRequest: {
            type: "object",
            required: ["username", "email", "password"],
            properties: {
              username: { type: "string", example: "johndoe" },
              email: { type: "string", format: "email", example: "john@example.com" },
              password: { type: "string", format: "password", example: "s3cur3P@ssw0rd" }
            }
          },
          LoginRequest: {
            type: "object",
            required: ["email", "password"],
            properties: {
              email: { type: "string", format: "email", example: "john@example.com" },
              password: { type: "string", format: "password", example: "s3cur3P@ssw0rd" }
            }
          },
          ErrorResponse: {
            type: "object",
            properties: {
              error: { type: "string" }
            }
          },
          MessageResponse: {
            type: "object",
            properties: {
              message: { type: "string" }
            }
          },
          UnitSave: {
            type: "object",
            required: ["unitId", "owned"],
            properties: {
              unitId: { type: "string", example: "alpha" },
              owned: { type: "integer", minimum: 0, example: 5 }
            }
          },
          StoreSaveRequest: {
            type: "object",
            required: [
              "tokens",
              "totalTokensEarned",
              "totalClicks",
              "elapsedSeconds",
              "units"
            ],
            properties: {
              tokens: {
                type: "number",
                description: "Current token balance",
                example: 1234.56
              },
              totalTokensEarned: {
                type: "number",
                description: "All-time tokens earned",
                example: 9999.99
              },
              totalClicks: {
                type: "integer",
                description: "Total manual clicks",
                example: 420
              },
              elapsedSeconds: {
                type: "number",
                description: "Total time played in seconds",
                example: 3600.5
              },
              units: {
                type: "array",
                items: { $ref: "#/components/schemas/UnitSave" }
              }
            }
          },
          SaveData: {
            type: "object",
            properties: {
              tokens: { type: "number", example: 1234.56 },
              totalTokensEarned: { type: "number", example: 9999.99 },
              totalClicks: { type: "integer", example: 420 },
              elapsedSeconds: { type: "number", example: 3600.5 },
              savedAt: { type: "string", format: "date-time" },
              units: {
                type: "array",
                items: { $ref: "#/components/schemas/UnitSave" }
              }
            }
          },
          LoadSaveResponse: {
            type: "object",
            properties: {
              save: {
                oneOf: [
                  { $ref: "#/components/schemas/SaveData" },
                  { type: "null" }
                ],
                description: "null when the user has no save yet"
              }
            }
          },
          StoreSaveResponse: {
            allOf: [
              { $ref: "#/components/schemas/MessageResponse" },
              {
                type: "object",
                properties: {
                  savedAt: { type: "string", format: "date-time" }
                }
              }
            ]
          }
        },
        responses: {
          Unauthorized: {
            description: "Missing or invalid session token",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/ErrorResponse" },
                example: { error: "Unauthorized." }
              }
            }
          },
          InternalError: {
            description: "Internal server error",
            content: {
              "application/json": {
                schema: { $ref: "#/components/schemas/ErrorResponse" },
                example: { error: "Internal server error." }
              }
            }
          }
        }
      }
    },
    // Scans these files for @openapi JSDoc blocks at startup
    apis: [path.join(__dirname, "../controllers/*.ts")]
  };

  return swaggerJsdoc(options);
};
