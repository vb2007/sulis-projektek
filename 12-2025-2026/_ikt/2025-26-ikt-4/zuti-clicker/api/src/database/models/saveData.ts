import { prisma } from "../prisma";

export interface UnitInput {
  unitId: string;
  owned: number;
}

export interface SaveInput {
  tokens: number;
  totalTokensEarned: number;
  totalClicks: number;
  elapsedSeconds: number;
  units: UnitInput[];
}

export const getSave = async (userId: number) => {
  return prisma.gameSave.findUnique({
    where: { userId },
    include: { units: true }
  });
};

export const upsertSave = async (userId: number, data: SaveInput) => {
  const { tokens, totalTokensEarned, totalClicks, elapsedSeconds, units } = data;
  const now = new Date();

  return prisma.$transaction(async (tx) => {
    const gameSave = await tx.gameSave.upsert({
      where: { userId },
      create: { userId, tokens, totalTokensEarned, totalClicks, elapsedSeconds, savedAt: now },
      update: { tokens, totalTokensEarned, totalClicks, elapsedSeconds, savedAt: now }
    });

    await tx.unitSave.deleteMany({ where: { gameSaveId: gameSave.id } });

    if (units.length > 0) {
      await tx.unitSave.createMany({
        data: units.map((u) => ({ gameSaveId: gameSave.id, unitId: u.unitId, owned: u.owned }))
      });
    }

    return gameSave;
  });
};

export const deleteSave = async (userId: number) => {
  // deleteMany is idempotent — no error if no save exists.
  // Cascade in the DB removes associated UnitSave rows.
  return prisma.gameSave.deleteMany({ where: { userId } });
};
