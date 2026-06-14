import express from "express";
import { getSave, upsertSave, deleteSave, type UnitInput } from "../database/models/saveData";
import { Responses } from "../constants/responses";

interface SaveBody {
  tokens?: unknown;
  totalTokensEarned?: unknown;
  totalClicks?: unknown;
  elapsedSeconds?: unknown;
  units?: unknown;
}

function isValidUnits(units: unknown): units is UnitInput[] {
  if (!Array.isArray(units)) return false;
  return units.every((u) => {
    if (u === null || typeof u !== "object") return false;
    const entry = u as Record<string, unknown>;
    return (
      typeof entry["unitId"] === "string" &&
      typeof entry["owned"] === "number" &&
      (entry["owned"] as number) >= 0
    );
  });
}

/**
 * @openapi
 * /save:
 *   get:
 *     tags:
 *       - Save
 *     summary: Load the current user's game save
 *     security:
 *       - cookieAuth: []
 *     responses:
 *       '200':
 *         description: Save data (or null if no save exists yet)
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/LoadSaveResponse'
 *       '401':
 *         $ref: '#/components/responses/Unauthorized'
 *       '500':
 *         $ref: '#/components/responses/InternalError'
 */
export const loadSave = async (req: express.Request, res: express.Response) => {
  try {
    const userId = req.identity?.id;
    if (userId === undefined) {
      const r = Responses.AUTH.UNAUTHORIZED;
      res.status(r.status).json(r.body);
      return;
    }

    const save = await getSave(userId);

    if (!save) {
      res.status(200).json({ save: null });
      return;
    }

    res.status(200).json({
      save: {
        tokens: save.tokens,
        totalTokensEarned: save.totalTokensEarned,
        totalClicks: save.totalClicks,
        elapsedSeconds: save.elapsedSeconds,
        savedAt: save.savedAt,
        units: save.units.map((u) => ({ unitId: u.unitId, owned: u.owned }))
      }
    });
  } catch (error) {
    console.error("Load save error:", error);
    const r = Responses.SAVE.INTERNAL_ERROR;
    res.status(r.status).json(r.body);
  }
};

/**
 * @openapi
 * /save:
 *   put:
 *     tags:
 *       - Save
 *     summary: Create or overwrite the current user's game save
 *     security:
 *       - cookieAuth: []
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/StoreSaveRequest'
 *     responses:
 *       '200':
 *         description: Save persisted successfully
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/StoreSaveResponse'
 *       '400':
 *         description: Missing or invalid fields
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/ErrorResponse'
 *       '401':
 *         $ref: '#/components/responses/Unauthorized'
 *       '500':
 *         $ref: '#/components/responses/InternalError'
 */
export const storeSave = async (req: express.Request, res: express.Response) => {
  try {
    const userId = req.identity?.id;
    if (userId === undefined) {
      const r = Responses.AUTH.UNAUTHORIZED;
      res.status(r.status).json(r.body);
      return;
    }

    const { tokens, totalTokensEarned, totalClicks, elapsedSeconds, units } =
      req.body as SaveBody;

    if (
      typeof tokens !== "number" ||
      typeof totalTokensEarned !== "number" ||
      typeof totalClicks !== "number" ||
      typeof elapsedSeconds !== "number" ||
      !isValidUnits(units)
    ) {
      const r =
        typeof tokens !== "number" ||
        typeof totalTokensEarned !== "number" ||
        typeof totalClicks !== "number" ||
        typeof elapsedSeconds !== "number"
          ? Responses.SAVE.MISSING_FIELDS
          : Responses.SAVE.INVALID_UNITS;
      res.status(r.status).json(r.body);
      return;
    }

    const save = await upsertSave(userId, {
      tokens,
      totalTokensEarned,
      totalClicks,
      elapsedSeconds,
      units
    });

    const r = Responses.SAVE.SAVE_SUCCESS;
    res.status(r.status).json({ ...r.body, savedAt: save.savedAt });
  } catch (error) {
    console.error("Store save error:", error);
    const r = Responses.SAVE.INTERNAL_ERROR;
    res.status(r.status).json(r.body);
  }
};

/**
 * @openapi
 * /save:
 *   delete:
 *     tags:
 *       - Save
 *     summary: Reset (delete) the current user's game save
 *     security:
 *       - cookieAuth: []
 *     responses:
 *       '200':
 *         description: Save reset (idempotent — succeeds even if no save existed)
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/MessageResponse'
 *       '401':
 *         $ref: '#/components/responses/Unauthorized'
 *       '500':
 *         $ref: '#/components/responses/InternalError'
 */
export const resetSave = async (req: express.Request, res: express.Response) => {
  try {
    const userId = req.identity?.id;
    if (userId === undefined) {
      const r = Responses.AUTH.UNAUTHORIZED;
      res.status(r.status).json(r.body);
      return;
    }

    await deleteSave(userId);

    const r = Responses.SAVE.RESET_SUCCESS;
    res.status(r.status).json(r.body);
  } catch (error) {
    console.error("Reset save error:", error);
    const r = Responses.SAVE.INTERNAL_ERROR;
    res.status(r.status).json(r.body);
  }
};
